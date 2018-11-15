﻿#Region "Microsoft.VisualBasic::5b72d62ac2b9e4b831d059f43b953b15, ms2_math-core\Chromatogram\ROI.vb"

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

    '     Class ROI
    ' 
    '         Properties: Baseline, Integration, MaxInto, Noise, PeakWidth
    '                     rt, snRatio, Ticks, Time
    ' 
    '         Function: GetChromatogramData, GetROITable, ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model
Imports Microsoft.VisualBasic.Language.Default
Imports sys = System.Math

Namespace Chromatogram

    ''' <summary>
    ''' 一个ROI区域就是色谱图上面的一个时间范围内的色谱峰数据
    ''' </summary>
    Public Interface IROI
        ''' <summary>
        ''' 色谱图区域范围的时间下限
        ''' </summary>
        ''' <returns></returns>
        Property rtmin As Double
        ''' <summary>
        ''' 色谱图区域范围的时间上限
        ''' </summary>
        ''' <returns></returns>
        Property rtmax As Double
    End Interface

    ''' <summary>
    ''' Region of interest
    ''' </summary>
    Public Class ROI : Implements IRetentionTime

        ''' <summary>
        ''' 这个区域的起始和结束的时间点
        ''' </summary>
        ''' <returns></returns>
        Public Property Time As DoubleRange
        ''' <summary>
        ''' 出峰达到峰高最大值<see cref="MaxInto"/>的时间点
        ''' </summary>
        ''' <returns></returns>
        Public Property rt As Double Implements IRetentionTime.rt
        ''' <summary>
        ''' 这个区域的最大峰高度
        ''' </summary>
        ''' <returns></returns>
        Public Property MaxInto As Double

        ''' <summary>
        ''' 在这个ROI时间窗区域内的色谱图数据
        ''' </summary>
        ''' <returns></returns>
        Public Property Ticks As ChromatogramTick()
        ''' <summary>
        ''' 所计算出来的基线的响应强度
        ''' </summary>
        ''' <returns></returns>
        Public Property Baseline As Double
        ''' <summary>
        ''' 当前的这个ROI的峰面积积分值
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' 为当前的ROI峰面积占整个TIC峰面积的百分比，一个实验所导出来的所有的ROI的
        ''' 积分值加起来应该是约等于100的
        ''' </remarks>
        Public Property Integration As Double
        ''' <summary>
        ''' 噪声的面积积分百分比
        ''' </summary>
        ''' <returns></returns>
        Public Property Noise As Double

        ''' <summary>
        ''' 信噪比
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property snRatio As Double
            Get
                Return sys.Log(Integration / Noise)
            End Get
        End Property

        Public ReadOnly Property PeakWidth As Single
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return Time.Length
            End Get
        End Property

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetChromatogramData(Optional getTitle As Func(Of ROI, String) = Nothing) As NamedCollection(Of ChromatogramTick)
            Static defaultRtTitle As New DefaultValue(Of Func(Of ROI, String))(
                Function(roi)
                    Return $"[{roi.Time.Min.ToString("F0")},{roi.Time.Max.ToString("F0")}]"
                End Function)
            Return New NamedCollection(Of ChromatogramTick)((getTitle Or defaultRtTitle)(Me), Ticks)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function GetROITable(Optional getTitle As Func(Of ROI, String) = Nothing) As ROITable
            Static defaultRtTitle As New DefaultValue(Of Func(Of ROI, String))(
               Function(roi)
                   Return $"[{roi.Time.Min.ToString("F0")},{roi.Time.Max.ToString("F0")}]"
               End Function)

            Return New ROITable With {
                .baseline = Baseline,
                .ID = (getTitle Or defaultRtTitle)(Me),
                .integration = Integration,
                .maxInto = MaxInto,
                .rtmax = Time.Max,
                .rtmin = Time.Min,
                .rt = rt,
                .sn = snRatio
            }
        End Function

        Public Overrides Function ToString() As String
            Return Time.ToString
        End Function

        Public Shared Narrowing Operator CType(ROI As ROI) As DoubleRange
            Return ROI.Time
        End Operator
    End Class
End Namespace
