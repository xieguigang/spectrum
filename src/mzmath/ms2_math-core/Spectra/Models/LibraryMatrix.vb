﻿#Region "Microsoft.VisualBasic::ab3fb7fec56ad41389969a851c685030, src\mzmath\ms2_math-core\Spectra\Models\LibraryMatrix.vb"

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

    '     Class LibraryMatrix
    ' 
    '         Properties: intensity, ms2, Name
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: AlignMatrix, GetMaxInto
    '         Operators: *, /
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Ms1
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.Math.Scripting
Imports WhichSelector = Microsoft.VisualBasic.Linq.Which

Namespace Spectra

    ''' <summary>
    ''' The <see cref="ms2"/> library matrix object model
    ''' </summary>
    Public Class LibraryMatrix : Inherits IVector(Of ms2)
        Implements INamedValue

        ''' <summary>
        ''' The list of molecular fragment
        ''' </summary>
        ''' <returns></returns>
        Public Property ms2 As ms2()
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return buffer
            End Get
            Set(value As ms2())
                Call writeBuffer(value)
            End Set
        End Property

        Public Property Name As String Implements IKeyedEntity(Of String).Key

        Default Public Overloads ReadOnly Property Item(booleans As IEnumerable(Of Boolean)) As LibraryMatrix
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return New LibraryMatrix() With {
                    .ms2 = MyBase _
                        .Item(booleans) _
                        .ToArray,
                    .Name = Name
                }
            End Get
        End Property

        Public ReadOnly Property intensity As Vector
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return Me!intensity
            End Get
        End Property

        Sub New()
            Call MyBase.New({})
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetMaxInto() As ms2
            Return buffer(WhichSelector.Max(buffer.Select(Function(mz) mz.intensity)))
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function AlignMatrix(data As ms2(), tolerance As Tolerance) As ms2()
            Return ms2.AlignMatrix(data, tolerance)
        End Function

        ''' <summary>
        ''' ``<see cref="ms2.intensity"/> = <see cref="ms2.quantity"/> / x``
        ''' </summary>
        ''' <param name="matrix"></param>
        ''' <param name="x#"></param>
        ''' <returns></returns>
        Public Shared Operator /(matrix As LibraryMatrix, x#) As LibraryMatrix
            For Each ms2 As ms2 In matrix.ms2
                ms2.intensity = ms2.quantity / x
            Next

            Return matrix
        End Operator

        ''' <summary>
        ''' ``<see cref="ms2.intensity"/> *= x``
        ''' </summary>
        ''' <param name="matrix"></param>
        ''' <param name="x#"></param>
        ''' <returns></returns>
        Public Shared Operator *(matrix As LibraryMatrix, x#) As LibraryMatrix
            For Each ms2 As ms2 In matrix.ms2
                ms2.intensity *= x
            Next

            Return matrix
        End Operator

        ''' <summary>
        ''' Convert the ms2 data collection to <see cref="LibraryMatrix"/>
        ''' </summary>
        ''' <param name="ms2"></param>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Widening Operator CType(ms2 As ms2()) As LibraryMatrix
            Return New LibraryMatrix With {
                .ms2 = ms2
            }
        End Operator

        ''' <summary>
        ''' Convert the ms2 data collection to <see cref="LibraryMatrix"/>
        ''' </summary>
        ''' <param name="ms2"></param>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Widening Operator CType(ms2 As List(Of ms2)) As LibraryMatrix
            Return New LibraryMatrix With {
                .ms2 = ms2.ToArray
            }
        End Operator

        ''' <summary>
        ''' 将一个整形数列表转换为mz向量，这个转换函数为调试用的
        ''' </summary>
        ''' <param name="mzlist"></param>
        ''' <returns></returns>
        Public Shared Widening Operator CType(mzlist As Integer()) As LibraryMatrix
            Return New LibraryMatrix With {
                .ms2 = mzlist _
                    .Select(Function(mz)
                                Return New ms2 With {
                                    .mz = mz,
                                    .intensity = 1,
                                    .quantity = 1
                                }
                            End Function) _
                    .ToArray
            }
        End Operator

        ''' <summary>
        ''' Library matrix to ``&lt;m/z, intensity>`` tuples.
        ''' </summary>
        ''' <param name="matrix"></param>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overloads Shared Narrowing Operator CType(matrix As LibraryMatrix) As (mz#, into#)()
            Return matrix.ms2 _
                .Select(Function(r) (r.mz, r.intensity)) _
                .ToArray
        End Operator
    End Class
End Namespace