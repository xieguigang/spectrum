﻿#Region "Microsoft.VisualBasic::f55451396e72e4874ab81c2c810db5b2, pages\dockWindow\documents\frmFeatureSearch.vb"

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

    ' Class frmFeatureSearch
    ' 
    '     Sub: (+2 Overloads) AddFileMatch, frmFeatureSearch_Load, ViewToolStripMenuItem_Click
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Windows.Forms.ListViewItem
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Ms1
Imports Microsoft.VisualBasic.Language
Imports mzkit.My
Imports RibbonLib.Interop
Imports Task

Public Class frmFeatureSearch

    Public Sub AddFileMatch(file As String, matches As ParentMatch())
        Dim matchHeaders = {
            New ColumnHeader() With {.Text = "Precursor Type"},
            New ColumnHeader() With {.Text = "Adducts"},
            New ColumnHeader() With {.Text = "M"}
        }
        Me.TreeListView1.Columns.AddRange(matchHeaders)

        Dim row As New TreeListViewItem With {.Text = file.FileName, .ImageIndex = 0, .ToolTipText = file}
        Dim i As i32 = 1

        For Each member As ParentMatch In matches
            Dim ion As New TreeListViewItem(member.id) With {.ImageIndex = 1, .ToolTipText = member.id}

            ion.SubItems.Add(New ListViewSubItem With {.Text = $"#{++i}"})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.mz})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.rt})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.ppm})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.polarity})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.charge})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.BPC})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.TIC})

            ion.SubItems.Add(New ListViewSubItem With {.Text = member.precursor_type})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.adducts})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.M})

            row.Items.Add(ion)
        Next

        row.SubItems.Add(New ListViewSubItem With {.Text = matches.Length})

        TreeListView1.Items.Add(row)
    End Sub

    Public Sub AddFileMatch(file As String, targetMz As Double, matches As ScanEntry())
        Dim row As New TreeListViewItem With {.Text = file.FileName, .ImageIndex = 0, .ToolTipText = file}
        Dim i As i32 = 1

        For Each member As ScanEntry In matches
            Dim ion As New TreeListViewItem(member.id) With {.ImageIndex = 1, .ToolTipText = member.id}

            ion.SubItems.Add(New ListViewSubItem With {.Text = $"#{++i}"})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.mz})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.rt})
            ion.SubItems.Add(New ListViewSubItem With {.Text = PPMmethod.PPM(member.mz, targetMz).ToString("F2")})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.polarity})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.charge})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.BPC})
            ion.SubItems.Add(New ListViewSubItem With {.Text = member.TIC})

            row.Items.Add(ion)
        Next

        row.SubItems.Add(New ListViewSubItem With {.Text = matches.Length})

        TreeListView1.Items.Add(row)
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim cluster As TreeListViewItem
        Dim host = MyApplication.host

        If TreeListView1.SelectedItems.Count = 0 Then
            Return
        Else
            cluster = TreeListView1.SelectedItems(0)
        End If

        ' 当没有feature搜索结果的时候， children count也是零
        ' 但是raw文件的parent是空的
        ' 所以还需要加上parent是否为空的判断来避免无结果产生的冲突
        If cluster.ChildrenCount > 0 OrElse cluster.Parent Is Nothing Then
            ' 选择的是一个文件节点
            Dim filePath As String = cluster.ToolTipText
            Dim raw As Raw = Globals.workspace.FindRawFile(filePath)

            If Not raw Is Nothing Then
                Call MyApplication.mzkitRawViewer.showScatter(raw)
            End If
        Else
            ' 选择的是一个scan数据节点
            Dim parentFile = cluster.Parent.ToolTipText
            Dim scan_id As String = cluster.Text

            MyApplication.host.ribbonItems.TabGroupTableTools.ContextAvailable = ContextAvailability.Active

            ' scan节点
            Dim raw As Task.Raw = Globals.workspace.FindRawFile(parentFile)

            Call MyApplication.host.mzkitTool.showSpectrum(scan_id, raw)
            Call MyApplication.host.mzkitTool.ShowPage()
        End If
    End Sub

    Private Sub frmFeatureSearch_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "Feature Search Result"
        TabText = Text
    End Sub
End Class
