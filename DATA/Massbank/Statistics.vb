﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language.UnixBash
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.ComponentModel.DBLinkBuilder
Imports SMRUCC.proteomics.MS_Spectrum.DATA.TMIC.HMDB

Public Module Statistics

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cpd">KEGG compounds id list.</param>
    ''' <param name="br08901">The KEGG reference map data directory</param>
    ''' <returns></returns>
    <Extension>
    Public Function KEGGPathwayCoverages(cpd As IEnumerable(Of String), br08901$) As Dictionary(Of String, (cover%, ALL%))
        Dim coverages As New Dictionary(Of String, (cover%, ALL%))
        Dim list As Index(Of String) = cpd.Indexing
        Dim unknown% = 0

        For Each file As String In ls - l - r - "*.XML" <= br08901
            Dim refMap As PathwayMap = file.LoadXml(Of PathwayMap)

            If refMap.KEGGCompound.IsNullOrEmpty Then
                coverages(refMap.EntryId) = (0, 0)
            Else
                With refMap.KEGGCompound
                    coverages(refMap.EntryId) = (
                        .Where(Function(id) list(id.Key) > -1) _
                        .Count,
                        .Length)
                End With
            End If
        Next

        Return coverages
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="list">HMDB id list</param>
    ''' <param name="hmdb">The hmdb XML database file path.</param>
    ''' <returns></returns>
    <Extension>
    Public Function HMDBCoverages(list As IEnumerable(Of String), hmdb$, Optional ByRef unknwons% = -1) As Dictionary(Of String, (cover%, ALL%))
        Dim secondary2Main As New SecondaryIDSolver
        Dim metabolites As New Dictionary(Of String, metabolite)

        For Each m As metabolite In metabolite.Load(hmdb)
            With m
                Call secondary2Main.Add(
                    .accession,
                    .secondary_accessions.accession)
                Call metabolites.Add(.accession, m)
            End With
        Next

        ' All counts
        Dim id2Class As Dictionary(Of String, Integer) = metabolites _
            .Values _
            .Where(Function(m) Not m.taxonomy Is Nothing) _
            .Select(Function(id)
                        Return (id.accession, id.taxonomy.super_class)
                    End Function) _
            .GroupBy(Function(t) t.Item2) _
            .ToDictionary(Function(name) name.Key,
                          Function(ALL) ALL.Count)

        ' counts for inputs
        Dim counts As New Dictionary(Of String, Integer)
        Dim classKey$

        counts!unknown = 1

        For Each id As String In list
            id = secondary2Main(id)

            If id.StringEmpty Then
                counts!unknown += 1
                Continue For
            Else
                id = UCase(id)
                classKey = metabolites(id).taxonomy?.super_class
            End If

            If classKey.StringEmpty Then
                counts!unknown += 1
            Else
                If Not counts.ContainsKey(classKey) Then
                    Call counts.Add(classKey, 1)
                Else
                    counts(classKey) += 1
                End If
            End If
        Next

        Dim coverages As New Dictionary(Of String, (cover%, ALL%))

        For Each classKey In id2Class.Keys
            If counts.ContainsKey(classKey) Then
                coverages(classKey) = (counts(classKey), id2Class(classKey))
            Else
                coverages(classKey) = (0, id2Class(classKey))
            End If
        Next

        unknwons = counts!unknown

        Return coverages
    End Function
End Module
