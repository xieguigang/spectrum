﻿#Region "Microsoft.VisualBasic::f78dc4289a8df7131776712a9ff85fb7, src\mzmath\ms2_math-core\Spectra\Models\ms2.vb"

    ' Author:
    ' 
    '       xieguigang (gg.xie@bionovogene.com, BioNovoGene Co., LTD.)
    ' 
    ' Copyright (c) 2018 gg.xie@bionovogene.com, BioNovoGene Co., LTD.
    ' 
    ' 
    ' MIT License
    ' 
    ' 
    ' Permission is hereby granted, free of charge, to any person obtaining a copy
    ' of this software and associated documentation files (the "Software"), to deal
    ' in the Software without restriction, including without limitation the rights
    ' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    ' copies of the Software, and to permit persons to whom the Software is
    ' furnished to do so, subject to the following conditions:
    ' 
    ' The above copyright notice and this permission notice shall be included in all
    ' copies or substantial portions of the Software.
    ' 
    ' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    ' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    ' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    ' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    ' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    ' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    ' SOFTWARE.



    ' /********************************************************************************/

    ' Summaries:

    '     Class ms2
    ' 
    '         Properties: Annotation, intensity, mz
    ' 
    '         Function: AbsoluteIntensity, RelativeIntensity, ToString
    '         Operators: -
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps

Namespace Spectra

    ''' <summary>
    ''' A spectra fragment with m/z and into data.
    ''' </summary>
    ''' <remarks>
    ''' [mz, into, annotation]
    ''' </remarks>
    Public Class ms2 : Implements IMzAnnotation

        ''' <summary>
        ''' Molecular fragment m/z
        ''' </summary>
        ''' <returns></returns>
        <DataFrameColumn(NameOf(mz))>
        <XmlAttribute> Public Property mz As Double Implements IMzAnnotation.mz
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
        Public Property Annotation As String Implements IMzAnnotation.annotation

        Public Overrides Function ToString() As String
            Dim mzinto As String

            If intensity <= 1 Then
                mzinto = $"{mz} ({Fix(intensity * 100%)}%)"
            Else
                mzinto = $"{mz} ({intensity.ToString("G3")})"
            End If

            Return mzinto & If(Annotation.StringEmpty, "", $" {Annotation}")
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator -(x As ms2, y As ms2) As Double
            Return x.mz - y.mz
        End Operator

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
                                .intensity = mz.intensity / basePeak
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
                                .intensity = mz.intensity / totalIon
                            }
                        End Function) _
                .ToArray

            Return norm
        End Function
    End Class
End Namespace
