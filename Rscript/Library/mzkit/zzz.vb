﻿#Region "Microsoft.VisualBasic::b272d492acf40182edf35e96629a9532, Rscript\Library\mzkit\zzz.vb"

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

    ' Class zzz
    ' 
    '     Function: printLib, printMSScan
    ' 
    '     Sub: onLoad
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text
Imports BioNovoGene.Analytical.MassSpectrometry.Assembly.mzData.mzWebCache
Imports BioNovoGene.Analytical.MassSpectrometry.Math.Spectra
Imports REnv = SMRUCC.Rsharp.Runtime

Public Class zzz

    Public Shared Sub onLoad()
        Call REnv.Internal.ConsolePrinter.AttachConsoleFormatter(Of LibraryMatrix)(AddressOf printLib)
        Call REnv.Internal.ConsolePrinter.AttachConsoleFormatter(Of ScanMS1)(AddressOf printMSScan)
        Call REnv.Internal.ConsolePrinter.AttachConsoleFormatter(Of ScanMS2)(AddressOf printMSScan)
    End Sub

    Private Shared Function printMSScan(scan As MSScan) As String
        Dim sb As New StringBuilder

        Call sb.AppendLine(scan.scan_id)
        Call sb.AppendLine(New String("-", scan.scan_id.Length))

        If TypeOf scan Is ScanMS1 Then
            Dim ms1 As ScanMS1 = DirectCast(scan, ScanMS1)

            Call sb.AppendLine($"Total Ions: {ms1.TIC}")
            Call sb.AppendLine($"BasePeak Intensity: {ms1.BPC}")
            Call sb.AppendLine($"Scan Time: {ms1.rt}")
            Call sb.AppendLine($"Num Products: {ms1.products.TryCount}")

        ElseIf TypeOf scan Is ScanMS2 Then
            Dim ms2 As ScanMS2 = DirectCast(scan, ScanMS2)

            Call sb.AppendLine($"Parent M/Z: {ms2.parentMz}")
            Call sb.AppendLine($"Scan Time: {ms2.rt}")
            Call sb.AppendLine($"Num Fragments: {ms2.mz.Length}")
            Call sb.AppendLine($"Precursor Intensity: {ms2.intensity}")
            Call sb.AppendLine($"Polarity: {ms2.polarity}")
            Call sb.AppendLine($"Charge: {ms2.charge}")
            Call sb.AppendLine($"Activation Method: {ms2.activationMethod.Description}")
            Call sb.AppendLine($"Collision Energy: {ms2.collisionEnergy}")
            Call sb.AppendLine($"Centroided: {ms2.centroided}")

        Else
            Throw New NotImplementedException(scan.GetType.FullName)
        End If

        Return sb.ToString
    End Function

    Private Shared Function printLib([lib] As LibraryMatrix) As String
        Dim sb As New StringBuilder

        Call sb.AppendLine([lib].name)
        Call sb.AppendLine(New String("-"c, 48))
        Call sb.AppendLine($"centroid: {[lib].centroid.ToString.ToLower}")
        Call sb.AppendLine($"length: {[lib].Length}")
        Call sb.AppendLine($"totalIon: {[lib].totalIon}")
        Call sb.AppendLine($"basePeak: {[lib].Max}")

        Return sb.ToString
    End Function
End Class
