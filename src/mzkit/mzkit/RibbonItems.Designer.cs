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


    partial class RibbonItems
    {
        private static class Cmd
        {
            public const uint cmdTabGroupTableTools = 1031;
            public const uint cmdTabDesign = 1032;
            public const uint cmdGroupDesign = 1036;
            public const uint cmdSpinner = 1050;
            public const uint cmdButtonDesign2 = 1041;
            public const uint cmdButtonDesign3 = 1042;
            public const uint cmdTabLayout = 1035;
            public const uint cmdGroupLayout = 1037;
            public const uint cmdButtonLayout1 = 1043;
            public const uint cmdButtonLayout2 = 1044;
            public const uint cmdTabGroupCalculatorTools = 1061;
            public const uint cmdTabCalculator = 1062;
            public const uint cmdGroupCalculator = 1063;
            public const uint cmdButtonCalculatorExport = 1064;
            public const uint cmdTabGroupExactMassSearchTools = 1071;
            public const uint cmdTabExactMassSearch = 1072;
            public const uint cmdGroupExactMassSearch = 1073;
            public const uint cmdButtonExactMassSearchExport = 1074;
            public const uint cmdTabGroupNetworkTools = 1081;
            public const uint cmdTabNetwork = 1082;
            public const uint cmdGroupNetwork = 1083;
            public const uint cmdButtonNetworkExport = 1084;
            public const uint cmdButtonNetworkRender = 1085;
            public const uint cmdTabGroupFormulaSearchTools = 1091;
            public const uint cmdTabFormulaSearch = 1092;
            public const uint cmdGroupFormulaSearch = 1093;
            public const uint cmdButtonFormulaSearchExport = 1094;
            public const uint cmdGroupFormulaSearchConfig2 = 1095;
            public const uint cmdComboFormulaSearchProfile3 = 1099;
            public const uint cmdHelpButton = 1016;
            public const uint cmdTabMain = 1011;
            public const uint cmdGroupFileActions = 1045;
            public const uint cmdButtonNew = 1001;
            public const uint cmdButtonOpenRaw = 1002;
            public const uint cmdButtonSave = 1003;
            public const uint cmdButtonExit = 1004;
            public const uint cmdTabTools = 1012;
            public const uint cmdGroupToolsActions = 1046;
            public const uint cmdButtonMzCalculator = 1013;
            public const uint cmdButtonMzSearch = 1052;
            public const uint cmdTabAbout = 1020;
            public const uint cmdGroupAboutActions = 1047;
            public const uint cmdButtonAbout = 1021;
            public const uint cmdButtonSettings = 1051;
            public const uint cmdRecentItems = 1014;
            public const uint cmdMenuGroupFile = 1005;
            public const uint cmdButtonOpen = 1007;
            public const uint cmdButtonDropA = 1008;
            public const uint cmdButtonDropB = 1009;
            public const uint cmdButtonDropC = 1010;
            public const uint cmdMenuGroupExit = 1006;
            public const uint cmdQAT = 1015;
            public const uint cmdButtonPageNavBack = 1053;
            public const uint cmdCustomizeQAT = 1018;
        }

        // ContextPopup CommandName

        private static bool initialized;

        public Ribbon Ribbon { get; private set; }
        public RibbonTabGroup TabGroupTableTools { get; private set; }
        public RibbonTab TabDesign { get; private set; }
        public RibbonGroup GroupDesign { get; private set; }
        public RibbonSpinner Spinner { get; private set; }
        public RibbonButton ButtonDesign2 { get; private set; }
        public RibbonButton ButtonDesign3 { get; private set; }
        public RibbonTab TabLayout { get; private set; }
        public RibbonGroup GroupLayout { get; private set; }
        public RibbonButton ButtonLayout1 { get; private set; }
        public RibbonButton ButtonLayout2 { get; private set; }
        public RibbonTabGroup TabGroupCalculatorTools { get; private set; }
        public RibbonTab TabCalculator { get; private set; }
        public RibbonGroup GroupCalculator { get; private set; }
        public RibbonButton ButtonCalculatorExport { get; private set; }
        public RibbonTabGroup TabGroupExactMassSearchTools { get; private set; }
        public RibbonTab TabExactMassSearch { get; private set; }
        public RibbonGroup GroupExactMassSearch { get; private set; }
        public RibbonButton ButtonExactMassSearchExport { get; private set; }
        public RibbonTabGroup TabGroupNetworkTools { get; private set; }
        public RibbonTab TabNetwork { get; private set; }
        public RibbonGroup GroupNetwork { get; private set; }
        public RibbonButton ButtonNetworkExport { get; private set; }
        public RibbonButton ButtonNetworkRender { get; private set; }
        public RibbonTabGroup TabGroupFormulaSearchTools { get; private set; }
        public RibbonTab TabFormulaSearch { get; private set; }
        public RibbonGroup GroupFormulaSearch { get; private set; }
        public RibbonButton ButtonFormulaSearchExport { get; private set; }
        public RibbonGroup GroupFormulaSearchConfig2 { get; private set; }
        public RibbonComboBox ComboFormulaSearchProfile3 { get; private set; }
        public RibbonHelpButton HelpButton { get; private set; }
        public RibbonTab TabMain { get; private set; }
        public RibbonGroup GroupFileActions { get; private set; }
        public RibbonButton ButtonNew { get; private set; }
        public RibbonButton ButtonOpenRaw { get; private set; }
        public RibbonButton ButtonSave { get; private set; }
        public RibbonButton ButtonExit { get; private set; }
        public RibbonTab TabTools { get; private set; }
        public RibbonGroup GroupToolsActions { get; private set; }
        public RibbonButton ButtonMzCalculator { get; private set; }
        public RibbonButton ButtonMzSearch { get; private set; }
        public RibbonTab TabAbout { get; private set; }
        public RibbonGroup GroupAboutActions { get; private set; }
        public RibbonButton ButtonAbout { get; private set; }
        public RibbonButton ButtonSettings { get; private set; }
        public RibbonRecentItems RecentItems { get; private set; }
        public RibbonMenuGroup MenuGroupFile { get; private set; }
        public RibbonDropDownButton ButtonOpen { get; private set; }
        public RibbonButton ButtonDropA { get; private set; }
        public RibbonButton ButtonDropB { get; private set; }
        public RibbonButton ButtonDropC { get; private set; }
        public RibbonMenuGroup MenuGroupExit { get; private set; }
        public RibbonQuickAccessToolbar QAT { get; private set; }
        public RibbonButton ButtonPageNavBack { get; private set; }

        public RibbonItems(Ribbon ribbon)
        {
            if (ribbon == null)
                throw new ArgumentNullException(nameof(ribbon), "Parameter is null");
            if (initialized)
                return;
            this.Ribbon = ribbon;
            TabGroupTableTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupTableTools);
            TabDesign = new RibbonTab(ribbon, Cmd.cmdTabDesign);
            GroupDesign = new RibbonGroup(ribbon, Cmd.cmdGroupDesign);
            Spinner = new RibbonSpinner(ribbon, Cmd.cmdSpinner);
            ButtonDesign2 = new RibbonButton(ribbon, Cmd.cmdButtonDesign2);
            ButtonDesign3 = new RibbonButton(ribbon, Cmd.cmdButtonDesign3);
            TabLayout = new RibbonTab(ribbon, Cmd.cmdTabLayout);
            GroupLayout = new RibbonGroup(ribbon, Cmd.cmdGroupLayout);
            ButtonLayout1 = new RibbonButton(ribbon, Cmd.cmdButtonLayout1);
            ButtonLayout2 = new RibbonButton(ribbon, Cmd.cmdButtonLayout2);
            TabGroupCalculatorTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupCalculatorTools);
            TabCalculator = new RibbonTab(ribbon, Cmd.cmdTabCalculator);
            GroupCalculator = new RibbonGroup(ribbon, Cmd.cmdGroupCalculator);
            ButtonCalculatorExport = new RibbonButton(ribbon, Cmd.cmdButtonCalculatorExport);
            TabGroupExactMassSearchTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupExactMassSearchTools);
            TabExactMassSearch = new RibbonTab(ribbon, Cmd.cmdTabExactMassSearch);
            GroupExactMassSearch = new RibbonGroup(ribbon, Cmd.cmdGroupExactMassSearch);
            ButtonExactMassSearchExport = new RibbonButton(ribbon, Cmd.cmdButtonExactMassSearchExport);
            TabGroupNetworkTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupNetworkTools);
            TabNetwork = new RibbonTab(ribbon, Cmd.cmdTabNetwork);
            GroupNetwork = new RibbonGroup(ribbon, Cmd.cmdGroupNetwork);
            ButtonNetworkExport = new RibbonButton(ribbon, Cmd.cmdButtonNetworkExport);
            ButtonNetworkRender = new RibbonButton(ribbon, Cmd.cmdButtonNetworkRender);
            TabGroupFormulaSearchTools = new RibbonTabGroup(ribbon, Cmd.cmdTabGroupFormulaSearchTools);
            TabFormulaSearch = new RibbonTab(ribbon, Cmd.cmdTabFormulaSearch);
            GroupFormulaSearch = new RibbonGroup(ribbon, Cmd.cmdGroupFormulaSearch);
            ButtonFormulaSearchExport = new RibbonButton(ribbon, Cmd.cmdButtonFormulaSearchExport);
            GroupFormulaSearchConfig2 = new RibbonGroup(ribbon, Cmd.cmdGroupFormulaSearchConfig2);
            ComboFormulaSearchProfile3 = new RibbonComboBox(ribbon, Cmd.cmdComboFormulaSearchProfile3);
            HelpButton = new RibbonHelpButton(ribbon, Cmd.cmdHelpButton);
            TabMain = new RibbonTab(ribbon, Cmd.cmdTabMain);
            GroupFileActions = new RibbonGroup(ribbon, Cmd.cmdGroupFileActions);
            ButtonNew = new RibbonButton(ribbon, Cmd.cmdButtonNew);
            ButtonOpenRaw = new RibbonButton(ribbon, Cmd.cmdButtonOpenRaw);
            ButtonSave = new RibbonButton(ribbon, Cmd.cmdButtonSave);
            ButtonExit = new RibbonButton(ribbon, Cmd.cmdButtonExit);
            TabTools = new RibbonTab(ribbon, Cmd.cmdTabTools);
            GroupToolsActions = new RibbonGroup(ribbon, Cmd.cmdGroupToolsActions);
            ButtonMzCalculator = new RibbonButton(ribbon, Cmd.cmdButtonMzCalculator);
            ButtonMzSearch = new RibbonButton(ribbon, Cmd.cmdButtonMzSearch);
            TabAbout = new RibbonTab(ribbon, Cmd.cmdTabAbout);
            GroupAboutActions = new RibbonGroup(ribbon, Cmd.cmdGroupAboutActions);
            ButtonAbout = new RibbonButton(ribbon, Cmd.cmdButtonAbout);
            ButtonSettings = new RibbonButton(ribbon, Cmd.cmdButtonSettings);
            RecentItems = new RibbonRecentItems(ribbon, Cmd.cmdRecentItems);
            MenuGroupFile = new RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupFile);
            ButtonOpen = new RibbonDropDownButton(ribbon, Cmd.cmdButtonOpen);
            ButtonDropA = new RibbonButton(ribbon, Cmd.cmdButtonDropA);
            ButtonDropB = new RibbonButton(ribbon, Cmd.cmdButtonDropB);
            ButtonDropC = new RibbonButton(ribbon, Cmd.cmdButtonDropC);
            MenuGroupExit = new RibbonMenuGroup(ribbon, Cmd.cmdMenuGroupExit);
            QAT = new RibbonQuickAccessToolbar(ribbon, Cmd.cmdQAT, Cmd.cmdCustomizeQAT);
            ButtonPageNavBack = new RibbonButton(ribbon, Cmd.cmdButtonPageNavBack);
            initialized = true;
        }

    }
