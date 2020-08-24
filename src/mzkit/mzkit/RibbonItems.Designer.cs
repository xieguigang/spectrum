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
        initialized = true;
    }

}