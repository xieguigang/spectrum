﻿#Region "Microsoft.VisualBasic::d78644e03331f50917498380710fd4fd, src\mzkit\mzkit\pages\dockWindow\base\DocumentWindow.vb"

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

    ' Class DocumentWindow
    ' 
    '     Sub: ApplyVsTheme, CloseAllButThisToolStripMenuItem_Click, CloseAllDocumentsToolStripMenuItem_Click, CloseToolStripMenuItem_Click, CopyFullPath
    '          FloatToolStripMenuItem_Click, HandleTaskbar, OpenContainingFolder, SaveDocument, ToolWindow_Load
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.Windows.Taskbar
Imports mzkit.My
Imports WeifenLuo.WinFormsUI.Docking

Public Class DocumentWindow

    Friend WithEvents VS2015LightTheme1 As New VS2015LightTheme
    Friend WithEvents VisualStudioToolStripExtender1 As VisualStudioToolStripExtender

    Public Event CloseDocument()

    Protected Sub ApplyVsTheme(ParamArray items As ToolStrip())
        For Each item In items
            Call VisualStudioToolStripExtender1.SetStyle(item, VisualStudioToolStripExtender.VsVersion.Vs2015, VS2015LightTheme1)
        Next
    End Sub

    Friend preview As TabbedThumbnail

    Private Sub ToolWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        TabPageContextMenuStrip = DockContextMenuStrip1

        AutoScaleMode = AutoScaleMode.Dpi
        DoubleBuffered = True
        VisualStudioToolStripExtender1 = New VisualStudioToolStripExtender(components)

        Call ApplyVsTheme(DockContextMenuStrip1)
        ' Call HandleTaskbar()
    End Sub

    Private Sub HandleTaskbar()
        ' Add a new preview
        preview = New TabbedThumbnail(ParentForm.Handle, Me.Handle) With {
            .ClippingRectangle = New Rectangle(New Point, Size)
        }

        TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(preview)

        ' Event handlers for this preview
        AddHandler preview.TabbedThumbnailActivated, AddressOf preview_TabbedThumbnailActivated
        AddHandler preview.TabbedThumbnailClosed, AddressOf preview_TabbedThumbnailClosed
        AddHandler preview.TabbedThumbnailMaximized, AddressOf preview_TabbedThumbnailMaximized
        AddHandler preview.TabbedThumbnailMinimized, AddressOf preview_TabbedThumbnailMinimized

        TaskBarWindow.UpdatePreviewBitmap(Me)
    End Sub

    Private Sub FloatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FloatToolStripMenuItem.Click
        DockState = DockState.Float
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        RaiseEvent CloseDocument()

        Call Me.Close()
    End Sub

    Private Sub CloseAllButThisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllButThisToolStripMenuItem.Click
        For Each tab As IDockContent In MyApplication.host.dockPanel.Documents.ToArray
            If Not TypeOf tab Is ToolWindow Then
                If Not tab Is Me Then
                    Call DirectCast(tab, Form).Close()
                End If
            End If
        Next
    End Sub

    Private Sub CloseAllDocumentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllDocumentsToolStripMenuItem.Click
        For Each tab As IDockContent In MyApplication.host.dockPanel.Documents.ToArray
            If Not TypeOf tab Is ToolWindow Then
                Call DirectCast(tab, Form).Close()
            End If
        Next
    End Sub

    Protected Overridable Sub CopyFullPath() Handles CopyFullPathToolStripMenuItem.Click

    End Sub

    Protected Overridable Sub OpenContainingFolder() Handles OpenContainingFolderToolStripMenuItem.Click

    End Sub

    Protected Overridable Sub SaveDocument() Handles SaveDocumentToolStripMenuItem.Click

    End Sub
End Class
