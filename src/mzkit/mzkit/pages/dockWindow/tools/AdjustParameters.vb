﻿#Region "Microsoft.VisualBasic::207c06b608d89b09d4fb97cca5eaf155, src\mzkit\mzkit\pages\dockWindow\tools\AdjustParameters.vb"

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

    ' Class AdjustParameters
    ' 
    '     Sub: AdjustParameters_Closing, propertyGrid_PropertyValueChanged, SetParameterObject
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports WeifenLuo.WinFormsUI.Docking

Public Class AdjustParameters

    Dim applyNewParameters As Action(Of Object)

    Public Sub SetParameterObject(Of T As Class)(args As T, refresh As Action(Of T))
        applyNewParameters = Sub(obj) Call refresh(DirectCast(obj, T))
        propertyGrid.SelectedObject = args
        propertyGrid.Refresh()
    End Sub

    Private Sub propertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles propertyGrid.PropertyValueChanged
        Call applyNewParameters(propertyGrid.SelectedObject)
    End Sub

    Private Sub AdjustParameters_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Me.DockState = DockState.Hidden
    End Sub
End Class
