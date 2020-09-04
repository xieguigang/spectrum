﻿Imports BioNovoGene.Analytical.MassSpectrometry.Math.Ms1
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Spectra
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports stdNum = System.Math

''' <summary>
''' 1. 按照母离子m/z二叉树聚类
''' 2. 每一个聚类结果作为一个node进行碎片合并
''' 3. 基于node进行molecular networking
''' 4. 导出网络数据
''' </summary>
Public Class Protocols

    ReadOnly ms1_tolerance As Tolerance
    ReadOnly ms2_tolerance As Tolerance

    ReadOnly treeIdentical As Double
    ReadOnly treeSimilar As Double
    ReadOnly intoCutoff As Double

    ReadOnly raw As New Dictionary(Of String, PeakMs2)
    ReadOnly clusters As New Dictionary(Of String, NetworkingNode)

    Default Public ReadOnly Property GetSpectrum(ref As String) As PeakMs2
        Get
            Return raw(ref)
        End Get
    End Property

    Public ReadOnly Property Cluster(ref As String) As NetworkingNode
        Get
            Return clusters(ref)
        End Get
    End Property

    Sub New(ms1_tolerance As Tolerance, ms2_tolerance As Tolerance, treeIdentical As Double, treeSimilar As Double, intoCutoff As Double)
        Me.treeIdentical = treeIdentical
        Me.treeSimilar = treeSimilar
        Me.intoCutoff = intoCutoff
        Me.ms1_tolerance = ms1_tolerance
        Me.ms2_tolerance = ms2_tolerance
    End Sub

    Public Function RunProtocol(raw As IEnumerable(Of PeakMs2), progress As Action(Of String)) As ProtocolPipeline
        Dim centroid As PeakMs2()

        Call progress("run data centroidlized...")

        centroid = centroidlized(raw)

        For Each ion In centroid
            Me.raw.Add(ion.lib_guid, ion)
        Next

        Return New ProtocolPipeline(Me, centroid, progress)
    End Function

    ''' <summary>
    ''' 步骤1
    ''' </summary>
    ''' <param name="raw"></param>
    ''' <returns></returns>
    Friend Iterator Function BinaryTree(raw As IEnumerable(Of PeakMs2)) As IEnumerable(Of SpectrumCluster)
        Dim tree As New SpectrumTreeCluster(SpectrumTreeCluster.SSMCompares(ms2_tolerance, treeIdentical, treeSimilar))

        Call tree.doCluster(raw.ToArray)

        For Each cluster In tree.PopulateClusters
            Yield cluster
        Next
    End Function

    ''' <summary>
    ''' 为了减少内存占用，在这里进行离散化
    ''' </summary>
    ''' <param name="raw"></param>
    ''' <returns></returns>
    Private Function centroid(raw As PeakMs2) As PeakMs2
        Return New PeakMs2 With {
            .activation = raw.activation,
            .file = raw.file,
            .collisionEnergy = raw.collisionEnergy,
            .lib_guid = raw.lib_guid,
            .meta = New Dictionary(Of String, String)(raw.meta),
            .mz = raw.mz,
            .mzInto = raw.mzInto.Centroid(ms2_tolerance, intoCutoff).ToArray,
            .precursor_type = raw.precursor_type,
            .rt = raw.rt,
            .scan = raw.scan
        }
    End Function

    Private Function centroidlized(raw As IEnumerable(Of PeakMs2)) As PeakMs2()
        Return raw _
            .AsParallel _
            .Select(AddressOf centroid) _
            .ToArray
    End Function

    Friend Iterator Function ProduceNodes(raw As IEnumerable(Of PeakMs2)) As IEnumerable(Of NetworkingNode)
        Dim groupByMz As NamedCollection(Of PeakMs2)() = raw _
            .GroupBy(Function(peak) peak.mz, ms1_tolerance) _
            .ToArray

        For Each mz As NamedCollection(Of PeakMs2) In groupByMz
            For Each cluster In BinaryTree(mz)
                Yield NetworkingNode.Create(Val(mz.name), cluster, ms2_tolerance)
            Next
        Next
    End Function

    Friend Iterator Function Networking(nodes As IEnumerable(Of NetworkingNode), progress As Action(Of String)) As IEnumerable(Of NamedValue(Of Dictionary(Of String, Double)))
        Dim i As i32 = 1
        Dim rawData As NetworkingNode() = nodes.ToArray

        For Each scan As NetworkingNode In rawData
            Dim scores = rawData _
                .Where(Function(a) Not a Is scan) _
                .AsParallel _
                .Select(Function(a)
                            Dim id As String = a.referenceId
                            Dim score = GlobalAlignment.TwoDirectionSSM(scan.representation.ms2, a.representation.ms2, ms2_tolerance)

                            Return (id, stdNum.Min(score.forward, score.reverse))
                        End Function) _
                .ToArray

            Call progress($"[{++i}/{rawData.Length}] {scan.ToString} has {scores.Where(Function(a) a.Item2 >= 0.8).Count} homologous spectrum")
            Call clusters.Add(scan.referenceId, scan)

            Yield New NamedValue(Of Dictionary(Of String, Double)) With {
                .Name = scan.referenceId,
                .Value = scores.ToDictionary(Function(a) a.id, Function(a) a.Item2)
            }
        Next
    End Function
End Class

