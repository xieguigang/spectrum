﻿#Region "Microsoft.VisualBasic::0b6b159a64e51269d3033f70f2838677, ms2_math-core\Ms2\GlobalAlignment.vb"

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

    ' Module GlobalAlignment
    ' 
    '     Function: Align, AlignMatrix, SharedPeakCount, TwoDirectionSSM
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Math.Extensions
Imports Microsoft.VisualBasic.Math.LinearAlgebra

Namespace Spectra

    ''' <summary>
    ''' Global alignment of two MS/MS matrix.
    ''' </summary>
    Public Module GlobalAlignment

        '''' <summary>
        '''' ### shared peak count
        '''' 
        '''' In the matrix ``M``, ``i`` and ``j`` are positions, where ``i`` is the
        '''' horizontal coordinate And ``j`` Is the vertical coordinate. For Each
        '''' cell in the matrix, a score Is calculated (Si,j). If the two compared
        '''' masses are a match, Then ``C`` the cost Is equal To 0. However, If
        '''' the two masses are outside the designated ppm Error window,
        '''' then the cost Is equal to 1.
        '''' </summary>
        '''' <param name="query"></param>
        '''' <param name="subject"></param>
        '''' <returns></returns>
        'Public Function NWGlobalAlign(query As LibraryMatrix, subject As LibraryMatrix, Optional tolerance As Tolerance = Nothing) As GlobalAlign(Of ms2)()
        '    Dim massEquals As IEquals(Of ms2)
        '    Dim empty As New ms2 With {
        '        .mz = -1,
        '        .intensity = -1,
        '        .quantity = -1
        '    }

        '    With tolerance Or da3
        '        massEquals = Function(q, s)
        '                         Return .Assert(q.mz, s.mz)
        '                     End Function
        '    End With

        '    With New NeedlemanWunsch(Of ms2)(query, subject, massEquals, empty, Function(ms2) ms2.ToString.First).Compute()
        '        Return .PopulateAlignments.ToArray
        '    End With
        'End Function

        Public Function SharedPeakCount(query As LibraryMatrix, subject As LibraryMatrix, Optional tolerance As Tolerance = Nothing, Optional top% = 10) As Integer
            Dim q = query.OrderByDescending(Function(mz) mz.quantity).Take(top).ToArray
            Dim s = subject.OrderByDescending(Function(mz) mz.quantity).Take(top).ToArray

            With tolerance Or Tolerance.DefaultTolerance
                Dim share = s.Where(Function(mz)
                                        Dim find = q.Where(Function(frag)
                                                               Return .Assert(frag.mz, mz.mz)
                                                           End Function) _
                                                .FirstOrDefault
                                        Return Not find Is Nothing
                                    End Function) _
                             .Count
                Return share
            End With
        End Function

        ''' <summary>
        ''' xy分别为预测或者标准品的结果数据，无顺序之分
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function TwoDirectionSSM(x As ms2(), y As ms2(), method As Tolerance) As (forward#, reverse#)
            Return (GlobalAlignment.Align(x, y, method), GlobalAlignment.Align(y, x, method))
        End Function

        ReadOnly ppm20 As DefaultValue(Of Tolerance) = New PPMmethod(20).Interface

        ''' <summary>
        ''' 以<paramref name="ref"/>为基准，从<paramref name="query"/>之中选择出对应的<see cref="ms2.mz"/>信号响应信息，完成对齐操作
        ''' </summary>
        ''' <param name="query"></param>
        ''' <param name="ref"></param>
        ''' <returns></returns>
        Public Function Align(query As ms2(), ref As ms2(), Optional method As Tolerance = Nothing) As Double
            Dim q As Vector = query.AlignMatrix(ref, method Or ppm20).Shadows!intensity
            Dim s As Vector = ref.Shadows!intensity

            Return SSM(q / q.Max, s / s.Max)
        End Function

        ''' <summary>
        ''' 在ref之中找不到对应的mz，则into为零
        ''' </summary>
        ''' <param name="query"></param>
        ''' <param name="ref"></param>
        ''' <param name="method"></param>
        ''' <returns></returns>
        <Extension>
        Public Function AlignMatrix(query As ms2(), ref As ms2(), method As Tolerance) As ms2()
            Return ref _
                .Select(Function(mz)

                            ' 2017-10-29
                            '
                            ' 当找不到的时候，会返回一个空的structure对象，这个时候intensity为零
                            ' 所以在这个Linq表达式中，后面不需要使用Where来删除对象了

                            Dim subject = query _
                                .Where(Function(q) method.Assert(q.mz, mz.mz)) _
                                .Shadows

                            If subject.Length = 0 Then
                                ' With single intensity ZERO
                                Return New ms2 With {
                                    .mz = mz.mz
                                }
                            Else
                                ' 返回响应值最大的
                                Return subject(Which.Max(subject!intensity))
                            End If
                        End Function) _
                .ToArray
        End Function
    End Module
End Namespace