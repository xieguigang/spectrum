﻿#Region "Microsoft.VisualBasic::b713d060472924ebc54613ea74f7a61a, src\assembly\ThermoRawFileReader\Enums\IntensityCutoffTypeConstants.vb"

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

    ' Enum IntensityCutoffTypeConstants
    ' 
    ' 
    '  
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region


''' <summary>
''' Intensity Cutoff Types
''' </summary>
''' <remarks>Used with <see cref="XRawFileIO.mXRawFile"/> functions in <see cref="XRawFileIO.GetScanData2D"/> and <see cref="XRawFileIO.GetScanDataSumScans"/></remarks>
<CLSCompliant(True)>
Public Enum IntensityCutoffTypeConstants
    ''' <summary>
    ''' All Values Returned
    ''' </summary>
    None = 0

    ''' <summary>
    ''' Absolute Intensity Units
    ''' </summary>
    AbsoluteIntensityUnits = 1

    ''' <summary>
    ''' Intensity relative to base peak
    ''' </summary>
    RelativeToBasePeak = 2
End Enum
