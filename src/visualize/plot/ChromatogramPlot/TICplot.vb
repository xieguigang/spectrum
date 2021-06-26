﻿#Region "Microsoft.VisualBasic::c9664345eaf951b363629b3b6fd165be, src\visualize\plot\ChromatogramPlot\TICplot.vb"

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

    ' Class TICplot
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    '     Function: colorProvider, GetLabels, newPen
    ' 
    '     Sub: DrawLabels, DrawTICLegends, PlotInternal, RunPlot
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Chromatogram
Imports Microsoft.VisualBasic.ComponentModel.Algorithm.base
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Axis
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Canvas
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Legend
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.d3js
Imports Microsoft.VisualBasic.Imaging.d3js.Layout
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Imaging.Drawing2D.Colors
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.MIME.Html.CSS

Public Class TICplot : Inherits Plot

    ReadOnly ionData As NamedCollection(Of ChromatogramTick)()
    ReadOnly timeRange As Double() = Nothing
    ReadOnly intensityMax As Double = 0
    ReadOnly isXIC As Boolean
    ReadOnly fillCurve As Boolean
    ReadOnly fillAlpha As Integer
    ReadOnly labelLayoutTicks As Integer = 100
    ReadOnly deln As Integer = 10
    ''' <summary>
    ''' 当两个滑窗点的时间距离过长的时候，就不进行连接线的绘制操作了
    ''' （插入两个零值的点）
    ''' </summary>
    ReadOnly leapTimeWinSize As Double = 30

    Public Sub New(ionData As NamedCollection(Of ChromatogramTick)(),
                   timeRange As Double(),
                   intensityMax As Double,
                   isXIC As Boolean,
                   fillCurve As Boolean,
                   fillAlpha As Integer,
                   labelLayoutTicks As Integer,
                   deln As Integer,
                   theme As Theme)

        MyBase.New(theme)

        Me.isXIC = isXIC
        Me.intensityMax = intensityMax
        Me.ionData = ionData
        Me.fillCurve = fillCurve
        Me.fillAlpha = fillAlpha
        Me.labelLayoutTicks = labelLayoutTicks
        Me.deln = deln

        If timeRange Is Nothing Then
            Me.timeRange = {}
        Else
            Me.timeRange = timeRange
        End If
    End Sub

    Private Function newPen(c As Color) As Pen
        Dim style As Stroke = Stroke.TryParse(theme.lineStroke)
        style.fill = c.ARGBExpression
        Return style.GDIObject
    End Function

    Private Function colorProvider() As LoopArray(Of Pen)
        If ionData.Length = 1 Then
            Return {newPen(theme.colorSet.TranslateColor(False) Or Color.DeepSkyBlue.AsDefault)}
        Else
            Return Designer _
                .GetColors(theme.colorSet) _
                .Select(AddressOf newPen) _
                .ToArray
        End If
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Protected Overrides Sub PlotInternal(ByRef g As IGraphics, canvas As GraphicsRegion)
        Call RunPlot(g, canvas, Nothing, Nothing)
    End Sub

    Friend Sub RunPlot(ByRef g As IGraphics, canvas As GraphicsRegion, ByRef labels As Label(), ByRef legends As LegendObject())
        Dim colors As LoopArray(Of Pen) = colorProvider()
        Dim XTicks As Double() = ionData _
            .Select(Function(ion)
                        Return ion.value.TimeArray
                    End Function) _
            .IteratesALL _
            .JoinIterates(timeRange) _
            .AsVector _
            .Range _
            .CreateAxisTicks  ' time

        Dim YTicks = ionData _
            .Select(Function(ion)
                        Return ion.value.IntensityArray
                    End Function) _
            .IteratesALL _
            .JoinIterates({intensityMax}) _
            .AsVector _
            .Range _
            .CreateAxisTicks ' intensity

        Dim rect As Rectangle = canvas.PlotRegion
        Dim X = d3js.scale.linear.domain(XTicks).range(integers:={rect.Left, rect.Right})
        Dim Y = d3js.scale.linear.domain(YTicks).range(integers:={rect.Top, rect.Bottom})
        Dim scaler As New DataScaler With {
            .AxisTicks = (XTicks, YTicks),
            .region = rect,
            .X = X,
            .Y = Y
        }

        If theme.drawAxis Then
            Call g.DrawAxis(
                canvas, scaler, showGrid:=theme.drawGrid,
                xlabel:=Me.xlabel,
                ylabel:=Me.ylabel,
                htmlLabel:=False,
                XtickFormat:=If(isXIC, "F2", "F0"),
                YtickFormat:="G2",
                labelFont:=theme.axisLabelCSS,
                tickFontStyle:=theme.axisTickCSS,
                gridFill:=theme.gridFill,
                xlayout:=theme.xAxisLayout,
                ylayout:=theme.yAxisLayout,
                axisStroke:=theme.axisStroke
            )
        End If

        Dim peakTimes As New List(Of NamedValue(Of ChromatogramTick))
        Dim fillColor As Brush
        Dim legendList As New List(Of LegendObject)

        For i As Integer = 0 To ionData.Length - 1
            Dim curvePen As Pen = colors.Next
            Dim line = ionData(i)
            Dim chromatogram = line.value

            If chromatogram.IsNullOrEmpty Then
                Call $"ion not found in raw file: '{line.name}'".Warning
                Continue For
            End If

            legendList += New LegendObject With {
                .title = line.name,
                .color = curvePen.Color.ToHtmlColor,
                .fontstyle = theme.legendLabelCSS,
                .style = LegendStyles.Rectangle
            }
            peakTimes += New NamedValue(Of ChromatogramTick) With {
                .Name = line.name,
                .Value = chromatogram(which.Max(chromatogram.Shadows!Intensity))
            }

            Dim bottom% = canvas.Bottom - 6
            Dim viz = g
            Dim polygon As New List(Of PointF)
            Dim draw = Sub(t1 As ChromatogramTick, t2 As ChromatogramTick)
                           Dim A = scaler.Translate(t1.Time, t1.Intensity)
                           Dim B = scaler.Translate(t2.Time, t2.Intensity)

                           Call viz.DrawLine(curvePen, A, B)

                           If polygon = 0 Then
                               polygon.Add(New PointF(A.X, bottom))
                               polygon.Add(A)
                           End If

                           polygon.Add(B)
                       End Sub

            For Each signal As SlideWindow(Of ChromatogramTick) In chromatogram.SlideWindows(winSize:=2)
                Dim dt As Double = signal.Last.Time - signal.First.Time

                If dt > leapTimeWinSize Then
                    ' add zero point
                    If dt > leapTimeWinSize Then
                        dt = leapTimeWinSize / 2
                    Else
                        dt = dt / 2
                    End If

                    Dim i1 As New ChromatogramTick With {.Time = signal.First.Time + dt, .Intensity = 0}
                    Dim i2 As New ChromatogramTick With {.Time = signal.Last.Time - dt, .Intensity = 0}

                    Call draw(signal.First, i1)

                    polygon.Add(New PointF(polygon.Last.X, bottom))

                    If fillCurve Then
                        fillColor = New SolidBrush(Color.FromArgb(fillAlpha, curvePen.Color))
                        g.FillPolygon(fillColor, polygon)
                    End If

                    polygon.Clear()

                    Call draw(i2, signal.Last)
                Else
                    Call draw(signal.First, signal.Last)
                End If
            Next

            polygon.Add(New PointF(polygon.Last.X, bottom))

            If fillCurve Then
                fillColor = New SolidBrush(Color.FromArgb(fillAlpha, curvePen.Color))
                g.FillPolygon(fillColor, polygon)
            End If
        Next

        legends = legendList
        labels = GetLabels(g, scaler, peakTimes).ToArray

        If theme.drawLabels Then Call DrawLabels(g, rect, labels, theme, labelLayoutTicks)
        If theme.drawLegend Then Call DrawTICLegends(g, canvas, legends, deln, outside:=False)
    End Sub

    Private Iterator Function GetLabels(g As IGraphics, scaler As DataScaler, peakTimes As IEnumerable(Of NamedValue(Of ChromatogramTick))) As IEnumerable(Of Label)
        Dim labelFont As Font = CSSFont.TryParse(theme.tagCSS)

        For Each ion As NamedValue(Of ChromatogramTick) In peakTimes
            Dim labelSize As SizeF = g.MeasureString(ion.Name, labelFont)
            Dim location As PointF = scaler.Translate(ion.Value)

            Yield New Label With {
                .height = labelSize.Height,
                .width = labelSize.Width,
                .text = ion.Name,
                .X = location.X,
                .Y = location.Y
            }
        Next
    End Function

    Friend Shared Sub DrawLabels(g As IGraphics, rect As Rectangle, labels As Label(), theme As Theme, labelLayoutTicks As Integer)
        Dim labelFont As Font = CSSFont.TryParse(theme.tagCSS)
        Dim labelConnector As Pen = Stroke.TryParse(theme.tagLinkStroke)
        Dim anchors As Anchor() = labels.GetLabelAnchors(r:=3)

        Call d3js.labeler(maxAngle:=5, maxMove:=300, w_lab2:=100, w_lab_anc:=100) _
            .Labels(labels) _
            .Anchors(anchors) _
            .Width(rect.Width) _
            .Height(rect.Height) _
            .Start(showProgress:=False, nsweeps:=labelLayoutTicks)

        Dim labelBrush As Brush = theme.tagColor.GetBrush

        For Each i As SeqValue(Of Label) In labels.SeqIterator
            Call g.DrawLine(labelConnector, i.value.GetTextAnchor(anchors(i)), anchors(i))
            Call g.DrawString(i.value.text, labelFont, labelBrush, i.value)
        Next
    End Sub

    Friend Shared Sub DrawTICLegends(g As IGraphics, canvas As GraphicsRegion, legends As LegendObject(), deln As Integer, outside As Boolean)
        ' 如果离子数量非常多的话,则会显示不完
        ' 这时候每20个换一列
        Dim cols = legends.Length / deln

        If cols > Fix(cols) Then
            ' 有余数,说明还有剩下的,增加一列
            cols += 1
        End If

        ' 计算在右上角的位置
        Dim maxSize As SizeF = legends.MaxLegendSize(g)
        Dim top = canvas.PlotRegion.Top + maxSize.Height + 5
        Dim maxLen = maxSize.Width
        Dim legendShapeWidth% = 70
        Dim left As Double

        If outside Then
            left = canvas.PlotRegion.Right + g.MeasureString("A", legends(Scan0).GetFont).Width
        Else
            left = canvas.PlotRegion.Right - (maxLen + legendShapeWidth) * cols
        End If

        Dim position As New Point With {
            .X = left,
            .Y = top
        }

        For Each block As LegendObject() In legends.Split(deln)
            g.DrawLegends(position, block, $"{legendShapeWidth},10", d:=0)
            position = New Point With {
                .X = position.X + maxLen + legendShapeWidth,
                .Y = position.Y
            }
        Next
    End Sub
End Class
