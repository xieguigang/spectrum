﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps

Namespace Spectra

    ''' <summary>
    ''' A spectra fragment with m/z and into data.
    ''' </summary>
    Public Class ms2

        ''' <summary>
        ''' Molecular fragment m/z
        ''' </summary>
        ''' <returns></returns>
        <DataFrameColumn(NameOf(mz))>
        <XmlAttribute> Public Property mz As Double
        ''' <summary>
        ''' quantity
        ''' </summary>
        ''' <returns></returns>
        <DataFrameColumn(NameOf(quantity))>
        <XmlAttribute> Public Property quantity As Double
        ''' <summary>
        ''' Relative intensity.(percentage) 
        ''' </summary>
        ''' <returns></returns>
        <DataFrameColumn(NameOf(intensity))>
        <XmlAttribute> Public Property intensity As Double

        ''' <summary>
        ''' Peak annotation data or something else
        ''' </summary>
        ''' <returns></returns>
        <XmlText>
        Public Property Annotation As String

        Public Overrides Function ToString() As String
            If intensity <= 1 Then
                Return $"{mz} ({Fix(intensity * 100%)}%)"
            Else
                Return $"{mz} ({Fix(intensity)}%)"
            End If
        End Function

        ''' <summary>
        ''' 以质谱峰中最强峰作为100％，称为基峰（该离子的丰度最大、最稳定），然后用各种峰的离子流强度除以基峰的离子流强度，所得的百分数就是相对强度。 
        ''' </summary>
        ''' <param name="matrix"></param>
        ''' <returns></returns>
        Public Shared Function RelativeIntensity(matrix As ms2()) As ms2()
            Dim basePeak As Double = matrix.Select(Function(mz) mz.intensity).Max
            Dim norm As ms2() = matrix _
                .Select(Function(mz)
                            Return New ms2 With {
                                .mz = mz.mz,
                                .Annotation = mz.Annotation,
                                .intensity = mz.intensity,
                                .quantity = mz.intensity / basePeak
                            }
                        End Function) _
                .ToArray

            Return norm
        End Function

        ''' <summary>
        ''' 绝对强度是将所有离子峰的离子流强度相加作为总离子流，用各离子峰的离子强度除以总离子流，得出各离子流占总离子流的百分数(总离子流是100％)。 
        ''' </summary>
        ''' <param name="matrix"></param>
        ''' <returns></returns>
        Public Shared Function AbsoluteIntensity(matrix As ms2()) As ms2()
            Dim totalIon As Double = matrix.Select(Function(mz) mz.intensity).Sum
            Dim norm As ms2() = matrix _
                .Select(Function(mz)
                            Return New ms2 With {
                                .mz = mz.mz,
                                .Annotation = mz.Annotation,
                                .intensity = mz.intensity,
                                .quantity = mz.intensity / totalIon
                            }
                        End Function) _
                .ToArray

            Return norm
        End Function
    End Class
End Namespace