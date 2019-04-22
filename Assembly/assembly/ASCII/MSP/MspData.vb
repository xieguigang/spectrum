﻿#Region "Microsoft.VisualBasic::37033628de9b24f3919aade8c0156493, ASCII\MSP\MspData.vb"

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

'     Class MspData
' 
'         Properties: Collision_energy, Comments, DB_id, Formula, InChIKey
'                     Instrument, Instrument_type, Ion_mode, MetaDB, MetaReader
'                     MW, Name, Peaks, Precursor_type, PrecursorMZ
'                     Spectrum_type, Synonyms
' 
'         Function: Load, ToString
' 
' 
' /********************************************************************************/

#End Region

Imports System.Collections.Specialized
Imports System.Data.Linq.Mapping
Imports System.Runtime.CompilerServices

Namespace ASCII.MSP

    Public Class MspData

        Public Property Name As String
        Public Property Synonyms As String()

        ''' <summary>
        ''' ``DB#``
        ''' </summary>
        ''' <returns></returns>
        <Column(Name:="DB#")>
        Public Property DB_id As String
        Public Property InChIKey As String
        Public Property MW As Double
        Public Property Formula As String
        Public Property PrecursorMZ As String
        Public Property Precursor_type As String
        Public Property Comments As NameValueCollection
        Public Property Spectrum_type As String
        Public Property Instrument_type As String
        Public Property Instrument As String
        Public Property Ion_mode As String
        Public Property Collision_energy As String

        Public Property Peaks As MSMSPeak()

        Public Overrides Function ToString() As String
            Return Name
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Function Load(path$, Optional ms2 As Boolean = True) As IEnumerable(Of MspData)
            Return MspParser.Load(path, ms2)
        End Function
    End Class
End Namespace
