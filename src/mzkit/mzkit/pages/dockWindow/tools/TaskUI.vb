﻿#Region "Microsoft.VisualBasic::d1dfd10487545be840a06dd87f2dc023, src\mzkit\mzkit\pages\dockWindow\tools\TaskUI.vb"

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

    ' Class TaskUI
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: Finish, ProgressMessage, Running
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports mzkit.My
Imports Vip.Notification

Public Class TaskUI

    Dim window As TaskListWindow
    Dim row As TreeListViewItem
    Dim status As ListViewItem.ListViewSubItem
    Dim progress As ListViewItem.ListViewSubItem

    Dim taskTitle, taskContent As String

    Sub New(task$, content$, list As TaskListWindow)
        row = New TreeListViewItem With {.Text = task, .ImageIndex = 0}
        status = New ListViewItem.ListViewSubItem With {.Text = "Pending", .BackColor = Color.Yellow}
        progress = New ListViewItem.ListViewSubItem With {.Text = "..."}

        row.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = content})
        row.SubItems.Add(New ListViewItem.ListViewSubItem With {.Text = Now.ToString})
        row.SubItems.Add(status)
        row.SubItems.Add(progress)

        window = list
        window.TreeListView1.Items.Add(row)

        taskTitle = task
        taskContent = content
    End Sub

    ''' <summary>
    ''' 切换为执行中的状态
    ''' </summary>
    Public Sub Running()
        window.Invoke(Sub()
                          status.Text = "Running..."
                          status.BackColor = Color.Green
                      End Sub)
    End Sub

    Public Sub ProgressMessage(message As String)
        window.Invoke(Sub()
                          progress.Text = message
                      End Sub)
    End Sub

    Public Sub Finish()
        Dim message As String = $"{taskTitle} Job Done!{vbCrLf}{taskContent}"
        Dim main = MyApplication.host

        window.Invoke(Sub()
                          status.Text = "Finished"
                          progress.Text = ""
                          status.BackColor = Color.SkyBlue
                      End Sub)
        TaskListWindow.pending -= 1

        Call main.Invoke(Sub()
                             main.ToolStripProgressBar1.Value += 1
                             WindowModules.taskWin.UpdateProgress()

                             If main.ToolStripProgressBar1.Value = main.ToolStripProgressBar1.Maximum Then
                                 main.ToolStripStatusLabel4.Image = My.Resources._1200px_Checked_svg
                                 main.ToolStripStatusLabel4.Text = "Job Done!"

                                 main.ToolStripProgressBar1.Value = 0
                                 main.ToolStripProgressBar1.Maximum = 0
                             End If
                         End Sub)

        ' Call Alert.ShowSucess(message)
    End Sub
End Class

