﻿
Imports System.Drawing
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Content
Imports BioNovoGene.Analytical.MassSpectrometry.Math.MRM
Imports Microsoft.VisualBasic.Data.Bootstrapping
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports stdNum = System.Math

Namespace LinearQuantitative.Linear

    ''' <summary>
    ''' 普通标准曲线计算算法模块
    ''' </summary>
    Public Class InternalStandardMethod

        ReadOnly contents As ContentTable
        ReadOnly baselineQuantile As Double = 0.65
        ReadOnly maxDeletions As Integer = 1

        Sub New(contents As ContentTable, Optional baselineQuantile As Double = 0.65, Optional maxDeletions As Integer = 1)
            Me.maxDeletions = maxDeletions
            Me.contents = contents
            Me.baselineQuantile = baselineQuantile
        End Sub

        ''' <summary>
        ''' linear regression
        ''' </summary>
        ''' <param name="points"></param>
        ''' <returns></returns>
        Public Iterator Function ToLinears(points As IEnumerable(Of TargetPeakPoint)) As IEnumerable(Of StandardCurve)
            Dim ionGroups As Dictionary(Of String, TargetPeakPoint()) = points _
                .GroupBy(Function(p) p.Name) _
                .ToDictionary(Function(ion) ion.Key,
                              Function(samples)
                                  Return samples.ToArray
                              End Function)
            Dim linearSamples As String() = ionGroups.Values _
                .IteratesALL _
                .Select(Function(p) p.SampleName) _
                .Distinct _
                .ToArray

            For Each featureId As String In ionGroups.Keys
                Yield ToFeatureLinear(ionGroups, featureId, linearSamples)
            Next
        End Function

        ''' <summary>
        ''' linear regression
        ''' </summary>
        ''' <param name="ionGroups"></param>
        ''' <param name="ionKey"></param>
        ''' <param name="linearSamples"></param>
        ''' <returns></returns>
        Private Function ToFeatureLinear(ionGroups As Dictionary(Of String, TargetPeakPoint()),
                                         ionKey As String,
                                         linearSamples As String()) As StandardCurve

            Dim define As Standards = contents.GetStandards(ionKey)
            Dim rawPoints As TargetPeakPoint() = ionGroups(ionKey)
            Dim isPoints As TargetPeakPoint() = ionGroups(define.ISTD)
            Dim points As New List(Of ReferencePoint)
            Dim A As Double() = TPA(linearSamples, rawPoints)
            Dim ISTPA As Double() = TPA(linearSamples, isPoints)
            Dim C As Double() = linearSamples.Select(Function(level) define.C(level)).ToArray
            Dim CIS As Double = 1
            Dim invalids As New List(Of PointF)
            Dim line As PointF() = StandardCurveWorker _
                .CreateModelPoints(C, A, ISTPA, CIS, ionKey, define.Name, points) _
                .ToArray
            Dim fit As IFitted = StandardCurve.CreateLinearRegression(line, maxDeletions, removed:=invalids)

            ' get points that removed from linear modelling
            For Each ptRef As ReferencePoint In points
                For Each invalid In invalids
                    If stdNum.Abs(invalid.X - ptRef.Cti) <= 0.0001 AndAlso stdNum.Abs(invalid.Y - ptRef.Px) <= 0.0001 Then
                        ptRef.valid = False
                        Exit For
                    End If
                Next
            Next

            Dim out As New StandardCurve With {
                .name = ionKey,
                .linear = fit,
                .points = points.PopAll,
                .[IS] = contents.GetIS(define.ISTD)
            }
            Dim fy As Func(Of Double, Double) = out.reverseModel
            Dim ptY#

            For Each pt As ReferencePoint In out.points
                If pt.AIS > 0 Then
                    ptY = pt.Ati / pt.AIS
                Else
                    ptY = pt.Ati
                End If

                pt.yfit = stdNum.Round(fy(ptY), 5)
            Next

            Return out
        End Function

        Private Function TPA(linearSamples As String(), points As IEnumerable(Of TargetPeakPoint)) As Double()
            Dim getByLevels = points.ToDictionary(Function(p) p.SampleName)
            Dim vec As New List(Of Double)
            Dim deconv As (area#, baseline#, maxPeakHeight#)
            Dim target As TargetPeakPoint

            For Each sampleLevel As String In linearSamples
                target = getByLevels(sampleLevel)
                deconv = target.Peak.ticks _
                    .Shadows _
                    .TPAIntegrator(target.Peak, baselineQuantile)

                vec.Add(deconv.area)
            Next

            Return vec.ToArray
        End Function
    End Class
End Namespace