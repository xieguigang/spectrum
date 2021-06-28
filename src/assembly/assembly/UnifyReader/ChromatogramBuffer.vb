﻿#Region "Microsoft.VisualBasic::7467c8e5527b5c8e58406dc2919cf777, src\assembly\assembly\UnifyReader\ChromatogramBuffer.vb"

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

    '     Module ChromatogramBuffer
    ' 
    '         Function: FromBuffer, GetBytes, (+2 Overloads) MeasureSize
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.IO

Namespace DataReader

    Public Module ChromatogramBuffer

        ''' <summary>
        ''' get data buffer of a <see cref="Chromatogram"/> data object.
        ''' </summary>
        ''' <param name="chr"></param>
        ''' <returns></returns>
        <Extension>
        Public Function GetBytes(chr As Chromatogram) As Byte()
            Using buffer As New MemoryStream, bin As New BinaryDataWriter(buffer) With {
                .ByteOrder = ByteOrder.BigEndian
            }
                Call bin.Write(chr.length)
                Call bin.Write(chr.scan_time)
                Call bin.Write(chr.TIC)
                Call bin.Write(chr.BPC)
                Call bin.Flush()

                Return buffer.ToArray
            End Using
        End Function

        Public Function FromBuffer(buffer As Stream) As Chromatogram
            Using bin As New BinaryDataReader(buffer) With {.ByteOrder = ByteOrder.BigEndian}
                Dim n As Integer = bin.ReadInt32
                Dim scan_time As Double() = bin.ReadDoubles(n)
                Dim TiC As Double() = bin.ReadDoubles(n)
                Dim BpC As Double() = bin.ReadDoubles(n)

                Return New Chromatogram With {
                    .scan_time = scan_time,
                    .BPC = BpC,
                    .TIC = TiC
                }
            End Using
        End Function

        Public Function MeasureSize(len As Integer) As Long
            ' scan_time double
            ' TIC double
            ' BPC double
            ' count integer
            Dim size As Long = len * 8 * 3 + 4
            Return size
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function MeasureSize(chr As Chromatogram) As Long
            Return MeasureSize(chr.length)
        End Function

    End Module
End Namespace
