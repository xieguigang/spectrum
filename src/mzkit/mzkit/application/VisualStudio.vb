﻿Imports mzkit.DockSample
Imports mzkit.My
Imports WeifenLuo.WinFormsUI.Docking

Public Class VisualStudio

    Public Shared Sub Dock(win As ToolWindow, prefer As DockState)
        Call win.Show(MyApplication.host.dockPanel)

        Select Case win.DockState
            Case DockState.Hidden, DockState.Unknown
                win.DockState = prefer
            Case DockState.Float, DockState.Document, DockState.DockTop, DockState.DockRight, DockState.DockLeft, DockState.DockBottom
                ' do nothing 
            Case DockState.DockBottomAutoHide
                win.DockState = DockState.DockBottom
            Case DockState.DockLeftAutoHide
                win.DockState = DockState.DockLeft
            Case DockState.DockRightAutoHide
                win.DockState = DockState.DockRight
            Case DockState.DockTopAutoHide
                win.DockState = DockState.DockTop
        End Select
    End Sub
End Class