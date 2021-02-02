﻿Imports BioNovoGene.Analytical.MassSpectrometry.Math.Spectra
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.Ranges.Model

Namespace GCMS

    ''' <summary>
    ''' 定量离子模型
    ''' </summary>
    Public Class QuantifyIon : Implements INamedValue

        Public Property id As String Implements INamedValue.Key
        Public Property rt As DoubleRange
        Public Property ms As ms2()

    End Class
End Namespace