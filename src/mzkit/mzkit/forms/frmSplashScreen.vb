﻿#Region "Microsoft.VisualBasic::a29d2953a02e461d3f9939b3e829e309, src\mzkit\mzkit\forms\frmSplashScreen.vb"

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

    ' Class frmSplashScreen
    ' 
    '     Properties: isAboutScreen
    ' 
    '     Sub: frmSplashScreen_Deactivate, frmSplashScreen_Load, frmSplashScreen_LostFocus, frmSplashScreen_Paint, LinkLabel1_LinkClicked
    ' 
    ' /********************************************************************************/

#End Region

Public Class frmSplashScreen

    Public Property isAboutScreen As Boolean = False

    Private Sub frmSplashScreen_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If isAboutScreen Then
            Call Me.Close()
        End If
    End Sub

    Private Sub frmSplashScreen_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://mzkit.org/")
    End Sub

    Private Sub frmSplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = Label3.Text.Replace("%s", My.User.Name)
    End Sub

    Private Sub frmSplashScreen_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
End Class

