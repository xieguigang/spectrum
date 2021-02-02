﻿Imports BioNovoGene.Analytical.MassSpectrometry.Math.Chromatogram
Imports BioNovoGene.Analytical.MassSpectrometry.Math.LinearQuantitative.Linear
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Ms1
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Spectra
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports stdNum = System.Math

Namespace GCMS.QuantifyAnalysis

    Public Class SIMIonExtract : Inherits FeatureExtract(Of Raw)

        ReadOnly ions As QuantifyIon()
        ReadOnly ms1ppm As Tolerance
        ReadOnly dadot3 As Tolerance = Tolerance.DeltaMass(0.3)

        Public Sub New(ions As IEnumerable(Of QuantifyIon), peakwidth As DoubleRange, centroid As Tolerance)
            Call MyBase.New(peakwidth)

            Me.ms1ppm = centroid
            Me.ions = ions.ToArray
        End Sub

        Public Overrides Iterator Function GetSamplePeaks(sample As Raw) As IEnumerable(Of TargetPeakPoint)
            Dim ROI As ROI() = GetTICPeaks(sample.GetTIC).ToArray
            Dim rtmin As Vector = ROI.Select(Function(r) r.time.Min).ToArray
            Dim rtmax As Vector = ROI.Select(Function(r) r.time.Max).ToArray
            Dim ms As ms2()() = ROI.Select(Function(r) GetMsScan(sample, r.time)).ToArray

            For Each ion As QuantifyIon In ions
                Dim rtminScore As Vector = (ion.rt.Min / rtmin).Log(2).Abs
                Dim rtmaxScore As Vector = (ion.rt.Max / rtmax).Log(2).Abs
                Dim cos As Vector = ms _
                    .Select(Function(spectra)
                                With GlobalAlignment.TwoDirectionSSM(ion.ms, spectra, dadot3)
                                    Return stdNum.Min(.forward, .reverse)
                                End With
                            End Function) _
                    .ToArray
                Dim scores As Vector = (2 ^ rtminScore) + (2 ^ rtmaxScore) + cos
                Dim feature As ROI = ROI(Which.Max(scores))

                Yield GetPeak(ion.id, feature.time, sample)
            Next
        End Function

        Private Function GetMsScan(sample As Raw, rt As DoubleRange) As ms2()
            Dim ms_scan As ms1_scan() = sample.GetMsScan(rt)
            Dim spectra As ms2() = ms_scan _
                .Select(Function(scan)
                            Return New ms2 With {
                                .mz = scan.mz,
                                .quantity = scan.intensity,
                                .intensity = .quantity
                            }
                        End Function) _
                .ToArray _
                .Centroid(ms1ppm, LowAbundanceTrimming.Default) _
                .ToArray

            Return spectra
        End Function

        Private Function GetPeak(ion_id As String, rt As DoubleRange, sample As Raw) As TargetPeakPoint
            Dim sampleName As String = sample.fileName.BaseName
            Dim spectra As ms2() = GetMsScan(sample, rt)
            ' SIM模式下只使用响应度最高的碎片做定量计算
            Dim maxInto As Double = spectra.Select(Function(mz) mz.intensity).Max
            Dim tick As New ChromatogramTick With {.Intensity = maxInto, .Time = rt.Average}
            Dim q As New Quantile With {.Quantile = 1, .Percentage = 1}

            Return New TargetPeakPoint With {
                .Name = ion_id,
                .SampleName = sampleName,
                .Peak = New ROIPeak With {
                    .base = 0,
                    .peakHeight = maxInto,
                    .ticks = {tick},
                    .window = New DoubleRange(rt)
                },
                .ChromatogramSummary = {q}
            }
        End Function
    End Class
End Namespace