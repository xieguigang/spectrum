﻿#Region "Microsoft.VisualBasic::0e1f911df52e6eb3a2a3260432390c8e, Massbank\Public\MoNA\MoNAJson.vb"

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

' Class MoNAJson
' 
' 
' 
' /********************************************************************************/

#End Region

Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.MassSpectrum.Assembly.ASCII.MSP
Imports SMRUCC.MassSpectrum.DATA.File
Imports SMRUCC.MassSpectrum.DATA.MetaLib
Imports SMRUCC.MassSpectrum.Math.Spectra

''' <summary>
''' Reader for file ``MoNA-export-LC-MS-MS_Spectra.sdf``
''' </summary>
Public Module SDFReader

    Public Iterator Function ParseFile(path As String) As IEnumerable(Of SpectraSection)
        For Each mol As SDF In SDF.IterateParser(path, parseStruct:=False)
            Dim M As Func(Of String, String) = mol.readMeta
            Dim commentMeta = mol.MetaData!COMMENT.ToTable
            Dim ms2 As ms2() = mol.MetaData("MASS SPECTRAL PEAKS") _
                .Select(Function(line) line.Split) _
                .Select(Function(line)
                            Return New ms2 With {
                                .mz = line(0),
                                .intensity = line(1),
                                .quantity = line(1)
                            }
                        End Function) _
                .ToArray
            Dim info As Dictionary(Of String, String) = M.readSpectraInfo

            Yield New SpectraSection With {
                .name = M("NAME"),
                .ID = M("ID"),
                .Comment = commentMeta,
                .formula = M("FORMULA"),
                .mass = M("EXACT MASS"),
                .MassPeaks = ms2,
                .xref = commentMeta.readXref(M),
                .SpectraInfo = info
            }
        Next
    End Function

    <Extension>
    Private Function readSpectraInfo(M As Func(Of String, String)) As Dictionary(Of String, String)
        Dim info As New Dictionary(Of String, String)

        info!MsLevel = M("SPECTRUM TYPE")
        info!mz = M("PRECURSOR M/Z")
        info!instrument_type = M("INSTRUMENT TYPE")
        info!instrument = M("INSTRUMENT")
        info!collision_energy = M("COLLISION ENERGY")
        info!ion_mode = M("ION MODE")

        Return info
    End Function

    <Extension>
    Private Function readXref(commentMeta As NameValueCollection, M As Func(Of String, String)) As xref
        Dim xref As New xref

        xref.CAS = commentMeta.GetValues("cas")
        xref.chebi = commentMeta("chebi")
        xref.HMDB = commentMeta("hmdb")
        xref.InChI = commentMeta("InChI")
        xref.InChIkey = commentMeta("InChIKey") Or M("INCHIKEY").AsDefault
        xref.KEGG = commentMeta("KEGG")
        xref.pubchem = commentMeta("pubchem cid")
        xref.SMILES = commentMeta("SMILES")

        Return xref
    End Function

    <Extension>
    Private Function readMeta(mol As SDF) As Func(Of String, String)
        Dim meta As Dictionary(Of String, String()) = mol.MetaData _
            !COMMENT _
            .ToTable _
            .ToDictionary(allStrings:=True)

        For Each [property] In mol.MetaData
            If meta.ContainsKey([property].Key) Then
                meta([property].Key) = meta([property].Key).Join([property].Value).ToArray
            Else
                meta([property].Key) = [property].Value
            End If
        Next

        Return Function(key As String)
                   Return meta.TryGetValue(key, [default]:={}).FirstOrDefault
               End Function
    End Function
End Module