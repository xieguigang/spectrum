﻿#Region "Microsoft.VisualBasic::6ce0adaee953267edee55107fe5bdc5a, src\mzmath\ms2_math-core\Spectra\Models\Fragments.vb"

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

    '     Class Library
    ' 
    '         Properties: ID, LibraryIntensity, Name, PrecursorMz, ProductMz
    ' 
    '         Function: ToString
    ' 
    '     Class SpectraMatrix
    ' 
    '         Properties: length, matrix, title
    ' 
    '         Function: GenericEnumerator, GetEnumerator, LibraryMatrix
    ' 
    '     Class ms2
    ' 
    '         Properties: Annotation, intensity, mz, quantity
    ' 
    '         Function: ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports System.Web.Script.Serialization
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Microsoft.VisualBasic.Linq

Namespace Spectra

    ''' <summary>
    ''' MS2 fragment matrix
    ''' </summary>
    Public Class Library

        ''' <summary>
        ''' Fragment ID in this matrix.
        ''' </summary>
        ''' <returns></returns>
        Public Property ID As String
        ''' <summary>
        ''' 前体离子的m/z
        ''' </summary>
        ''' <returns></returns>
        Public Property PrecursorMz As Double
        ''' <summary>
        ''' 碎片的m/z
        ''' </summary>
        ''' <returns></returns>
        Public Property ProductMz As Double
        ''' <summary>
        ''' 当前的这个碎片的信号强度
        ''' </summary>
        ''' <returns></returns>
        Public Property LibraryIntensity As Double
        ''' <summary>
        ''' library name
        ''' </summary>
        ''' <returns></returns>
        Public Property Name As String

        Public Overrides Function ToString() As String
            Return $"[{ProductMz}, {LibraryIntensity}]"
        End Function

    End Class

    ''' <summary>
    ''' The Xml data model of <see cref="Spectra.LibraryMatrix"/>
    ''' </summary>
    Public Class SpectraMatrix : Implements Enumeration(Of ms2)
        Implements INamedValue

        <XmlAttribute>
        Public Property title As String Implements IKeyedEntity(Of String).Key

        <XmlElement>
        Public Property matrix As ms2()

        ''' <summary>
        ''' 这个质谱图内的二级碎片的数量
        ''' </summary>
        ''' <returns></returns>
        <ScriptIgnore>
        <XmlIgnore>
        Public ReadOnly Property length As Integer
            Get
                Return matrix.Length
            End Get
        End Property

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function LibraryMatrix() As LibraryMatrix
            Return New LibraryMatrix With {
                .Name = title,
                .ms2 = matrix
            }
        End Function

        Public Iterator Function GenericEnumerator() As IEnumerator(Of ms2) Implements Enumeration(Of ms2).GenericEnumerator
            For Each fragment As ms2 In matrix.SafeQuery
                Yield fragment
            Next
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator Implements Enumeration(Of ms2).GetEnumerator
            Yield GenericEnumerator()
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Widening Operator CType([lib] As LibraryMatrix) As SpectraMatrix
            Return New SpectraMatrix With {.title = [lib].Name, .matrix = [lib].ms2}
        End Operator
    End Class

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
    End Class
End Namespace