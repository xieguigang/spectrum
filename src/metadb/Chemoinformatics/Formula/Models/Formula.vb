﻿#Region "Microsoft.VisualBasic::3aa972a9fd5c07d5400d076498557985, src\metadb\Chemoinformatics\Formula\Formula.vb"

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

'     Class Formula
' 
'         Properties: CountsByElement, Elements, EmpiricalFormula
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: BuildFormula, ToString
'         Operators: *
' 
'     Class FormulaComposition
' 
'         Properties: charge, exact_mass, ppm
' 
'         Constructor: (+1 Overloads) Sub New
'         Function: AppendElement, GetCopy
' 
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace Formula

    Public Class Formula

        Public ReadOnly Property CountsByElement As Dictionary(Of String, Integer)
        Public ReadOnly Property EmpiricalFormula As String
            Get
                Return m_formula
            End Get
        End Property

        Friend m_formula As String

        Public Shared ReadOnly Property Elements As IReadOnlyDictionary(Of String, Element) = Element.MemoryLoadElements

        Default Public ReadOnly Property GetAtomCount(atom As String) As Integer
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return CountsByElement.TryGetValue(atom)
            End Get
        End Property

        Public ReadOnly Property ExactMass As Double
            Get
                Return Aggregate element
                       In CountsByElement
                       Let mass As Double = Elements(element.Key).isotopic * element.Value
                       Into Sum(mass)
            End Get
        End Property

        Sub New(counts As IDictionary(Of String, Integer), Optional formula$ = Nothing)
            CountsByElement = New Dictionary(Of String, Integer)(counts)

            If formula.StringEmpty Then
                Me.m_formula = BuildFormula(CountsByElement)
            Else
                Me.m_formula = formula
            End If
        End Sub

        Public Shared Function BuildFormula(countsByElement As Dictionary(Of String, Integer)) As String
            Return countsByElement _
                .Where(Function(e) e.Value > 0) _
                .Select(Function(e)
                            Return If(e.Value = 1, e.Key, e.Key & e.Value)
                        End Function) _
                .JoinBy("")
        End Function

        Public Function DebugView() As String
            Return $"{EmpiricalFormula} ({ExactMass} = {CountsByElement.GetJson})"
        End Function

        Public Overrides Function ToString() As String
            Return EmpiricalFormula
        End Function

        Public Shared Operator *(composition As Formula, n%) As Formula
            Dim newFormula$ = $"({composition}){n}"
            Dim newComposition = composition _
                .CountsByElement _
                .ToDictionary(Function(e) e.Key,
                              Function(e)
                                  Return e.Value * n
                              End Function)

            Return New Formula(newComposition, newFormula)
        End Operator
    End Class
End Namespace