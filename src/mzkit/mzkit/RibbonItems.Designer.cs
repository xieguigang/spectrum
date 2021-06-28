//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using RibbonLib;
using RibbonLib.Controls;
using RibbonLib.Interop;

namespace RibbonLib.Controls
{
    partial class RibbonItems
    {
        private static class Cmd
        {
            public const uint cmdRecentItems = 1014;
            public const uint cmdMenuGroupFile = 1005;
            public const uint cmdButtonNew = 1001;
            public const uint cmdButtonImportsRawFiles = 1017;
            public const uint cmdButtonToolkits = 1007;
            public const uint cmdButtonDropA = 1008;
            public const uint cmdButtonDropB = 1009;
            public const uint cmdButtonFormulaSearch = 1010;
            public const uint cmdButtonDropD = 5010;
            public const uint cmdButtonRsharp = 1107;
            public const uint cmdButtonSettings = 1051;
            public const uint cmdButtonAbout = 1021;
            public const uint cmdButtonBioDeep = 1022;
            public const uint cmdButtonLicense = 1101;
            public const uint cmdMenuGroupExit = 1006;
            public const uint cmdButtonExit = 1004;
            public const uint cmdHelpButton = 1016;
            public const uint cmdQAT = 1015;
            public const uint cmdButtonPageNavBack = 1053;
            public const uint cmdButtonOpenRaw = 1002;
            public const uint cmdButtonSave = 1003;
            public const uint cmdTabGroupTableTools = 1031;
            public const uint cmdTabDesign = 1032;
            public const uint cmdGroupDesign = 1036;
            public const uint cmdPPMSpinner = 1050;
            public const uint cmdGroupShowViewer = 1110;
            public const uint cmdButtonShowPlotViewer = 1111;
            public const uint cmdButtonShowMatrixViewer = 1112;
            public const uint cmdGroupShowDockWindows = 1120;
            public const uint cmdExplorers = 114;
            public const uint cmdButtonShowExplorer = 1121;
            public const uint cmdShowGCMSExplorer = 113;
            public const uint cmdShowMRMExplorer = 118;
            public const uint cmdButtonMsImaging = 1167;
            public const uint cmdButtonShowSearchList = 1122;
            public const uint cmdButtonShowProperties = 1123;
            public const uint cmdTabLayout = 1035;
            public const uint cmdGroupLayout = 1037;
            public const uint cmdButtonLayout1 = 1043;
            public const uint cmdButtonLayout2 = 1044;
            public const uint cmdGroupChromatography = 1141;
            public const uint cmdButtonBPC = 1143;
            public const uint cmdButtonTIC = 1144;
            public const uint cmdButtonXIC = 1145;
            public const uint cmdPlotOptions = 97;
            public const uint cmdCheckBoxXICRelative = 96;
            public const uint cmdTabGroupCalculatorTools = 1061;
            public const uint cmdTabCalculator = 1062;
            public const uint cmdGroupCalculator = 1063;
            public const uint cmdButtonCalculatorExport = 1064;
            public const uint cmdTabGroupRscriptTools = 1130;
            public const uint cmdTabRscriptTools = 1131;
            public const uint cmdGroupRscript = 1132;
            public const uint cmdButtonSaveScript = 1134;
            public const uint cmdButtonRunScript = 1133;
            public const uint cmdTabRStudio = 111;
            public const uint cmdButtonInstallMzkitPackage = 112;
            public const uint cmdTabGroupExactMassSearchTools = 1071;
            public const uint cmdTabExactMassSearch = 1072;
            public const uint cmdGroupExactMassSearch = 1073;
            public const uint cmdButtonExactMassSearchExport = 1074;
            public const uint cmdTabGroupNetworkTools = 1081;
            public const uint cmdTabNetwork = 1082;
            public const uint cmdGroupNetwork = 1083;
            public const uint cmdButtonNetworkExport = 1084;
            public const uint cmdButtonNetworkRender = 1085;
            public const uint cmdGroupNetworkTools = 1151;
            public const uint cmdSpinnerSimilarity = 1153;
            public const uint cmdGroupNetworkRenderTool = 1150;
            public const uint cmdButtonRefreshNetwork = 1154;
            public const uint cmdTabGroupFormulaSearchTools = 1091;
            public const uint cmdTabFormulaSearch = 1092;
            public const uint cmdGroupFormulaSearch = 1093;
            public const uint cmdButtonFormulaSearchExport = 1094;
            public const uint cmdTargetedContex = 101;
            public const uint cmdTabTargeted = 102;
            public const uint cmdTabGroupTargeted = 98;
            public const uint cmdImportsLinear = 100;
            public const uint cmdSaveLinears = 103;
            public const uint cmdTabGroupTargetedLibrary = 107;
            public const uint cmdMRMLibrary = 108;
            public const uint cmdQuantifyIons = 109;
            public const uint cmdTagGroupParameterTool = 117;
            public const uint cmdAdjustParameters = 116;
            public const uint cmdTabGroupMSI = 120;
            public const uint cmdTabMSIPage = 121;
            public const uint cmdGroupMSIFile = 122;
            public const uint cmdButtonOpenMSIRaw = 119;
            public const uint cmdTabMSISnapshot = 126;
            public const uint cmdButtonMSITotalIon = 123;
            public const uint cmdButtonMSIBasePeakIon = 124;
            public const uint cmdButtonMSIAverageIon = 125;
            public const uint cmdTabMain = 1011;
            public const uint cmdGroupFileActions = 1045;
            public const uint cmdTabGroupWindowTools = 1023;
            public const uint cmdButtonShowStartPage = 1108;
            public const uint cmdButtonShowLogWindow = 1109;
            public const uint cmdButtonResetLayout = 1019;
            public const uint cmdTabGroupBioDeep = 105;
            public const uint cmdLogInBioDeep = 106;
            public const uint cmdTabTools = 1012;
            public const uint cmdGroupToolsActions = 1046;
            public const uint cmdButtonMzCalculator = 1013;
            public const uint cmdButtonMzSearch = 1052;
            public const uint cmdButtonShowSpectrumSearchPage = 1102;
            public const uint cmdTargeted = 99;
            public const uint cmdTabAbout = 1020;
            public const uint cmdGroupAboutActions = 1047;
            public const uint cmdTutorials = 115;
            public const uint cmdTabDemo = 110;
            public const uint cmdButtonMsDemo = 1168;
            public const uint cmdFontControl = 1165;
            public const uint cmdLegendCheckBox = 1166;
            public const uint cmdTweaksImage = 93;
            public const uint cmdShowProperty = 3;
            public const uint cmdGroupExport = 2;
            public const uint cmdButtonExportImage = 1104;
            public const uint cmdButtonExportMatrix = 1105;
            public const uint cmdContextMap = 1106;
            public const uint cmdCustomizeQAT = 1018;
        }

        // ContextPopup CommandName
        public const uint cmdContextMap = Cmd.cmdContextMap;

        public Ribbon Ribbon { get; private set; }
        public RibbonRecentItems RecentItems { get; private set; }
        public RibbonMenuGroup MenuGroupFile { get; private set; }
        public RibbonButton ButtonNew { get; private set; }
        public RibbonButton ButtonImportsRawFiles { get; private set; }
        public RibbonDropDownButton ButtonToolkits { get; private set; }
        public RibbonButton ButtonDropA { get; private set; }
        public RibbonButton ButtonDropB { get; private set; }
        public RibbonButton ButtonFormulaSearch { get; private set; }
        public RibbonButton ButtonDropD { get; private set; }
        public RibbonButton ButtonRsharp { get; private set; }
        public RibbonButton ButtonSettings { get; private set; }
        public RibbonButton ButtonAbout { get; private set; }
        public RibbonButton ButtonBioDeep { get; private set; }
        public RibbonButton ButtonLicense { get; private set; }
        public RibbonMenuGroup MenuGroupExit { get; private set; }
        public RibbonButton ButtonExit { get; private set; }
        public RibbonHelpButton HelpButton { get; private set; }
        public RibbonQuickAccessToolbar QAT { get; private set; }
        public RibbonButton ButtonPageNavBack { get; private set; }
        public RibbonButton ButtonOpenRaw { get; private set; }
        public RibbonButton ButtonSave { get; private set; }
        public RibbonTabGroup TabGroupTableTools { get; private set; }
        public RibbonTab TabDesign { get; private set; }
        public RibbonGroup GroupDesign { get; private set; }
        public RibbonSpinner PPMSpinner { get; private set; }
        public RibbonGroup GroupShowViewer { get; private set; }
        public RibbonButton ButtonShowPlotViewer { get; private set; }
        public RibbonButton ButtonShowMatrixViewer { get; private set; }
        public RibbonGroup GroupShowDockWindows { get; private set; }
        public RibbonSplitButtonGallery Explorers { get; private set; }
        public RibbonButton ButtonShowExplorer { get; private set; }
        public RibbonButton ShowGCMSExplorer { get; private set; }
        public RibbonButton ShowMRMExplorer { get; private set; }
        public RibbonButton ButtonMsImaging { get; private set; }
        public RibbonButton ButtonShowSearchList { get; private set; }
        public RibbonButton ButtonShowProperties { get; private set; }
        public RibbonTab TabLayout { get; private set; }
        public RibbonGroup GroupLayout { get; private set; }
        public RibbonButton ButtonLayout1 { get; private set; }
        public RibbonButton ButtonLayout2 { get; private set; }
        public RibbonGroup GroupChromatography { get; private set; }
        public RibbonButton ButtonBPC { get; private set; }
        public RibbonButton ButtonTIC { get; private set; }
        public RibbonButton ButtonXIC { get; private set; }
        public RibbonGroup PlotOptions { get; private set; }
        public RibbonCheckBox CheckBoxXICRelative { get; private set; }
        public RibbonTabGroup TabGroupCalculatorTools { get; private set; }
        public RibbonTab TabCalculator { get; private set; }
        public RibbonGroup GroupCalculator { get; private set; }
        public RibbonButton ButtonCalculatorExport { get; private set; }
        public RibbonTabGroup TabGroupRscriptTools { get; private set; }
        public RibbonTab TabRscriptTools { get; private set; }
        public RibbonGroup GroupRscript { get; private set; }
        public RibbonButton ButtonSaveScript { get; private set; }
        public RibbonButton ButtonRunScript { get; private set; }
        public RibbonGroup TabRStudio { get; private set; }
        public RibbonButton ButtonInstallMzkitPackage { get; private set; }
        public RibbonTabGroup TabGroupExactMassSearchTools { get; private set; }
        public RibbonTab TabExactMassSearch { get; private set; }
        public RibbonGroup GroupExactMassSearch { get; private set; }
        public RibbonButton ButtonExactMassSearchExport { get; private set; }
        public RibbonTabGroup TabGroupNetworkTools { get; private set; }
        public RibbonTab TabNetwork { get; private set; }
        public RibbonGroup GroupNetwork { get; private set; }
        public RibbonButton ButtonNetworkExport { get; private set; }
        public RibbonButton ButtonNetworkRender { get; private set; }
        public RibbonGroup GroupNetworkTools { get; private set; }
        public RibbonSpinner SpinnerSimilarity { get; private set; }
        public RibbonGroup GroupNetworkRenderTool { get; private set; }
        public RibbonButton ButtonRefreshNetwork { get; private set; }
        public RibbonTabGroup TabGroupFormulaSearchTools { get; private set; }
        public RibbonTab TabFormulaSearch { get; private set; }
        public RibbonGroup GroupFormulaSearch { get; private set; }
        public RibbonButton ButtonFormulaSearchExport { get; private set; }
        public RibbonTabGroup TargetedContex { get; private set; }
        public RibbonTab TabTargeted { get; private set; }
        public RibbonGroup TabGroupTargeted { get; private set; }
        public RibbonButton ImportsLinear { get; private set; }
        public RibbonButton SaveLinears { get; private set; }
        public RibbonGroup TabGroupTargetedLibrary { get; private set; }
        public RibbonButton MRMLibrary { get; private set; }
        public RibbonButton QuantifyIons { get; private set; }
        public RibbonGroup TagGroupParameterTool { get; private set; }
        public RibbonButton AdjustParameters { get; private set; }
        public RibbonTabGroup TabGroupMSI { get; private set; }
        public RibbonTab TabMSIPage { get; private set; }
        public RibbonGroup GroupMSIFile { get; private set; }
        public RibbonButton ButtonOpenMSIRaw { get; private set; }
        public RibbonGroup TabMSISnapshot { get; private set; }
        public RibbonButton ButtonMSITotalIon { get; private set; }
        public RibbonButton ButtonMSIBasePeakIon { get; private set; }
        public RibbonButton ButtonMSIAverageIon { get; private set; }
        public RibbonTab TabMain { get; private set; }
        public RibbonGroup GroupFileActions { get; private set; }
        public RibbonGroup TabGroupWindowTools { get; private set; }
        public RibbonButton ButtonShowStartPage { get; private set; }
        public RibbonButton ButtonShowLogWindow { get; private set; }
        public RibbonButton ButtonResetLayout { get; private set; }
        public RibbonGroup TabGroupBioDeep { get; private set; }
        public RibbonButton LogInBioDeep { get; private set; }
        public RibbonTab TabTools { get; private set; }
        public RibbonGroup GroupToolsActions { get; private set; }
        public RibbonButton ButtonMzCalculator { get; private set; }
        public RibbonButton ButtonMzSearch { get; private set; }
        public RibbonButton ButtonShowSpectrumSearchPage { get; private set; }
        public RibbonButton Targeted { get; private set; }
        public RibbonTab TabAbout { get; private set; }
        public RibbonGroup GroupAboutActions { get; private set; }
        public RibbonButton Tutorials { get; private set; }
        public RibbonGroup TabDemo { get; private set; }
        public RibbonButton ButtonMsDemo { get; private set; }
        public RibbonFontControl FontControl { get; private set; }
        public RibbonCheckBox LegendCheckBox { get; private set; }
        public RibbonButton TweaksImage { get; private set; }
        public RibbonButton ShowProperty { get; private set; }
        public RibbonDropDownButton GroupExport { get; private set; }
        public RibbonButton ButtonExportImage { get; private set; }
        public RibbonButton ButtonExportMatrix { get; private set; }

        public RibbonItems(Ribbon ribbon)
        {
            if (ribbon == null)
                throw new ArgumentNullException(nameof(ribbon), "Parameter is null");
            this.Ribbon = ribbon;
            RecentItems = new RibbonRecentItems(ribbon, Cmd.cmdRecentItems);
            MenuGroupFile = new RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupFile);
            ButtonNew = new RibbonButton(ribbon, Cmd.cmdButtonNew);
            ButtonImportsRawFiles = new RibbonButton(ribbon, Cmd.cmdButtonImportsRawFiles);
            ButtonToolkits = new RibbonDropDownButton(ribbon, Cmd.cmdButtonToolkits);
            ButtonDropA = new RibbonButton(ribbon, Cmd.cmdButtonDropA);
            ButtonDropB = new RibbonButton(ribbon, Cmd.cmdButtonDropB);
            ButtonFormulaSearch = new RibbonButton(ribbon, Cmd.cmdButtonFormulaSearch);
            ButtonDropD = new RibbonButton(ribbon, Cmd.cmdButtonDropD);
            ButtonRsharp = new RibbonButton(ribbon, Cmd.cmdButtonRsharp);
            ButtonSettings = new RibbonButton(ribbon, Cmd.cmdButtonSettings);
            ButtonAbout = new RibbonButton(ribbon, Cmd.cmdButtonAbout);
            ButtonBioDeep = new RibbonButton(ribbon, Cmd.cmdButtonBioDeep);
            ButtonLicense = new RibbonButton(ribbon, Cmd.cmdButtonLicense);
            MenuGroupExit = new RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupExit);
            ButtonExit = new RibbonButton(ribbon, Cmd.cmdButtonExit);
            HelpButton = new RibbonHelpButton(ribbon, Cmd.cmdHelpButton);
            QAT = new RibbonQuickAccessToolbar(ribbon, Cmd.cmdQAT, Cmd.cmdCustomizeQAT);
            ButtonPageNavBack = new RibbonButton(ribbon, Cmd.cmdButtonPageNavBack);
            ButtonOpenRaw = new RibbonButton(ribbon, Cmd.cmdButtonOpenRaw);
            ButtonSave = new RibbonButton(ribbon, Cmd.cmdButtonSave);
            TabGroupTableTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupTableTools);
            TabDesign = new RibbonTab(ribbon, Cmd.cmdTabDesign);
            GroupDesign = new RibbonGroup(ribbon, Cmd.cmdGroupDesign);
            PPMSpinner = new RibbonSpinner(ribbon, Cmd.cmdPPMSpinner);
            GroupShowViewer = new RibbonGroup(ribbon, Cmd.cmdGroupShowViewer);
            ButtonShowPlotViewer = new RibbonButton(ribbon, Cmd.cmdButtonShowPlotViewer);
            ButtonShowMatrixViewer = new RibbonButton(ribbon, Cmd.cmdButtonShowMatrixViewer);
            GroupShowDockWindows = new RibbonGroup(ribbon, Cmd.cmdGroupShowDockWindows);
            Explorers = new RibbonSplitButtonGallery(ribbon, Cmd.cmdExplorers);
            ButtonShowExplorer = new RibbonButton(ribbon, Cmd.cmdButtonShowExplorer);
            ShowGCMSExplorer = new RibbonButton(ribbon, Cmd.cmdShowGCMSExplorer);
            ShowMRMExplorer = new RibbonButton(ribbon, Cmd.cmdShowMRMExplorer);
            ButtonMsImaging = new RibbonButton(ribbon, Cmd.cmdButtonMsImaging);
            ButtonShowSearchList = new RibbonButton(ribbon, Cmd.cmdButtonShowSearchList);
            ButtonShowProperties = new RibbonButton(ribbon, Cmd.cmdButtonShowProperties);
            TabLayout = new RibbonTab(ribbon, Cmd.cmdTabLayout);
            GroupLayout = new RibbonGroup(ribbon, Cmd.cmdGroupLayout);
            ButtonLayout1 = new RibbonButton(ribbon, Cmd.cmdButtonLayout1);
            ButtonLayout2 = new RibbonButton(ribbon, Cmd.cmdButtonLayout2);
            GroupChromatography = new RibbonGroup(ribbon, Cmd.cmdGroupChromatography);
            ButtonBPC = new RibbonButton(ribbon, Cmd.cmdButtonBPC);
            ButtonTIC = new RibbonButton(ribbon, Cmd.cmdButtonTIC);
            ButtonXIC = new RibbonButton(ribbon, Cmd.cmdButtonXIC);
            PlotOptions = new RibbonGroup(ribbon, Cmd.cmdPlotOptions);
            CheckBoxXICRelative = new RibbonCheckBox(ribbon, Cmd.cmdCheckBoxXICRelative);
            TabGroupCalculatorTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupCalculatorTools);
            TabCalculator = new RibbonTab(ribbon, Cmd.cmdTabCalculator);
            GroupCalculator = new RibbonGroup(ribbon, Cmd.cmdGroupCalculator);
            ButtonCalculatorExport = new RibbonButton(ribbon, Cmd.cmdButtonCalculatorExport);
            TabGroupRscriptTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupRscriptTools);
            TabRscriptTools = new RibbonTab(ribbon, Cmd.cmdTabRscriptTools);
            GroupRscript = new RibbonGroup(ribbon, Cmd.cmdGroupRscript);
            ButtonSaveScript = new RibbonButton(ribbon, Cmd.cmdButtonSaveScript);
            ButtonRunScript = new RibbonButton(ribbon, Cmd.cmdButtonRunScript);
            TabRStudio = new RibbonGroup(ribbon, Cmd.cmdTabRStudio);
            ButtonInstallMzkitPackage = new RibbonButton(ribbon, Cmd.cmdButtonInstallMzkitPackage);
            TabGroupExactMassSearchTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupExactMassSearchTools);
            TabExactMassSearch = new RibbonTab(ribbon, Cmd.cmdTabExactMassSearch);
            GroupExactMassSearch = new RibbonGroup(ribbon, Cmd.cmdGroupExactMassSearch);
            ButtonExactMassSearchExport = new RibbonButton(ribbon, Cmd.cmdButtonExactMassSearchExport);
            TabGroupNetworkTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupNetworkTools);
            TabNetwork = new RibbonTab(ribbon, Cmd.cmdTabNetwork);
            GroupNetwork = new RibbonGroup(ribbon, Cmd.cmdGroupNetwork);
            ButtonNetworkExport = new RibbonButton(ribbon, Cmd.cmdButtonNetworkExport);
            ButtonNetworkRender = new RibbonButton(ribbon, Cmd.cmdButtonNetworkRender);
            GroupNetworkTools = new RibbonGroup(ribbon, Cmd.cmdGroupNetworkTools);
            SpinnerSimilarity = new RibbonSpinner(ribbon, Cmd.cmdSpinnerSimilarity);
            GroupNetworkRenderTool = new RibbonGroup(ribbon, Cmd.cmdGroupNetworkRenderTool);
            ButtonRefreshNetwork = new RibbonButton(ribbon, Cmd.cmdButtonRefreshNetwork);
            TabGroupFormulaSearchTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupFormulaSearchTools);
            TabFormulaSearch = new RibbonTab(ribbon, Cmd.cmdTabFormulaSearch);
            GroupFormulaSearch = new RibbonGroup(ribbon, Cmd.cmdGroupFormulaSearch);
            ButtonFormulaSearchExport = new RibbonButton(ribbon, Cmd.cmdButtonFormulaSearchExport);
            TargetedContex = new RibbonTabGroup(ribbon, Cmd.cmdTargetedContex);
            TabTargeted = new RibbonTab(ribbon, Cmd.cmdTabTargeted);
            TabGroupTargeted = new RibbonGroup(ribbon, Cmd.cmdTabGroupTargeted);
            ImportsLinear = new RibbonButton(ribbon, Cmd.cmdImportsLinear);
            SaveLinears = new RibbonButton(ribbon, Cmd.cmdSaveLinears);
            TabGroupTargetedLibrary = new RibbonGroup(ribbon, Cmd.cmdTabGroupTargetedLibrary);
            MRMLibrary = new RibbonButton(ribbon, Cmd.cmdMRMLibrary);
            QuantifyIons = new RibbonButton(ribbon, Cmd.cmdQuantifyIons);
            TagGroupParameterTool = new RibbonGroup(ribbon, Cmd.cmdTagGroupParameterTool);
            AdjustParameters = new RibbonButton(ribbon, Cmd.cmdAdjustParameters);
            TabGroupMSI = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupMSI);
            TabMSIPage = new RibbonTab(ribbon, Cmd.cmdTabMSIPage);
            GroupMSIFile = new RibbonGroup(ribbon, Cmd.cmdGroupMSIFile);
            ButtonOpenMSIRaw = new RibbonButton(ribbon, Cmd.cmdButtonOpenMSIRaw);
            TabMSISnapshot = new RibbonGroup(ribbon, Cmd.cmdTabMSISnapshot);
            ButtonMSITotalIon = new RibbonButton(ribbon, Cmd.cmdButtonMSITotalIon);
            ButtonMSIBasePeakIon = new RibbonButton(ribbon, Cmd.cmdButtonMSIBasePeakIon);
            ButtonMSIAverageIon = new RibbonButton(ribbon, Cmd.cmdButtonMSIAverageIon);
            TabMain = new RibbonTab(ribbon, Cmd.cmdTabMain);
            GroupFileActions = new RibbonGroup(ribbon, Cmd.cmdGroupFileActions);
            TabGroupWindowTools = new RibbonGroup(ribbon, Cmd.cmdTabGroupWindowTools);
            ButtonShowStartPage = new RibbonButton(ribbon, Cmd.cmdButtonShowStartPage);
            ButtonShowLogWindow = new RibbonButton(ribbon, Cmd.cmdButtonShowLogWindow);
            ButtonResetLayout = new RibbonButton(ribbon, Cmd.cmdButtonResetLayout);
            TabGroupBioDeep = new RibbonGroup(ribbon, Cmd.cmdTabGroupBioDeep);
            LogInBioDeep = new RibbonButton(ribbon, Cmd.cmdLogInBioDeep);
            TabTools = new RibbonTab(ribbon, Cmd.cmdTabTools);
            GroupToolsActions = new RibbonGroup(ribbon, Cmd.cmdGroupToolsActions);
            ButtonMzCalculator = new RibbonButton(ribbon, Cmd.cmdButtonMzCalculator);
            ButtonMzSearch = new RibbonButton(ribbon, Cmd.cmdButtonMzSearch);
            ButtonShowSpectrumSearchPage = new RibbonButton(ribbon, Cmd.cmdButtonShowSpectrumSearchPage);
            Targeted = new RibbonButton(ribbon, Cmd.cmdTargeted);
            TabAbout = new RibbonTab(ribbon, Cmd.cmdTabAbout);
            GroupAboutActions = new RibbonGroup(ribbon, Cmd.cmdGroupAboutActions);
            Tutorials = new RibbonButton(ribbon, Cmd.cmdTutorials);
            TabDemo = new RibbonGroup(ribbon, Cmd.cmdTabDemo);
            ButtonMsDemo = new RibbonButton(ribbon, Cmd.cmdButtonMsDemo);
            FontControl = new RibbonFontControl(ribbon, Cmd.cmdFontControl);
            LegendCheckBox = new RibbonCheckBox(ribbon, Cmd.cmdLegendCheckBox);
            TweaksImage = new RibbonButton(ribbon, Cmd.cmdTweaksImage);
            ShowProperty = new RibbonButton(ribbon, Cmd.cmdShowProperty);
            GroupExport = new RibbonDropDownButton(ribbon, Cmd.cmdGroupExport);
            ButtonExportImage = new RibbonButton(ribbon, Cmd.cmdButtonExportImage);
            ButtonExportMatrix = new RibbonButton(ribbon, Cmd.cmdButtonExportMatrix);
        }

    }
}
