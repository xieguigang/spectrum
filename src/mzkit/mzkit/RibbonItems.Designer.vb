﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports RibbonLib
Imports RibbonLib.Controls
Imports RibbonLib.Interop

Partial Class RibbonItems
    Private _Ribbon As Ribbon, _RecentItems As RibbonRecentItems, _MenuGroupFile As RibbonMenuGroup, _ButtonNew As RibbonButton, _ButtonImportsRawFiles As RibbonButton, _ButtonToolkits As RibbonDropDownButton, _ButtonDropA As RibbonButton, _ButtonDropB As RibbonButton, _ButtonDropC As RibbonButton, _ButtonDropD As RibbonButton, _ButtonRsharp As RibbonButton, _ButtonSettings As RibbonButton, _ButtonAbout As RibbonButton, _ButtonBioDeep As RibbonButton, _ButtonLicense As RibbonButton, _MenuGroupExit As RibbonMenuGroup, _ButtonExit As RibbonButton, _HelpButton As RibbonHelpButton, _QAT As RibbonQuickAccessToolbar, _ButtonPageNavBack As RibbonButton, _ButtonOpenRaw As RibbonButton, _ButtonSave As RibbonButton, _TabGroupTableTools As RibbonTabGroup, _TabDesign As RibbonTab, _GroupDesign As RibbonGroup, _PPMSpinner As RibbonSpinner, _GroupShowViewer As RibbonGroup, _ButtonShowPlotViewer As RibbonButton, _ButtonShowMatrixViewer As RibbonButton, _GroupShowDockWindows As RibbonGroup, _ButtonShowExplorer As RibbonButton, _ButtonShowSearchList As RibbonButton, _ButtonShowProperties As RibbonButton, _TabLayout As RibbonTab, _GroupLayout As RibbonGroup, _ButtonLayout1 As RibbonButton, _ButtonLayout2 As RibbonButton, _GroupChromatography As RibbonGroup, _ButtonBPC As RibbonButton, _ButtonTIC As RibbonButton, _ButtonXIC As RibbonButton, _PlotOptions As RibbonGroup, _CheckBoxXICRelative As RibbonCheckBox, _TabGroupCalculatorTools As RibbonTabGroup, _TabCalculator As RibbonTab, _GroupCalculator As RibbonGroup, _ButtonCalculatorExport As RibbonButton, _TabGroupRscriptTools As RibbonTabGroup, _TabRscriptTools As RibbonTab, _GroupRscript As RibbonGroup, _ButtonSaveScript As RibbonButton, _ButtonRunScript As RibbonButton, _TabGroupExactMassSearchTools As RibbonTabGroup, _TabExactMassSearch As RibbonTab, _GroupExactMassSearch As RibbonGroup, _ButtonExactMassSearchExport As RibbonButton, _TabGroupNetworkTools As RibbonTabGroup, _TabNetwork As RibbonTab, _GroupNetwork As RibbonGroup, _ButtonNetworkExport As RibbonButton, _ButtonNetworkRender As RibbonButton, _GroupNetworkTools As RibbonGroup, _SpinnerSimilarity As RibbonSpinner, _GroupNetworkRenderTool As RibbonGroup, _ButtonRefreshNetwork As RibbonButton, _TabGroupFormulaSearchTools As RibbonTabGroup, _TabFormulaSearch As RibbonTab, _GroupFormulaSearch As RibbonGroup, _ButtonFormulaSearchExport As RibbonButton, _TargetedContex As RibbonTabGroup, _TabTargeted As RibbonTab, _TabGroupTargeted As RibbonGroup, _ImportsLinear As RibbonButton, _TabMain As RibbonTab, _GroupFileActions As RibbonGroup, _TabGroupWindowTools As RibbonGroup, _ButtonShowStartPage As RibbonButton, _ButtonShowLogWindow As RibbonButton, _ButtonResetLayout As RibbonButton, _TabTools As RibbonTab, _GroupToolsActions As RibbonGroup, _ButtonMzCalculator As RibbonButton, _ButtonMzSearch As RibbonButton, _ButtonShowSpectrumSearchPage As RibbonButton, _Targeted As RibbonButton, _TabAbout As RibbonTab, _GroupAboutActions As RibbonGroup, _GroupDemoActions As RibbonGroup, _ButtonMsDemo As RibbonButton, _FontControl As RibbonFontControl, _LegendCheckBox As RibbonCheckBox, _TweaksImage As RibbonButton, _ShowProperty As RibbonButton, _GroupExport As RibbonDropDownButton, _ButtonExportImage As RibbonButton, _ButtonExportMatrix As RibbonButton

    Private NotInheritable Class Cmd
        Public Const cmdRecentItems As UInteger = 1014
        Public Const cmdMenuGroupFile As UInteger = 1005
        Public Const cmdButtonNew As UInteger = 1001
        Public Const cmdButtonImportsRawFiles As UInteger = 1017
        Public Const cmdButtonToolkits As UInteger = 1007
        Public Const cmdButtonDropA As UInteger = 1008
        Public Const cmdButtonDropB As UInteger = 1009
        Public Const cmdButtonDropC As UInteger = 1010
        Public Const cmdButtonDropD As UInteger = 5010
        Public Const cmdButtonRsharp As UInteger = 1107
        Public Const cmdButtonSettings As UInteger = 1051
        Public Const cmdButtonAbout As UInteger = 1021
        Public Const cmdButtonBioDeep As UInteger = 1022
        Public Const cmdButtonLicense As UInteger = 1101
        Public Const cmdMenuGroupExit As UInteger = 1006
        Public Const cmdButtonExit As UInteger = 1004
        Public Const cmdHelpButton As UInteger = 1016
        Public Const cmdQAT As UInteger = 1015
        Public Const cmdButtonPageNavBack As UInteger = 1053
        Public Const cmdButtonOpenRaw As UInteger = 1002
        Public Const cmdButtonSave As UInteger = 1003
        Public Const cmdTabGroupTableTools As UInteger = 1031
        Public Const cmdTabDesign As UInteger = 1032
        Public Const cmdGroupDesign As UInteger = 1036
        Public Const cmdPPMSpinner As UInteger = 1050
        Public Const cmdGroupShowViewer As UInteger = 1110
        Public Const cmdButtonShowPlotViewer As UInteger = 1111
        Public Const cmdButtonShowMatrixViewer As UInteger = 1112
        Public Const cmdGroupShowDockWindows As UInteger = 1120
        Public Const cmdButtonShowExplorer As UInteger = 1121
        Public Const cmdButtonShowSearchList As UInteger = 1122
        Public Const cmdButtonShowProperties As UInteger = 1123
        Public Const cmdTabLayout As UInteger = 1035
        Public Const cmdGroupLayout As UInteger = 1037
        Public Const cmdButtonLayout1 As UInteger = 1043
        Public Const cmdButtonLayout2 As UInteger = 1044
        Public Const cmdGroupChromatography As UInteger = 1141
        Public Const cmdButtonBPC As UInteger = 1143
        Public Const cmdButtonTIC As UInteger = 1144
        Public Const cmdButtonXIC As UInteger = 1145
        Public Const cmdPlotOptions As UInteger = 97
        Public Const cmdCheckBoxXICRelative As UInteger = 96
        Public Const cmdTabGroupCalculatorTools As UInteger = 1061
        Public Const cmdTabCalculator As UInteger = 1062
        Public Const cmdGroupCalculator As UInteger = 1063
        Public Const cmdButtonCalculatorExport As UInteger = 1064
        Public Const cmdTabGroupRscriptTools As UInteger = 1130
        Public Const cmdTabRscriptTools As UInteger = 1131
        Public Const cmdGroupRscript As UInteger = 1132
        Public Const cmdButtonSaveScript As UInteger = 1134
        Public Const cmdButtonRunScript As UInteger = 1133
        Public Const cmdTabGroupExactMassSearchTools As UInteger = 1071
        Public Const cmdTabExactMassSearch As UInteger = 1072
        Public Const cmdGroupExactMassSearch As UInteger = 1073
        Public Const cmdButtonExactMassSearchExport As UInteger = 1074
        Public Const cmdTabGroupNetworkTools As UInteger = 1081
        Public Const cmdTabNetwork As UInteger = 1082
        Public Const cmdGroupNetwork As UInteger = 1083
        Public Const cmdButtonNetworkExport As UInteger = 1084
        Public Const cmdButtonNetworkRender As UInteger = 1085
        Public Const cmdGroupNetworkTools As UInteger = 1151
        Public Const cmdSpinnerSimilarity As UInteger = 1153
        Public Const cmdGroupNetworkRenderTool As UInteger = 1150
        Public Const cmdButtonRefreshNetwork As UInteger = 1154
        Public Const cmdTabGroupFormulaSearchTools As UInteger = 1091
        Public Const cmdTabFormulaSearch As UInteger = 1092
        Public Const cmdGroupFormulaSearch As UInteger = 1093
        Public Const cmdButtonFormulaSearchExport As UInteger = 1094
        Public Const cmdTargetedContex As UInteger = 101
        Public Const cmdTabTargeted As UInteger = 102
        Public Const cmdTabGroupTargeted As UInteger = 98
        Public Const cmdImportsLinear As UInteger = 100
        Public Const cmdTabMain As UInteger = 1011
        Public Const cmdGroupFileActions As UInteger = 1045
        Public Const cmdTabGroupWindowTools As UInteger = 1023
        Public Const cmdButtonShowStartPage As UInteger = 1108
        Public Const cmdButtonShowLogWindow As UInteger = 1109
        Public Const cmdButtonResetLayout As UInteger = 1019
        Public Const cmdTabTools As UInteger = 1012
        Public Const cmdGroupToolsActions As UInteger = 1046
        Public Const cmdButtonMzCalculator As UInteger = 1013
        Public Const cmdButtonMzSearch As UInteger = 1052
        Public Const cmdButtonShowSpectrumSearchPage As UInteger = 1102
        Public Const cmdTargeted As UInteger = 99
        Public Const cmdTabAbout As UInteger = 1020
        Public Const cmdGroupAboutActions As UInteger = 1047
        Public Const cmdGroupDemoActions As UInteger = 1048
        Public Const cmdButtonMsDemo As UInteger = 1168
        Public Const cmdFontControl As UInteger = 1165
        Public Const cmdLegendCheckBox As UInteger = 1166
        Public Const cmdTweaksImage As UInteger = 93
        Public Const cmdShowProperty As UInteger = 3
        Public Const cmdGroupExport As UInteger = 2
        Public Const cmdButtonExportImage As UInteger = 1104
        Public Const cmdButtonExportMatrix As UInteger = 1105
        Public Const cmdContextMap As UInteger = 1106
        Public Const cmdCustomizeQAT As UInteger = 1018
    End Class

    ' ContextPopup CommandName
    Public Const cmdContextMap As UInteger = Cmd.cmdContextMap

    Public Property Ribbon As Ribbon
        Get
            Return _Ribbon
        End Get
        Private Set(ByVal value As Ribbon)
            _Ribbon = value
        End Set
    End Property

    Public Property RecentItems As RibbonRecentItems
        Get
            Return _RecentItems
        End Get
        Private Set(ByVal value As RibbonRecentItems)
            _RecentItems = value
        End Set
    End Property

    Public Property MenuGroupFile As RibbonMenuGroup
        Get
            Return _MenuGroupFile
        End Get
        Private Set(ByVal value As RibbonMenuGroup)
            _MenuGroupFile = value
        End Set
    End Property

    Public Property ButtonNew As RibbonButton
        Get
            Return _ButtonNew
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonNew = value
        End Set
    End Property

    Public Property ButtonImportsRawFiles As RibbonButton
        Get
            Return _ButtonImportsRawFiles
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonImportsRawFiles = value
        End Set
    End Property

    Public Property ButtonToolkits As RibbonDropDownButton
        Get
            Return _ButtonToolkits
        End Get
        Private Set(ByVal value As RibbonDropDownButton)
            _ButtonToolkits = value
        End Set
    End Property

    Public Property ButtonDropA As RibbonButton
        Get
            Return _ButtonDropA
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonDropA = value
        End Set
    End Property

    Public Property ButtonDropB As RibbonButton
        Get
            Return _ButtonDropB
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonDropB = value
        End Set
    End Property

    Public Property ButtonDropC As RibbonButton
        Get
            Return _ButtonDropC
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonDropC = value
        End Set
    End Property

    Public Property ButtonDropD As RibbonButton
        Get
            Return _ButtonDropD
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonDropD = value
        End Set
    End Property

    Public Property ButtonRsharp As RibbonButton
        Get
            Return _ButtonRsharp
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonRsharp = value
        End Set
    End Property

    Public Property ButtonSettings As RibbonButton
        Get
            Return _ButtonSettings
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonSettings = value
        End Set
    End Property

    Public Property ButtonAbout As RibbonButton
        Get
            Return _ButtonAbout
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonAbout = value
        End Set
    End Property

    Public Property ButtonBioDeep As RibbonButton
        Get
            Return _ButtonBioDeep
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonBioDeep = value
        End Set
    End Property

    Public Property ButtonLicense As RibbonButton
        Get
            Return _ButtonLicense
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonLicense = value
        End Set
    End Property

    Public Property MenuGroupExit As RibbonMenuGroup
        Get
            Return _MenuGroupExit
        End Get
        Private Set(ByVal value As RibbonMenuGroup)
            _MenuGroupExit = value
        End Set
    End Property

    Public Property ButtonExit As RibbonButton
        Get
            Return _ButtonExit
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonExit = value
        End Set
    End Property

    Public Property HelpButton As RibbonHelpButton
        Get
            Return _HelpButton
        End Get
        Private Set(ByVal value As RibbonHelpButton)
            _HelpButton = value
        End Set
    End Property

    Public Property QAT As RibbonQuickAccessToolbar
        Get
            Return _QAT
        End Get
        Private Set(ByVal value As RibbonQuickAccessToolbar)
            _QAT = value
        End Set
    End Property

    Public Property ButtonPageNavBack As RibbonButton
        Get
            Return _ButtonPageNavBack
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonPageNavBack = value
        End Set
    End Property

    Public Property ButtonOpenRaw As RibbonButton
        Get
            Return _ButtonOpenRaw
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonOpenRaw = value
        End Set
    End Property

    Public Property ButtonSave As RibbonButton
        Get
            Return _ButtonSave
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonSave = value
        End Set
    End Property

    Public Property TabGroupTableTools As RibbonTabGroup
        Get
            Return _TabGroupTableTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupTableTools = value
        End Set
    End Property

    Public Property TabDesign As RibbonTab
        Get
            Return _TabDesign
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabDesign = value
        End Set
    End Property

    Public Property GroupDesign As RibbonGroup
        Get
            Return _GroupDesign
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupDesign = value
        End Set
    End Property

    Public Property PPMSpinner As RibbonSpinner
        Get
            Return _PPMSpinner
        End Get
        Private Set(ByVal value As RibbonSpinner)
            _PPMSpinner = value
        End Set
    End Property

    Public Property GroupShowViewer As RibbonGroup
        Get
            Return _GroupShowViewer
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupShowViewer = value
        End Set
    End Property

    Public Property ButtonShowPlotViewer As RibbonButton
        Get
            Return _ButtonShowPlotViewer
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowPlotViewer = value
        End Set
    End Property

    Public Property ButtonShowMatrixViewer As RibbonButton
        Get
            Return _ButtonShowMatrixViewer
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowMatrixViewer = value
        End Set
    End Property

    Public Property GroupShowDockWindows As RibbonGroup
        Get
            Return _GroupShowDockWindows
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupShowDockWindows = value
        End Set
    End Property

    Public Property ButtonShowExplorer As RibbonButton
        Get
            Return _ButtonShowExplorer
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowExplorer = value
        End Set
    End Property

    Public Property ButtonShowSearchList As RibbonButton
        Get
            Return _ButtonShowSearchList
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowSearchList = value
        End Set
    End Property

    Public Property ButtonShowProperties As RibbonButton
        Get
            Return _ButtonShowProperties
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowProperties = value
        End Set
    End Property

    Public Property TabLayout As RibbonTab
        Get
            Return _TabLayout
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabLayout = value
        End Set
    End Property

    Public Property GroupLayout As RibbonGroup
        Get
            Return _GroupLayout
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupLayout = value
        End Set
    End Property

    Public Property ButtonLayout1 As RibbonButton
        Get
            Return _ButtonLayout1
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonLayout1 = value
        End Set
    End Property

    Public Property ButtonLayout2 As RibbonButton
        Get
            Return _ButtonLayout2
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonLayout2 = value
        End Set
    End Property

    Public Property GroupChromatography As RibbonGroup
        Get
            Return _GroupChromatography
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupChromatography = value
        End Set
    End Property

    Public Property ButtonBPC As RibbonButton
        Get
            Return _ButtonBPC
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonBPC = value
        End Set
    End Property

    Public Property ButtonTIC As RibbonButton
        Get
            Return _ButtonTIC
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonTIC = value
        End Set
    End Property

    Public Property ButtonXIC As RibbonButton
        Get
            Return _ButtonXIC
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonXIC = value
        End Set
    End Property

    Public Property PlotOptions As RibbonGroup
        Get
            Return _PlotOptions
        End Get
        Private Set(ByVal value As RibbonGroup)
            _PlotOptions = value
        End Set
    End Property

    Public Property CheckBoxXICRelative As RibbonCheckBox
        Get
            Return _CheckBoxXICRelative
        End Get
        Private Set(ByVal value As RibbonCheckBox)
            _CheckBoxXICRelative = value
        End Set
    End Property

    Public Property TabGroupCalculatorTools As RibbonTabGroup
        Get
            Return _TabGroupCalculatorTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupCalculatorTools = value
        End Set
    End Property

    Public Property TabCalculator As RibbonTab
        Get
            Return _TabCalculator
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabCalculator = value
        End Set
    End Property

    Public Property GroupCalculator As RibbonGroup
        Get
            Return _GroupCalculator
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupCalculator = value
        End Set
    End Property

    Public Property ButtonCalculatorExport As RibbonButton
        Get
            Return _ButtonCalculatorExport
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonCalculatorExport = value
        End Set
    End Property

    Public Property TabGroupRscriptTools As RibbonTabGroup
        Get
            Return _TabGroupRscriptTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupRscriptTools = value
        End Set
    End Property

    Public Property TabRscriptTools As RibbonTab
        Get
            Return _TabRscriptTools
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabRscriptTools = value
        End Set
    End Property

    Public Property GroupRscript As RibbonGroup
        Get
            Return _GroupRscript
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupRscript = value
        End Set
    End Property

    Public Property ButtonSaveScript As RibbonButton
        Get
            Return _ButtonSaveScript
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonSaveScript = value
        End Set
    End Property

    Public Property ButtonRunScript As RibbonButton
        Get
            Return _ButtonRunScript
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonRunScript = value
        End Set
    End Property

    Public Property TabGroupExactMassSearchTools As RibbonTabGroup
        Get
            Return _TabGroupExactMassSearchTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupExactMassSearchTools = value
        End Set
    End Property

    Public Property TabExactMassSearch As RibbonTab
        Get
            Return _TabExactMassSearch
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabExactMassSearch = value
        End Set
    End Property

    Public Property GroupExactMassSearch As RibbonGroup
        Get
            Return _GroupExactMassSearch
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupExactMassSearch = value
        End Set
    End Property

    Public Property ButtonExactMassSearchExport As RibbonButton
        Get
            Return _ButtonExactMassSearchExport
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonExactMassSearchExport = value
        End Set
    End Property

    Public Property TabGroupNetworkTools As RibbonTabGroup
        Get
            Return _TabGroupNetworkTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupNetworkTools = value
        End Set
    End Property

    Public Property TabNetwork As RibbonTab
        Get
            Return _TabNetwork
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabNetwork = value
        End Set
    End Property

    Public Property GroupNetwork As RibbonGroup
        Get
            Return _GroupNetwork
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupNetwork = value
        End Set
    End Property

    Public Property ButtonNetworkExport As RibbonButton
        Get
            Return _ButtonNetworkExport
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonNetworkExport = value
        End Set
    End Property

    Public Property ButtonNetworkRender As RibbonButton
        Get
            Return _ButtonNetworkRender
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonNetworkRender = value
        End Set
    End Property

    Public Property GroupNetworkTools As RibbonGroup
        Get
            Return _GroupNetworkTools
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupNetworkTools = value
        End Set
    End Property

    Public Property SpinnerSimilarity As RibbonSpinner
        Get
            Return _SpinnerSimilarity
        End Get
        Private Set(ByVal value As RibbonSpinner)
            _SpinnerSimilarity = value
        End Set
    End Property

    Public Property GroupNetworkRenderTool As RibbonGroup
        Get
            Return _GroupNetworkRenderTool
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupNetworkRenderTool = value
        End Set
    End Property

    Public Property ButtonRefreshNetwork As RibbonButton
        Get
            Return _ButtonRefreshNetwork
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonRefreshNetwork = value
        End Set
    End Property

    Public Property TabGroupFormulaSearchTools As RibbonTabGroup
        Get
            Return _TabGroupFormulaSearchTools
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TabGroupFormulaSearchTools = value
        End Set
    End Property

    Public Property TabFormulaSearch As RibbonTab
        Get
            Return _TabFormulaSearch
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabFormulaSearch = value
        End Set
    End Property

    Public Property GroupFormulaSearch As RibbonGroup
        Get
            Return _GroupFormulaSearch
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupFormulaSearch = value
        End Set
    End Property

    Public Property ButtonFormulaSearchExport As RibbonButton
        Get
            Return _ButtonFormulaSearchExport
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonFormulaSearchExport = value
        End Set
    End Property

    Public Property TargetedContex As RibbonTabGroup
        Get
            Return _TargetedContex
        End Get
        Private Set(ByVal value As RibbonTabGroup)
            _TargetedContex = value
        End Set
    End Property

    Public Property TabTargeted As RibbonTab
        Get
            Return _TabTargeted
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabTargeted = value
        End Set
    End Property

    Public Property TabGroupTargeted As RibbonGroup
        Get
            Return _TabGroupTargeted
        End Get
        Private Set(ByVal value As RibbonGroup)
            _TabGroupTargeted = value
        End Set
    End Property

    Public Property ImportsLinear As RibbonButton
        Get
            Return _ImportsLinear
        End Get
        Private Set(ByVal value As RibbonButton)
            _ImportsLinear = value
        End Set
    End Property

    Public Property TabMain As RibbonTab
        Get
            Return _TabMain
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabMain = value
        End Set
    End Property

    Public Property GroupFileActions As RibbonGroup
        Get
            Return _GroupFileActions
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupFileActions = value
        End Set
    End Property

    Public Property TabGroupWindowTools As RibbonGroup
        Get
            Return _TabGroupWindowTools
        End Get
        Private Set(ByVal value As RibbonGroup)
            _TabGroupWindowTools = value
        End Set
    End Property

    Public Property ButtonShowStartPage As RibbonButton
        Get
            Return _ButtonShowStartPage
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowStartPage = value
        End Set
    End Property

    Public Property ButtonShowLogWindow As RibbonButton
        Get
            Return _ButtonShowLogWindow
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowLogWindow = value
        End Set
    End Property

    Public Property ButtonResetLayout As RibbonButton
        Get
            Return _ButtonResetLayout
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonResetLayout = value
        End Set
    End Property

    Public Property TabTools As RibbonTab
        Get
            Return _TabTools
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabTools = value
        End Set
    End Property

    Public Property GroupToolsActions As RibbonGroup
        Get
            Return _GroupToolsActions
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupToolsActions = value
        End Set
    End Property

    Public Property ButtonMzCalculator As RibbonButton
        Get
            Return _ButtonMzCalculator
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonMzCalculator = value
        End Set
    End Property

    Public Property ButtonMzSearch As RibbonButton
        Get
            Return _ButtonMzSearch
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonMzSearch = value
        End Set
    End Property

    Public Property ButtonShowSpectrumSearchPage As RibbonButton
        Get
            Return _ButtonShowSpectrumSearchPage
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonShowSpectrumSearchPage = value
        End Set
    End Property

    Public Property Targeted As RibbonButton
        Get
            Return _Targeted
        End Get
        Private Set(ByVal value As RibbonButton)
            _Targeted = value
        End Set
    End Property

    Public Property TabAbout As RibbonTab
        Get
            Return _TabAbout
        End Get
        Private Set(ByVal value As RibbonTab)
            _TabAbout = value
        End Set
    End Property

    Public Property GroupAboutActions As RibbonGroup
        Get
            Return _GroupAboutActions
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupAboutActions = value
        End Set
    End Property

    Public Property GroupDemoActions As RibbonGroup
        Get
            Return _GroupDemoActions
        End Get
        Private Set(ByVal value As RibbonGroup)
            _GroupDemoActions = value
        End Set
    End Property

    Public Property ButtonMsDemo As RibbonButton
        Get
            Return _ButtonMsDemo
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonMsDemo = value
        End Set
    End Property

    Public Property FontControl As RibbonFontControl
        Get
            Return _FontControl
        End Get
        Private Set(ByVal value As RibbonFontControl)
            _FontControl = value
        End Set
    End Property

    Public Property LegendCheckBox As RibbonCheckBox
        Get
            Return _LegendCheckBox
        End Get
        Private Set(ByVal value As RibbonCheckBox)
            _LegendCheckBox = value
        End Set
    End Property

    Public Property TweaksImage As RibbonButton
        Get
            Return _TweaksImage
        End Get
        Private Set(ByVal value As RibbonButton)
            _TweaksImage = value
        End Set
    End Property

    Public Property ShowProperty As RibbonButton
        Get
            Return _ShowProperty
        End Get
        Private Set(ByVal value As RibbonButton)
            _ShowProperty = value
        End Set
    End Property

    Public Property GroupExport As RibbonDropDownButton
        Get
            Return _GroupExport
        End Get
        Private Set(ByVal value As RibbonDropDownButton)
            _GroupExport = value
        End Set
    End Property

    Public Property ButtonExportImage As RibbonButton
        Get
            Return _ButtonExportImage
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonExportImage = value
        End Set
    End Property

    Public Property ButtonExportMatrix As RibbonButton
        Get
            Return _ButtonExportMatrix
        End Get
        Private Set(ByVal value As RibbonButton)
            _ButtonExportMatrix = value
        End Set
    End Property

    Public Sub New(ByVal ribbon As Ribbon)
        If ribbon Is Nothing Then Throw New ArgumentNullException(NameOf(ribbon), "Parameter is null")
        Me.Ribbon = ribbon
        RecentItems = New RibbonRecentItems(ribbon, Cmd.cmdRecentItems)
        MenuGroupFile = New RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupFile)
        ButtonNew = New RibbonButton(ribbon, Cmd.cmdButtonNew)
        ButtonImportsRawFiles = New RibbonButton(ribbon, Cmd.cmdButtonImportsRawFiles)
        ButtonToolkits = New RibbonDropDownButton(ribbon, Cmd.cmdButtonToolkits)
        ButtonDropA = New RibbonButton(ribbon, Cmd.cmdButtonDropA)
        ButtonDropB = New RibbonButton(ribbon, Cmd.cmdButtonDropB)
        ButtonDropC = New RibbonButton(ribbon, Cmd.cmdButtonDropC)
        ButtonDropD = New RibbonButton(ribbon, Cmd.cmdButtonDropD)
        ButtonRsharp = New RibbonButton(ribbon, Cmd.cmdButtonRsharp)
        ButtonSettings = New RibbonButton(ribbon, Cmd.cmdButtonSettings)
        ButtonAbout = New RibbonButton(ribbon, Cmd.cmdButtonAbout)
        ButtonBioDeep = New RibbonButton(ribbon, Cmd.cmdButtonBioDeep)
        ButtonLicense = New RibbonButton(ribbon, Cmd.cmdButtonLicense)
        MenuGroupExit = New RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupExit)
        ButtonExit = New RibbonButton(ribbon, Cmd.cmdButtonExit)
        HelpButton = New RibbonHelpButton(ribbon, Cmd.cmdHelpButton)
        QAT = New RibbonQuickAccessToolbar(ribbon, Cmd.cmdQAT, Cmd.cmdCustomizeQAT)
        ButtonPageNavBack = New RibbonButton(ribbon, Cmd.cmdButtonPageNavBack)
        ButtonOpenRaw = New RibbonButton(ribbon, Cmd.cmdButtonOpenRaw)
        ButtonSave = New RibbonButton(ribbon, Cmd.cmdButtonSave)
        TabGroupTableTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupTableTools)
        TabDesign = New RibbonTab(ribbon, Cmd.cmdTabDesign)
        GroupDesign = New RibbonGroup(ribbon, Cmd.cmdGroupDesign)
        PPMSpinner = New RibbonSpinner(ribbon, Cmd.cmdPPMSpinner)
        GroupShowViewer = New RibbonGroup(ribbon, Cmd.cmdGroupShowViewer)
        ButtonShowPlotViewer = New RibbonButton(ribbon, Cmd.cmdButtonShowPlotViewer)
        ButtonShowMatrixViewer = New RibbonButton(ribbon, Cmd.cmdButtonShowMatrixViewer)
        GroupShowDockWindows = New RibbonGroup(ribbon, Cmd.cmdGroupShowDockWindows)
        ButtonShowExplorer = New RibbonButton(ribbon, Cmd.cmdButtonShowExplorer)
        ButtonShowSearchList = New RibbonButton(ribbon, Cmd.cmdButtonShowSearchList)
        ButtonShowProperties = New RibbonButton(ribbon, Cmd.cmdButtonShowProperties)
        TabLayout = New RibbonTab(ribbon, Cmd.cmdTabLayout)
        GroupLayout = New RibbonGroup(ribbon, Cmd.cmdGroupLayout)
        ButtonLayout1 = New RibbonButton(ribbon, Cmd.cmdButtonLayout1)
        ButtonLayout2 = New RibbonButton(ribbon, Cmd.cmdButtonLayout2)
        GroupChromatography = New RibbonGroup(ribbon, Cmd.cmdGroupChromatography)
        ButtonBPC = New RibbonButton(ribbon, Cmd.cmdButtonBPC)
        ButtonTIC = New RibbonButton(ribbon, Cmd.cmdButtonTIC)
        ButtonXIC = New RibbonButton(ribbon, Cmd.cmdButtonXIC)
        PlotOptions = New RibbonGroup(ribbon, Cmd.cmdPlotOptions)
        CheckBoxXICRelative = New RibbonCheckBox(ribbon, Cmd.cmdCheckBoxXICRelative)
        TabGroupCalculatorTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupCalculatorTools)
        TabCalculator = New RibbonTab(ribbon, Cmd.cmdTabCalculator)
        GroupCalculator = New RibbonGroup(ribbon, Cmd.cmdGroupCalculator)
        ButtonCalculatorExport = New RibbonButton(ribbon, Cmd.cmdButtonCalculatorExport)
        TabGroupRscriptTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupRscriptTools)
        TabRscriptTools = New RibbonTab(ribbon, Cmd.cmdTabRscriptTools)
        GroupRscript = New RibbonGroup(ribbon, Cmd.cmdGroupRscript)
        ButtonSaveScript = New RibbonButton(ribbon, Cmd.cmdButtonSaveScript)
        ButtonRunScript = New RibbonButton(ribbon, Cmd.cmdButtonRunScript)
        TabGroupExactMassSearchTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupExactMassSearchTools)
        TabExactMassSearch = New RibbonTab(ribbon, Cmd.cmdTabExactMassSearch)
        GroupExactMassSearch = New RibbonGroup(ribbon, Cmd.cmdGroupExactMassSearch)
        ButtonExactMassSearchExport = New RibbonButton(ribbon, Cmd.cmdButtonExactMassSearchExport)
        TabGroupNetworkTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupNetworkTools)
        TabNetwork = New RibbonTab(ribbon, Cmd.cmdTabNetwork)
        GroupNetwork = New RibbonGroup(ribbon, Cmd.cmdGroupNetwork)
        ButtonNetworkExport = New RibbonButton(ribbon, Cmd.cmdButtonNetworkExport)
        ButtonNetworkRender = New RibbonButton(ribbon, Cmd.cmdButtonNetworkRender)
        GroupNetworkTools = New RibbonGroup(ribbon, Cmd.cmdGroupNetworkTools)
        SpinnerSimilarity = New RibbonSpinner(ribbon, Cmd.cmdSpinnerSimilarity)
        GroupNetworkRenderTool = New RibbonGroup(ribbon, Cmd.cmdGroupNetworkRenderTool)
        ButtonRefreshNetwork = New RibbonButton(ribbon, Cmd.cmdButtonRefreshNetwork)
        TabGroupFormulaSearchTools = New RibbonTabGroup(ribbon, Cmd.cmdTabGroupFormulaSearchTools)
        TabFormulaSearch = New RibbonTab(ribbon, Cmd.cmdTabFormulaSearch)
        GroupFormulaSearch = New RibbonGroup(ribbon, Cmd.cmdGroupFormulaSearch)
        ButtonFormulaSearchExport = New RibbonButton(ribbon, Cmd.cmdButtonFormulaSearchExport)
        TargetedContex = New RibbonTabGroup(ribbon, Cmd.cmdTargetedContex)
        TabTargeted = New RibbonTab(ribbon, Cmd.cmdTabTargeted)
        TabGroupTargeted = New RibbonGroup(ribbon, Cmd.cmdTabGroupTargeted)
        ImportsLinear = New RibbonButton(ribbon, Cmd.cmdImportsLinear)
        TabMain = New RibbonTab(ribbon, Cmd.cmdTabMain)
        GroupFileActions = New RibbonGroup(ribbon, Cmd.cmdGroupFileActions)
        TabGroupWindowTools = New RibbonGroup(ribbon, Cmd.cmdTabGroupWindowTools)
        ButtonShowStartPage = New RibbonButton(ribbon, Cmd.cmdButtonShowStartPage)
        ButtonShowLogWindow = New RibbonButton(ribbon, Cmd.cmdButtonShowLogWindow)
        ButtonResetLayout = New RibbonButton(ribbon, Cmd.cmdButtonResetLayout)
        TabTools = New RibbonTab(ribbon, Cmd.cmdTabTools)
        GroupToolsActions = New RibbonGroup(ribbon, Cmd.cmdGroupToolsActions)
        ButtonMzCalculator = New RibbonButton(ribbon, Cmd.cmdButtonMzCalculator)
        ButtonMzSearch = New RibbonButton(ribbon, Cmd.cmdButtonMzSearch)
        ButtonShowSpectrumSearchPage = New RibbonButton(ribbon, Cmd.cmdButtonShowSpectrumSearchPage)
        Targeted = New RibbonButton(ribbon, Cmd.cmdTargeted)
        TabAbout = New RibbonTab(ribbon, Cmd.cmdTabAbout)
        GroupAboutActions = New RibbonGroup(ribbon, Cmd.cmdGroupAboutActions)
        GroupDemoActions = New RibbonGroup(ribbon, Cmd.cmdGroupDemoActions)
        ButtonMsDemo = New RibbonButton(ribbon, Cmd.cmdButtonMsDemo)
        FontControl = New RibbonFontControl(ribbon, Cmd.cmdFontControl)
        LegendCheckBox = New RibbonCheckBox(ribbon, Cmd.cmdLegendCheckBox)
        TweaksImage = New RibbonButton(ribbon, Cmd.cmdTweaksImage)
        ShowProperty = New RibbonButton(ribbon, Cmd.cmdShowProperty)
        GroupExport = New RibbonDropDownButton(ribbon, Cmd.cmdGroupExport)
        ButtonExportImage = New RibbonButton(ribbon, Cmd.cmdButtonExportImage)
        ButtonExportMatrix = New RibbonButton(ribbon, Cmd.cmdButtonExportMatrix)
    End Sub
End Class
