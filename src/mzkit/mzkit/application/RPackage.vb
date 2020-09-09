﻿#Region "Microsoft.VisualBasic::3bde69ca53c02be3a68b830a62c6fe66, src\mzkit\mzkit\application\RPackage.vb"

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

    '     Class MyApplication
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: BPC, ListFiles, rawDataFrame, TIC
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports Task
Imports REnv = SMRUCC.Rsharp.Runtime.Internal

Namespace My

    Partial Class MyApplication

        Shared Sub New()
            REnv.Object.Converts.makeDataframe.addHandler(GetType(Raw()), AddressOf rawDataFrame)
        End Sub

        Private Shared Function rawDataFrame(raws As Raw(), args As list, env As Environment) As dataframe
            Dim table As New dataframe With {.columns = New Dictionary(Of String, Array)}

            table.columns(NameOf(Raw.source)) = raws.Select(Function(a) a.source).ToArray
            table.columns(NameOf(Raw.rtmin)) = raws.Select(Function(a) a.rtmin).ToArray
            table.columns(NameOf(Raw.rtmax)) = raws.Select(Function(a) a.rtmax).ToArray
            table.columns(NameOf(Raw.numOfScans)) = raws.Select(Function(a) a.numOfScans).ToArray
            table.columns(NameOf(Raw.cache)) = raws.Select(Function(a) a.cache).ToArray
            table.columns("file_size") = raws.Select(Function(a) Lanudry(a.source.FileLength)).ToArray

            table.rownames = raws.Select(Function(a) a.source.FileName).ToArray

            Return table
        End Function

        <ExportAPI("TIC")>
        Public Shared Function TIC(file As Raw) As dataframe
            Dim table As New dataframe With {.columns = New Dictionary(Of String, Array)}
            Dim ms1 = file.scans.Where(Function(a) a.mz = 0).OrderBy(Function(a) a.rt).ToArray

            table.columns("time") = ms1.Select(Function(a) a.rt).ToArray
            table.columns("intensity") = ms1.Select(Function(a) a.TIC).ToArray

            Return table
        End Function

        <ExportAPI("BPC")>
        Public Shared Function BPC(file As Raw) As dataframe
            Dim table As New dataframe With {.columns = New Dictionary(Of String, Array)}
            Dim ms1 = file.scans.Where(Function(a) a.mz = 0).OrderBy(Function(a) a.rt).ToArray

            table.columns("time") = ms1.Select(Function(a) a.rt).ToArray
            table.columns("intensity") = ms1.Select(Function(a) a.BPC).ToArray

            Return table
        End Function

        ''' <summary>
        ''' Get a list of raw files that opened in current workspace
        ''' </summary>
        ''' <returns></returns>
        ''' 
        <ExportAPI("list.raw")>
        Public Shared Function ListFiles() As Raw()
            Dim list As New List(Of Raw)

            For i As Integer = 0 To host.fileExplorer.treeView1.Nodes.Count - 1
                list.Add(host.fileExplorer.treeView1.Nodes(i).Tag)
            Next

            Return list.ToArray
        End Function
    End Class
End Namespace