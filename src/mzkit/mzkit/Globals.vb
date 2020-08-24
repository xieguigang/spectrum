﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MIME.application.json
Imports Microsoft.VisualBasic.MIME.application.json.BSON
Imports Microsoft.VisualBasic.MIME.application.json.Javascript
Imports Task

Module Globals

    ReadOnly cacheList As String = App.LocalData & "/cacheList.dat"

    <Extension>
    Public Sub SaveRawFileCache(explorer As TreeView)
        Dim files As New List(Of Task.Raw)

        For Each node As TreeNode In explorer.Nodes
            files.Add(node.Tag)
        Next

        Dim obj As Dictionary(Of String, Raw) = files.ToDictionary(Function(raw) raw.source.FileName)
        Dim schema = obj.GetType
        Dim model As JsonElement = schema.GetJsonElement(obj, New JSONSerializerOptions)

        Using buffer = cacheList.Open(doClear:=True)
            Call DirectCast(model, JsonObject).WriteBuffer(buffer)
        End Using
    End Sub

    <Extension>
    Public Function LoadRawFileCache(explorer As TreeView) As Integer
        Dim rawBuffer As Byte() = cacheList.ReadBinary

        If rawBuffer.IsNullOrEmpty Then
            Return 0
        End If

        Dim files As Dictionary(Of String, Raw) = rawBuffer _
            .DoCall(AddressOf BSONFormat.Load) _
            .CreateObject(GetType(Dictionary(Of String, Raw)))
        Dim i As Integer

        For Each raw As Raw In files.SafeQuery.Values
            Call explorer.addRawFile(raw)
            i += 1
        Next

        Return i
    End Function

    <Extension>
    Public Sub addRawFile(explorer As TreeView, raw As Raw)
        Dim rawFileNode As New TreeNode($"{raw.source.FileName} [{raw.numOfScans} Scans]") With {
                .Checked = True,
                .Tag = raw
            }

        explorer.Nodes.Add(rawFileNode)
        rawFileNode.addRawFile(raw, True, True)
    End Sub

    <Extension>
    Public Sub addRawFile(rawFileNode As TreeNode, raw As Raw, ms1 As Boolean, ms2 As Boolean)
        For Each scan As ScanEntry In raw.scans
            If scan.mz = 0 AndAlso Not ms1 Then
                Continue For
            End If
            If scan.mz > 0 AndAlso Not ms2 Then
                Continue For
            End If

            Dim scanNode As New TreeNode(scan.id) With {
                .Tag = scan,
                .ToolTipText = "m/z: " & scan.mz
            }

            rawFileNode.Nodes.Add(scanNode)
        Next
    End Sub

    <Extension>
    Public Function CurrentRawFile(explorer As TreeView) As (raw As Raw, tree As TreeNode)
        Dim node = explorer.SelectedNode

        If node Is Nothing Then
            Return Nothing
        ElseIf TypeOf node.Tag Is Raw Then
            Return (DirectCast(node.Tag, Raw), node)
        Else
            Return (DirectCast(node.Parent.Tag, Raw), node.Parent)
        End If
    End Function
End Module