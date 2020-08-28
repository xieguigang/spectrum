﻿#Region "Microsoft.VisualBasic::4ef6afc89710a6b57c3edfe242277045, src\metadb\Chemoinformatics\Formula\SearchOption.vb"

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

    '     Class SearchOption
    ' 
    '         Properties: candidateElements, chargeRange, ppm
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: AddElement, AdjustPpm, DefaultMetaboliteProfile, GeneralFlavone, NaturalProduct
    '                   SmallMolecule, ToString
    ' 
    '     Enum DNPOrWileyType
    ' 
    '         DNP, Wiley
    ' 
    '  
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Formula

    Public Class SearchOption

        Public ReadOnly Property candidateElements As List(Of ElementSearchCandiate)
        Public ReadOnly Property ppm As Double
        Public ReadOnly Property chargeRange As IntRange

        Sub New(minCharge As Integer, maxCharge As Integer, Optional ppm As Double = 30)
            Me.candidateElements = New List(Of ElementSearchCandiate)
            Me.ppm = ppm
            Me.chargeRange = New IntRange(minCharge, maxCharge)
        End Sub

        Public Function AddElement(element As String, min As Integer, max As Integer) As SearchOption
            Call New ElementSearchCandiate With {
                .Element = element,
                .MaxCount = max,
                .MinCount = min
            }.DoCall(AddressOf candidateElements.Add)

            Return Me
        End Function

        Public Function AdjustPpm(ppm As Double) As SearchOption
            _ppm = ppm
            Return Me
        End Function

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function

        Public Shared Function DefaultMetaboliteProfile() As SearchOption
            Return New SearchOption(-999999999, 999999999, ppm:=1) _
                .AddElement("C", 1, 30) _
                .AddElement("H", 0, 300) _
                .AddElement("N", 0, 30) _
                .AddElement("O", 0, 30) _
                .AddElement("P", 0, 30) _
                .AddElement("S", 0, 30)
        End Function

        Public Shared Function NaturalProduct(type As DNPOrWileyType, common As Boolean) As SearchOption
            If type = DNPOrWileyType.DNP Then
                Dim opts As New SearchOption(-999999999, 999999999, ppm:=1)
                opts.AddElement("C", 0, 66) _
                    .AddElement("H", 0, 126) _
                    .AddElement("N", 0, 25) _
                    .AddElement("O", 0, 27) _
                    .AddElement("P", 0, 6) _
                    .AddElement("S", 0, 8)

                If Not common Then
                    Return opts.AddElement("F", 0, 16) _
                        .AddElement("Cl", 0, 11) _
                        .AddElement("Br", 0, 8) _
                        .AddElement("Si", 0, 0)
                End If

                Return opts
            Else
                Dim opts As New SearchOption(-999999999, 999999999, ppm:=1)
                opts.AddElement("C", 0, 78) _
                    .AddElement("H", 0, 126) _
                    .AddElement("N", 0, 20) _
                    .AddElement("O", 0, 27) _
                    .AddElement("P", 0, 9) _
                    .AddElement("S", 0, 14)

                If Not common Then
                    Return opts.AddElement("F", 0, 34) _
                    .AddElement("Cl", 0, 12) _
                    .AddElement("Br", 0, 8) _
                    .AddElement("Si", 0, 14)
                End If

                Return opts
            End If
        End Function

        Public Shared Function GeneralFlavone() As SearchOption
            Return New SearchOption(-999999, 999999, ppm:=1).AddElement("C", 9, 50).AddElement("H", 4, 100).AddElement("O", 1, 30)
        End Function

        Public Shared Function SmallMolecule(type As DNPOrWileyType, common As Boolean) As SearchOption
            If type = DNPOrWileyType.DNP Then
                Dim opts As New SearchOption(-999999999, 999999999, ppm:=1)
                opts.AddElement("C", 0, 29) _
                    .AddElement("H", 0, 72) _
                    .AddElement("N", 0, 10) _
                    .AddElement("O", 0, 18) _
                    .AddElement("P", 0, 4) _
                    .AddElement("S", 0, 7)

                If Not common Then
                    Return opts _
                    .AddElement("F", 0, 15) _
                    .AddElement("Cl", 0, 8) _
                    .AddElement("Br", 0, 5) _
                    .AddElement("Si", 0, 0)
                End If

                Return opts
            Else
                Dim opts As New SearchOption(-999999999, 999999999, ppm:=1)
                opts.AddElement("C", 0, 39) _
                    .AddElement("H", 0, 72) _
                    .AddElement("N", 0, 20) _
                    .AddElement("O", 0, 20) _
                    .AddElement("P", 0, 9) _
                    .AddElement("S", 0, 10)

                If Not common Then
                    Return opts _
                    .AddElement("F", 0, 16) _
                    .AddElement("Cl", 0, 10) _
                    .AddElement("Br", 0, 4) _
                    .AddElement("Si", 0, 8)
                End If

                Return opts
            End If
        End Function
    End Class

    Public Enum DNPOrWileyType
        DNP
        Wiley
    End Enum
End Namespace