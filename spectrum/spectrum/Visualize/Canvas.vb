﻿Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Axis
Imports Microsoft.VisualBasic.Data.ChartPlots.Graphic.Legend
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.MIME.Markup.HTML.CSS

Public Module Canvas

    Const Padding$ = "padding: 250px 100px 200px 200px"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="MS_spectrum"></param>
    ''' <param name="size"></param>
    ''' <param name="padding$"></param>
    ''' <param name="bg$"></param>
    ''' <param name="mzAxis$">Y轴的数据永远是0到100</param>
    ''' <returns></returns>
    ''' 
    <Extension>
    Public Function Plot(MS_spectrum As spectrumData,
                         Optional size As Size = Nothing,
                         Optional padding$ = Canvas.Padding,
                         Optional bg$ = "white",
                         Optional title$ = "<span style=""color:blue"">MS/MS spectra</span>",
                         Optional mzAxis$ = "(0,800),tick=100",
                         Optional signalStroke$ = "stroke: green; stroke-width: 3px; stroke-dash: solid;",
                         Optional titleFontCSS$ = CSSFont.Win7Large,
                         Optional axisTickFont$ = CSSFont.Win10NormalLarger,
                         Optional axisLabelFont$ = CSSFont.Win7Large,
                         Optional legendFontCSS$ = CSSFont.PlotSmallTitle) As Bitmap

        Dim plotInternal =
            Sub(ByRef g As Graphics, region As GraphicsRegion)
                Dim y As AxisProvider = "(0,100),n=5"
                Dim x As AxisProvider

                If mzAxis.StringEmpty Then
                    Dim mzAxisData#() = MS_spectrum.data _
                        .Select(Function(mz) mz.x) _
                        .ToArray
                    x = New AxisProvider(mzAxisData)
                Else
                    x = mzAxis
                End If

                Dim mapper As New Mapper(x, y)
                Dim scaler = mapper.PointScaler(region.Size, region.Padding)
                Dim getPoint = Function(xi!, yi!)
                                   Return scaler(New PointF(xi, yi))
                               End Function

                Call mapper.DrawYGrid(g, region,
                                      New Pen(Color.Black, 2),
                                      "Intensity (%)",)
                Call g.DrawX(size, padding, New Pen(Color.Black, 2),
                             "Mass (m/z)",
                             mapper,
                             XAxisLayoutStyles.Bottom,
                             Nothing,
                             axisLabelFont,
                             CSSFont.TryParse(axisTickFont),
                             overridesTickLine:=20)

                Dim signalPen As Pen = Stroke.TryParse(signalStroke)
                Dim bottom! = region.Bottom

                For Each hit As MSSignal In MS_spectrum.data
                    Dim point As PointF = getPoint(xi:=hit.x, yi:=hit.y)
                    Dim low As New PointF(point.X, bottom)

                    Call g.DrawLine(signalPen, point, low)
                Next

                Dim legendFont As Font = CSSFont.TryParse(legendFontCSS)
                Dim name$ = MS_spectrum.name.Trim
                Dim legendShapeSize As New Size(60, 45)
                Dim legendPoint As New Point(
                    region.PlotRegion.Right - legendShapeSize.Width * 2 - g.MeasureString(name, legendFont).Width,
                    region.Padding.Top * 1.5)
                Dim legend As New Legend With {
                    .color = signalPen.Color.RGBExpression,
                    .fontstyle = legendFontCSS,
                    .style = LegendStyles.RoundRectangle,
                    .title = name
                }

                Call g.DrawLegends(
                    legendPoint, {legend}, legendShapeSize,
                    regionBorder:=New Stroke With {
                        .dash = DashStyle.Solid,
                        .fill = "black",
                        .width = 2
                    })

                Dim titleImage As Image = Axis.DrawLabel(title, titleFontCSS)
                Call g.DrawImageUnscaled(titleImage, region.TopCentra(titleImage.Size))
            End Sub

        If size.IsEmpty Then
            size = New Size(2400, 1600)
        End If

        Return g.GraphicsPlots(
            size, padding,
            bg,
            plotInternal)
    End Function
End Module
