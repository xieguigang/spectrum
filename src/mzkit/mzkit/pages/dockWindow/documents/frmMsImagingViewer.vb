﻿Imports System.Threading
Imports BioNovoGene.Analytical.MassSpectrometry.MsImaging
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Net.Protocols.ContentTypes
Imports Microsoft.VisualBasic.Scripting.Runtime
Imports mzkit.My
Imports Task
Imports WeifenLuo.WinFormsUI.Docking

Public Class frmMsImagingViewer
    Implements IFileReference

    Public Property FilePath As String Implements IFileReference.FilePath

    Dim render As Drawer
    Dim params As MsImageProperty
    Dim WithEvents checks As ToolStripMenuItem
    Dim WithEvents tweaks As PropertyGrid
    Dim rendering As Action

    Public ReadOnly Property MimeType As ContentType() Implements IFileReference.MimeType
        Get
            Return {
                New ContentType With {.Details = "Image mzML", .FileExt = ".imzML", .MIMEType = "text/xml", .Name = "Image mzML"}
            }
        End Get
    End Property

    Private Sub frmMsImagingViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        TabText = Text
        MyApplication.host.msImageParameters.DockState = DockState.DockLeft
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
    End Sub

    Public Sub LoadRender(render As Drawer)
        Dim checks As CheckedListBox = MyApplication.host.msImageParameters.CheckedListBox1

        Me.checks = MyApplication.host.msImageParameters.RenderingToolStripMenuItem
        Me.render = render
        Me.params = New MsImageProperty(render)
        Me.tweaks = MyApplication.host.msImageParameters.PropertyGrid1

        MyApplication.host.msImageParameters.PropertyGrid1.SelectedObject = params
        MyApplication.host.msImageParameters.CheckedListBox1.Items.Clear()

        For Each mz As Double In render.LoadMzArray(20)
            Call checks.Items.Add(mz.ToString("F4"))
            Call Application.DoEvents()
        Next
    End Sub

    Private Sub checks_Click(sender As Object, e As EventArgs) Handles checks.Click
        Dim mz As Object() = (From item In MyApplication.host.msImageParameters.CheckedListBox1.CheckedItems).ToArray

        If mz.Length = 0 Then
            mz = (From item In MyApplication.host.msImageParameters.CheckedListBox1.SelectedItems).ToArray
        End If

        If mz.Length = 0 Then
            Call MyApplication.host.showStatusMessage("No ions selected for rendering!", My.Resources.StatusAnnotations_Warning_32xLG_color)
            Return
        End If

        Dim selectedMz As New List(Of Double)
        Dim progress As New frmProgressSpinner
        Dim size As String = $"{params.pixel_width},{params.pixel_height}"

        For i As Integer = 0 To mz.Length - 1
            selectedMz.Add(Val(CStr(mz(i))))
        Next

        If selectedMz.Count = 1 Then
            MyApplication.host.showStatusMessage($"Run MS-Image rendering for selected ion m/z {selectedMz(Scan0)}...")
        Else
            MyApplication.host.showStatusMessage($"Run MS-Image rendering for {selectedMz.Count} selected ions...")
        End If

        Call New Thread(
            Sub()
                Dim pixels = render.LoadPixels(selectedMz.ToArray, params.GetTolerance).ToArray
                Dim dimensionSize As Size = render.dimension

                pixels = Drawer.ScalePixels(pixels, params.GetTolerance)
                pixels = Drawer.GetPixelsMatrix(pixels)

                Call Invoke(Sub()
                                rendering = Sub()
                                                Call MyApplication.RegisterPlot(
                                                    Sub(args)
                                                        PictureBox1.BackgroundImage = Drawer.RenderPixels(
                                                            pixels:=pixels,
                                                            dimension:=dimensionSize,
                                                            dimSize:=size.SizeParser,
                                                            threshold:=params.threshold,
                                                            mapLevels:=params.mapLevels,
                                                            colorSet:=params.colors.Description
                                                        )

                                                        PictureBox1.BackColor = params.background
                                                    End Sub)
                                            End Sub
                            End Sub)

                Call Invoke(rendering)
                Call progress.Invoke(Sub() progress.Close())
            End Sub).Start()

        Call progress.ShowDialog()
        Call MyApplication.host.showStatusMessage("Rendering Complete!", My.Resources.preferences_system_notifications)
    End Sub

    Private Sub tweaks_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles tweaks.PropertyValueChanged
        Call rendering()
    End Sub
End Class