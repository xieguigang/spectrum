﻿#Region "Microsoft.VisualBasic::829e095c071c5a4ac89724293d4a78ec, src\mzkit\mzkit\pages\dockWindow\frmRsharp.vb"

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

' Class frmRsharp
' 
'     Sub: frmRsharp_Closing, frmRsharp_Load
' 
' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports Microsoft.VisualBasic.Windows.Forms
Imports mzkit.My

Public Class frmRsharp

    Dim console1 As New ConsoleControl
    Friend WithEvents console As Console

    Private Sub frmRsharp_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmRsharp_Load(sender As Object, e As EventArgs) Handles Me.Load
        TabText = "R# Terminal"

        Me.Icon = My.Resources.Rscript
        Me.ShowIcon = True

        Controls.Add(console1)

        console1.Font = New Font("Consolas", 10.0!)
        console1.Dock = DockStyle.Fill
        console1.Ps1Pattern = "[>]\s"

        console = console1.Console

        console.ForegroundColor = ConsoleColor.Black
        console.BackgroundColor = ConsoleColor.White

        MyApplication.RegisterConsole(console)
    End Sub

End Class
