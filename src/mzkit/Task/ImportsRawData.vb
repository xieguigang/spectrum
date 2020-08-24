﻿Imports System.Threading
Imports BioNovoGene.Analytical.MassSpectrometry.Assembly.MarkupData
Imports BioNovoGene.Analytical.MassSpectrometry.Assembly.MarkupData.mzML
Imports BioNovoGene.Analytical.MassSpectrometry.Assembly.MarkupData.mzXML
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Spectra
Imports Microsoft.VisualBasic.Data.IO.netCDF
Imports Microsoft.VisualBasic.Data.IO.netCDF.Components
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text
Imports mzML = BioNovoGene.Analytical.MassSpectrometry.Assembly.MarkupData.mzML

Public Class ImportsRawData

    ReadOnly source As String
    ReadOnly temp As String
    ReadOnly showProgress As Action(Of String)
    ReadOnly success As Action

    Public ReadOnly Property raw As Raw

    Sub New(file As String, progress As Action(Of String), finished As Action)
        source = file
        temp = App.AppSystemTemp & "/" & file.GetFullPath.MD5 & ".cdf"
        showProgress = progress
        success = finished
        raw = New Raw With {
            .cache = temp.GetFullPath,
            .source = source.GetFullPath
        }
    End Sub

    Public Sub RunImports()
        If source.ExtensionSuffix("mzxml") Then
            Call importsMzXML()
        Else
            Call importsMzML()
        End If

        Call showProgress("Job Done!")
        Call Thread.Sleep(1500)
        Call success()
    End Sub

    Private Sub importsMzXML()
        Using cache As New CDFWriter(temp, Encodings.UTF8WithoutBOM)
            Dim attrs As attribute()
            Dim data As Double()
            Dim name As String
            Dim nscans As New List(Of ScanEntry)
            Dim rt As New List(Of Double)

            For Each scan As mzXML.scan In mzXML.XML.LoadScans(source)
                If scan.peaks.compressedLen = 0 OrElse DirectCast(scan.peaks, IBase64Container).BinaryArray.StringEmpty Then
                    Continue For
                End If

                attrs = {
                    New attribute With {.name = NameOf(scan.msLevel), .type = CDFDataTypes.INT, .value = scan.msLevel},
                    New attribute With {.name = NameOf(scan.collisionEnergy), .type = CDFDataTypes.CHAR, .value = scan.collisionEnergy Or "n/a".AsDefault},
                    New attribute With {.name = NameOf(scan.centroided), .type = CDFDataTypes.CHAR, .value = scan.centroided Or "n/a".AsDefault},
                    New attribute With {.name = NameOf(scan.precursorMz), .type = CDFDataTypes.DOUBLE, .value = scan.precursorMz.value},
                    New attribute With {.name = NameOf(scan.retentionTime), .type = CDFDataTypes.DOUBLE, .value = PeakMs2.RtInSecond(scan.retentionTime)}
                }
                data = scan.peaks.Base64Decode(True)
                name = scan.getName & $" scan={nscans.Count + 1}"
                cache.AddVariable(name, New CDFData With {.numerics = data}, New Dimension With {.name = "m/z-int,scan_" & scan.num, .size = data.Length}, attrs)
                rt.Add(PeakMs2.RtInSecond(scan.retentionTime))

                Call New ScanEntry With {
                    .id = name,
                    .mz = scan.precursorMz.value,
                    .rt = PeakMs2.RtInSecond(scan.retentionTime),
                    .intensity = scan.basePeakIntensity
                }.DoCall(AddressOf nscans.Add)

                Call showProgress(name)
            Next

            cache.GlobalAttributes(New attribute With {.name = NameOf(nscans), .type = CDFDataTypes.INT, .value = nscans.Count})

            raw.scans = nscans.ToArray
            raw.rtmin = rt.Min
            raw.rtmax = rt.Max

            Call showProgress("Write cache data...")
        End Using
    End Sub

    Private Sub importsMzML()
        Using cache As New CDFWriter(temp, Encodings.UTF8WithoutBOM)
            Dim attrs As attribute()
            Dim data As New List(Of Double)
            Dim name As String
            Dim nscans As New List(Of ScanEntry)
            Dim rt As New List(Of Double)

            For Each scan As spectrum In mzML.Xml.LoadScans(source)
                Dim parent As (mz As Double, into As Double) = Nothing

                If Not scan.cvParams.KeyItem("electromagnetic radiation spectrum") Is Nothing Then
                    Call showProgress($"skip electromagnetic radiation spectrum at {scan.scan_time}...")
                    Continue For
                End If

                If scan.ms_level > 1 Then
                    parent = scan.selectedIon
                End If

                data.Clear()
                ' 在这里的attribute name需要与mzXML的名称保持一致
                attrs = {
                    New attribute With {.name = NameOf(mzXML.scan.msLevel), .type = CDFDataTypes.INT, .value = scan.ms_level},
                    New attribute With {.name = NameOf(mzXML.scan.collisionEnergy), .type = CDFDataTypes.CHAR, .value = If(scan.ms_level = 1, "n/a", scan.precursorList.precursor(Scan0).GetCollisionEnergy)},
                    New attribute With {.name = NameOf(mzXML.scan.centroided), .type = CDFDataTypes.CHAR, .value = Not scan.profile},
                    New attribute With {.name = NameOf(mzXML.scan.precursorMz), .type = CDFDataTypes.DOUBLE, .value = parent.mz},
                    New attribute With {.name = NameOf(mzXML.scan.retentionTime), .type = CDFDataTypes.DOUBLE, .value = scan.scan_time}
                }

                Dim mz = scan.ByteArray("m/z array").Base64Decode
                Dim intensity = scan.ByteArray("intensity array").Base64Decode

                For i As Integer = 0 To mz.Length - 1
                    data.Add(intensity(i))
                    data.Add(mz(i))
                Next

                Dim polarity As String
                Dim scanType As String = scan.scanList.scans(0).cvParams.KeyItem("filter string")?.value

                If Not scan.cvParams.KeyItem("positive scan") Is Nothing Then
                    polarity = "+"
                Else
                    polarity = "-"
                End If

                If scan.ms_level = 1 Then
                    name = $"[MS1] {scanType}_{nscans.Count + 1}, ({polarity}) retentionTime={CInt(scan.scan_time)}"
                Else
                    name = $"[MS/MS] {scanType}_{nscans.Count + 1}, ({polarity}) M{CInt(parent.mz)}T{CInt(scan.scan_time)}"
                End If

                rt.Add(scan.scan_time)
                cache.AddVariable(name, New CDFData With {.numerics = data}, New Dimension With {.name = "m/z-int,scan_" & scan.index, .size = data.Count}, attrs)

                Call New ScanEntry With {
                    .id = name,
                    .mz = parent.mz,
                    .rt = scan.scan_time,
                    .intensity = parent.into
                }.DoCall(AddressOf nscans.Add)

                Call showProgress(name)
            Next

            cache.GlobalAttributes(New attribute With {.name = NameOf(nscans), .type = CDFDataTypes.INT, .value = nscans.Count})

            raw.scans = nscans.ToArray
            raw.rtmin = rt.Min
            raw.rtmax = rt.Max

            Call showProgress("Write cache data...")
        End Using
    End Sub
End Class