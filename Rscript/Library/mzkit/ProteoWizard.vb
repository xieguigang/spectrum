﻿
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Logging
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports ProteoWizard.Interop
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.System.Configuration

''' <summary>
''' ProteoWizard helper
''' 
''' You should config the bin path of ProteoWizard at first 
''' by using ``options`` function
''' </summary>
<Package("ProteoWizard", Category:=APICategories.UtilityTools)>
Module ProteoWizard

    ''' <summary>
    ''' Is the ``ProteoWizard`` program ready to use?
    ''' </summary>
    ''' <returns></returns>
    <ExportAPI("msconvert.ready")>
    Public Function Ready(Optional env As Environment = Nothing) As Boolean
        VBDebugger.Mute = True

        If Not ProteoWizardCLI.IsAvaiable OrElse Not GetServices(env).IsAvailable Then
            VBDebugger.Mute = False
            Call env.AddMessage(ErrMsg, MSG_TYPES.WRN)
            Return False
        Else
            VBDebugger.Mute = False
            Return True
        End If
    End Function

    Private Function GetServices(env As Environment) As ProteoWizardCLI
        If Not ProteoWizardCLI.IsAvaiable Then
            Dim opts As Options = env.globalEnvironment.options
            Dim config As String = opts.getOption("ProteoWizard")

            Call ProteoWizardCLI.ConfigProgram(config)
        End If

        Return New ProteoWizardCLI
    End Function

    Const ErrMsg$ = "ProteoWizard un-available, you can config the program location by ``options(ProteoWizard='filepath')``!"

    ''' <summary>
    ''' Convert MRM wiff file to mzMl files
    ''' </summary>
    ''' <param name="wiff">The file path of the wiff file</param>
    ''' <returns>
    ''' File path collection of the converted mzML files.
    ''' </returns>
    <ExportAPI("MRM.mzML")>
    Public Function wiffMRM(wiff As String, Optional output$ = Nothing, Optional env As Environment = Nothing) As Object
        Dim bin As ProteoWizardCLI = GetServices(env)

        If Not bin.IsAvailable Then
            Return Internal.debug.stop(ErrMsg, env)
        Else
            If output.StringEmpty Then
                output = wiff.TrimSuffix
            End If

            bin.Convert2mzML(wiff, output, ProteoWizardCLI.OutFileTypes.mzML)
        End If

        Return output _
            .EnumerateFiles("*.mzML") _
            .ToArray
    End Function
End Module
