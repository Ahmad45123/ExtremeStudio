using System.ComponentModel;
using System.Windows.Forms;
using exscape;
using ExtremeCore.Controls_And_Tools;

namespace ExtremeStudio.FunctionsForms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.GotoDefHotkey = new exscape.HotkeyControl();
            this.label19 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.BuildHotkey = new exscape.HotkeyControl();
            this.Label18 = new System.Windows.Forms.Label();
            this.GotoBeforeHotkey = new exscape.HotkeyControl();
            this.Label17 = new System.Windows.Forms.Label();
            this.GotoNextHotkey = new exscape.HotkeyControl();
            this.Label16 = new System.Windows.Forms.Label();
            this.ReplaceHotkey = new exscape.HotkeyControl();
            this.Label15 = new System.Windows.Forms.Label();
            this.SearchHotkey = new exscape.HotkeyControl();
            this.Label14 = new System.Windows.Forms.Label();
            this.GotoHotkey = new exscape.HotkeyControl();
            this.Label13 = new System.Windows.Forms.Label();
            this.SaveAllHotkey = new exscape.HotkeyControl();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.SaveHotkey = new exscape.HotkeyControl();
            this.Label10 = new System.Windows.Forms.Label();
            this.ResetLangBtn = new System.Windows.Forms.Button();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.resetBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.colorsSettings = new System.Windows.Forms.PropertyGrid();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Button1 = new System.Windows.Forms.Button();
            this.customArgsText = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.parenthesesCheck = new System.Windows.Forms.CheckBox();
            this.semiColonCheck = new System.Windows.Forms.CheckBox();
            this.skipLinesUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label8 = new System.Windows.Forms.Label();
            this.tabSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.optiLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label5 = new System.Windows.Forms.Label();
            this.debugLevelUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.reportGenDirText = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.reportGenCheck = new System.Windows.Forms.CheckBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.ouputDirText = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.includesDirText = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.activeDirText = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.serverCFGTabPage = new System.Windows.Forms.TabPage();
            this.serverCfgGrid = new System.Windows.Forms.DataGridView();
            this.ToolTipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skipLinesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optiLevelUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugLevelUpDown)).BeginInit();
            this.serverCFGTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverCfgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.serverCFGTabPage);
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.GotoDefHotkey);
            this.TabPage3.Controls.Add(this.label19);
            this.TabPage3.Controls.Add(this.Button2);
            this.TabPage3.Controls.Add(this.BuildHotkey);
            this.TabPage3.Controls.Add(this.Label18);
            this.TabPage3.Controls.Add(this.GotoBeforeHotkey);
            this.TabPage3.Controls.Add(this.Label17);
            this.TabPage3.Controls.Add(this.GotoNextHotkey);
            this.TabPage3.Controls.Add(this.Label16);
            this.TabPage3.Controls.Add(this.ReplaceHotkey);
            this.TabPage3.Controls.Add(this.Label15);
            this.TabPage3.Controls.Add(this.SearchHotkey);
            this.TabPage3.Controls.Add(this.Label14);
            this.TabPage3.Controls.Add(this.GotoHotkey);
            this.TabPage3.Controls.Add(this.Label13);
            this.TabPage3.Controls.Add(this.SaveAllHotkey);
            this.TabPage3.Controls.Add(this.Label12);
            this.TabPage3.Controls.Add(this.Label11);
            this.TabPage3.Controls.Add(this.SaveHotkey);
            this.TabPage3.Controls.Add(this.Label10);
            this.TabPage3.Controls.Add(this.ResetLangBtn);
            resources.ApplyResources(this.TabPage3, "TabPage3");
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // GotoDefHotkey
            // 
            this.GotoDefHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.GotoDefHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.GotoDefHotkey, "GotoDefHotkey");
            this.GotoDefHotkey.Name = "GotoDefHotkey";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // Button2
            // 
            resources.ApplyResources(this.Button2, "Button2");
            this.Button2.Name = "Button2";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // BuildHotkey
            // 
            this.BuildHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.BuildHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.BuildHotkey, "BuildHotkey");
            this.BuildHotkey.Name = "BuildHotkey";
            // 
            // Label18
            // 
            resources.ApplyResources(this.Label18, "Label18");
            this.Label18.Name = "Label18";
            // 
            // GotoBeforeHotkey
            // 
            this.GotoBeforeHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.GotoBeforeHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.GotoBeforeHotkey, "GotoBeforeHotkey");
            this.GotoBeforeHotkey.Name = "GotoBeforeHotkey";
            // 
            // Label17
            // 
            resources.ApplyResources(this.Label17, "Label17");
            this.Label17.Name = "Label17";
            // 
            // GotoNextHotkey
            // 
            this.GotoNextHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.GotoNextHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.GotoNextHotkey, "GotoNextHotkey");
            this.GotoNextHotkey.Name = "GotoNextHotkey";
            // 
            // Label16
            // 
            resources.ApplyResources(this.Label16, "Label16");
            this.Label16.Name = "Label16";
            // 
            // ReplaceHotkey
            // 
            this.ReplaceHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.ReplaceHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.ReplaceHotkey, "ReplaceHotkey");
            this.ReplaceHotkey.Name = "ReplaceHotkey";
            // 
            // Label15
            // 
            resources.ApplyResources(this.Label15, "Label15");
            this.Label15.Name = "Label15";
            // 
            // SearchHotkey
            // 
            this.SearchHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.SearchHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.SearchHotkey, "SearchHotkey");
            this.SearchHotkey.Name = "SearchHotkey";
            // 
            // Label14
            // 
            resources.ApplyResources(this.Label14, "Label14");
            this.Label14.Name = "Label14";
            // 
            // GotoHotkey
            // 
            this.GotoHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.GotoHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.GotoHotkey, "GotoHotkey");
            this.GotoHotkey.Name = "GotoHotkey";
            // 
            // Label13
            // 
            resources.ApplyResources(this.Label13, "Label13");
            this.Label13.Name = "Label13";
            // 
            // SaveAllHotkey
            // 
            this.SaveAllHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.SaveAllHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.SaveAllHotkey, "SaveAllHotkey");
            this.SaveAllHotkey.Name = "SaveAllHotkey";
            // 
            // Label12
            // 
            resources.ApplyResources(this.Label12, "Label12");
            this.Label12.Name = "Label12";
            // 
            // Label11
            // 
            resources.ApplyResources(this.Label11, "Label11");
            this.Label11.Name = "Label11";
            // 
            // SaveHotkey
            // 
            this.SaveHotkey.Hotkey = System.Windows.Forms.Keys.None;
            this.SaveHotkey.HotkeyModifiers = System.Windows.Forms.Keys.None;
            resources.ApplyResources(this.SaveHotkey, "SaveHotkey");
            this.SaveHotkey.Name = "SaveHotkey";
            // 
            // Label10
            // 
            resources.ApplyResources(this.Label10, "Label10");
            this.Label10.Name = "Label10";
            // 
            // ResetLangBtn
            // 
            resources.ApplyResources(this.ResetLangBtn, "ResetLangBtn");
            this.ResetLangBtn.Name = "ResetLangBtn";
            this.ResetLangBtn.UseVisualStyleBackColor = true;
            this.ResetLangBtn.Click += new System.EventHandler(this.ResetLangBtn_Click);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.resetBtn);
            this.TabPage1.Controls.Add(this.importBtn);
            this.TabPage1.Controls.Add(this.exportBtn);
            this.TabPage1.Controls.Add(this.colorsSettings);
            this.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Name = "TabPage1";
            // 
            // resetBtn
            // 
            resources.ApplyResources(this.resetBtn, "resetBtn");
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // importBtn
            // 
            resources.ApplyResources(this.importBtn, "importBtn");
            this.importBtn.Name = "importBtn";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            resources.ApplyResources(this.exportBtn, "exportBtn");
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // colorsSettings
            // 
            resources.ApplyResources(this.colorsSettings, "colorsSettings");
            this.colorsSettings.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.colorsSettings.Name = "colorsSettings";
            this.colorsSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.colorsSettings_PropertyValueChanged);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Button1);
            this.TabPage2.Controls.Add(this.customArgsText);
            this.TabPage2.Controls.Add(this.Label9);
            this.TabPage2.Controls.Add(this.parenthesesCheck);
            this.TabPage2.Controls.Add(this.semiColonCheck);
            this.TabPage2.Controls.Add(this.skipLinesUpDown);
            this.TabPage2.Controls.Add(this.Label8);
            this.TabPage2.Controls.Add(this.tabSizeUpDown);
            this.TabPage2.Controls.Add(this.Label7);
            this.TabPage2.Controls.Add(this.optiLevelUpDown);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.debugLevelUpDown);
            this.TabPage2.Controls.Add(this.Label4);
            this.TabPage2.Controls.Add(this.reportGenDirText);
            this.TabPage2.Controls.Add(this.reportGenCheck);
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.ouputDirText);
            this.TabPage2.Controls.Add(this.Label3);
            this.TabPage2.Controls.Add(this.includesDirText);
            this.TabPage2.Controls.Add(this.Label2);
            this.TabPage2.Controls.Add(this.activeDirText);
            this.TabPage2.Controls.Add(this.Label1);
            resources.ApplyResources(this.TabPage2, "TabPage2");
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            resources.ApplyResources(this.Button1, "Button1");
            this.Button1.Name = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.ResetDefaultCompiler);
            // 
            // customArgsText
            // 
            resources.ApplyResources(this.customArgsText, "customArgsText");
            this.customArgsText.Name = "customArgsText";
            this.ToolTipHandler.SetToolTip(this.customArgsText, resources.GetString("customArgsText.ToolTip"));
            // 
            // Label9
            // 
            resources.ApplyResources(this.Label9, "Label9");
            this.Label9.Name = "Label9";
            // 
            // parenthesesCheck
            // 
            resources.ApplyResources(this.parenthesesCheck, "parenthesesCheck");
            this.parenthesesCheck.Name = "parenthesesCheck";
            this.ToolTipHandler.SetToolTip(this.parenthesesCheck, resources.GetString("parenthesesCheck.ToolTip"));
            this.parenthesesCheck.UseVisualStyleBackColor = true;
            // 
            // semiColonCheck
            // 
            resources.ApplyResources(this.semiColonCheck, "semiColonCheck");
            this.semiColonCheck.Name = "semiColonCheck";
            this.ToolTipHandler.SetToolTip(this.semiColonCheck, resources.GetString("semiColonCheck.ToolTip"));
            this.semiColonCheck.UseVisualStyleBackColor = true;
            // 
            // skipLinesUpDown
            // 
            resources.ApplyResources(this.skipLinesUpDown, "skipLinesUpDown");
            this.skipLinesUpDown.Name = "skipLinesUpDown";
            this.ToolTipHandler.SetToolTip(this.skipLinesUpDown, resources.GetString("skipLinesUpDown.ToolTip"));
            // 
            // Label8
            // 
            resources.ApplyResources(this.Label8, "Label8");
            this.Label8.Name = "Label8";
            // 
            // tabSizeUpDown
            // 
            resources.ApplyResources(this.tabSizeUpDown, "tabSizeUpDown");
            this.tabSizeUpDown.Name = "tabSizeUpDown";
            this.ToolTipHandler.SetToolTip(this.tabSizeUpDown, resources.GetString("tabSizeUpDown.ToolTip"));
            // 
            // Label7
            // 
            resources.ApplyResources(this.Label7, "Label7");
            this.Label7.Name = "Label7";
            // 
            // optiLevelUpDown
            // 
            resources.ApplyResources(this.optiLevelUpDown, "optiLevelUpDown");
            this.optiLevelUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.optiLevelUpDown.Name = "optiLevelUpDown";
            this.ToolTipHandler.SetToolTip(this.optiLevelUpDown, resources.GetString("optiLevelUpDown.ToolTip"));
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // debugLevelUpDown
            // 
            resources.ApplyResources(this.debugLevelUpDown, "debugLevelUpDown");
            this.debugLevelUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.debugLevelUpDown.Name = "debugLevelUpDown";
            this.ToolTipHandler.SetToolTip(this.debugLevelUpDown, resources.GetString("debugLevelUpDown.ToolTip"));
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // reportGenDirText
            // 
            resources.ApplyResources(this.reportGenDirText, "reportGenDirText");
            this.reportGenDirText.Description = "Select Save Location For The Report";
            this.reportGenDirText.Filter = "XML File (*.xml) | *.xml";
            this.reportGenDirText.Name = "reportGenDirText";
            this.reportGenDirText.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.FileSave;
            this.ToolTipHandler.SetToolTip(this.reportGenDirText, resources.GetString("reportGenDirText.ToolTip"));
            // 
            // reportGenCheck
            // 
            resources.ApplyResources(this.reportGenCheck, "reportGenCheck");
            this.reportGenCheck.Name = "reportGenCheck";
            this.reportGenCheck.UseVisualStyleBackColor = true;
            this.reportGenCheck.CheckedChanged += new System.EventHandler(this.reportGenCheck_CheckedChanged);
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // ouputDirText
            // 
            resources.ApplyResources(this.ouputDirText, "ouputDirText");
            this.ouputDirText.Description = "Select The Output Directory";
            this.ouputDirText.Filter = null;
            this.ouputDirText.Name = "ouputDirText";
            this.ouputDirText.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.Folder;
            this.ToolTipHandler.SetToolTip(this.ouputDirText, resources.GetString("ouputDirText.ToolTip"));
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // includesDirText
            // 
            resources.ApplyResources(this.includesDirText, "includesDirText");
            this.includesDirText.Description = "Select The Includes Directory";
            this.includesDirText.Filter = null;
            this.includesDirText.Name = "includesDirText";
            this.includesDirText.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.Folder;
            this.ToolTipHandler.SetToolTip(this.includesDirText, resources.GetString("includesDirText.ToolTip"));
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // activeDirText
            // 
            resources.ApplyResources(this.activeDirText, "activeDirText");
            this.activeDirText.Description = "Select The Active Directory";
            this.activeDirText.Filter = null;
            this.activeDirText.Name = "activeDirText";
            this.activeDirText.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.Folder;
            this.ToolTipHandler.SetToolTip(this.activeDirText, resources.GetString("activeDirText.ToolTip"));
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // serverCFGTabPage
            // 
            this.serverCFGTabPage.Controls.Add(this.serverCfgGrid);
            resources.ApplyResources(this.serverCFGTabPage, "serverCFGTabPage");
            this.serverCFGTabPage.Name = "serverCFGTabPage";
            this.serverCFGTabPage.UseVisualStyleBackColor = true;
            // 
            // serverCfgGrid
            // 
            this.serverCfgGrid.AllowUserToAddRows = false;
            this.serverCfgGrid.AllowUserToDeleteRows = false;
            this.serverCfgGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.serverCfgGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.serverCfgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serverCfgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.valueColumn});
            resources.ApplyResources(this.serverCfgGrid, "serverCfgGrid");
            this.serverCfgGrid.Name = "serverCfgGrid";
            // 
            // ToolTipHandler
            // 
            this.ToolTipHandler.AutomaticDelay = 0;
            this.ToolTipHandler.AutoPopDelay = 10000;
            this.ToolTipHandler.InitialDelay = 100;
            this.ToolTipHandler.ReshowDelay = 100;
            this.ToolTipHandler.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTipHandler.ToolTipTitle = "Help";
            // 
            // nameColumn
            // 
            resources.ApplyResources(this.nameColumn, "nameColumn");
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // valueColumn
            // 
            resources.ApplyResources(this.valueColumn, "valueColumn");
            this.valueColumn.Name = "valueColumn";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skipLinesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optiLevelUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugLevelUpDown)).EndInit();
            this.serverCFGTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverCfgGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public TabControl TabControl1;
        public TabPage TabPage1;
        internal PropertyGrid colorsSettings;
        internal Button exportBtn;
        internal Button resetBtn;
        internal Button importBtn;
        internal TabPage TabPage2;
        internal Label Label1;
        internal Label Label3;
        internal Label Label2;
        internal CheckBox reportGenCheck;
        internal Label Label6;
        internal NumericUpDown optiLevelUpDown;
        internal Label Label5;
        internal NumericUpDown debugLevelUpDown;
        internal Label Label4;
        internal NumericUpDown tabSizeUpDown;
        internal Label Label7;
        internal NumericUpDown skipLinesUpDown;
        internal Label Label8;
        internal CheckBox semiColonCheck;
        internal CheckBox parenthesesCheck;
        internal TextBox customArgsText;
        internal Label Label9;
        internal Button Button1;
        internal ToolTip ToolTipHandler;
        internal PathTextBox reportGenDirText;
        internal PathTextBox ouputDirText;
        internal PathTextBox includesDirText;
        internal PathTextBox activeDirText;
        internal TabPage serverCFGTabPage;
        internal DataGridView serverCfgGrid;
        internal TabPage TabPage3;
        internal Button ResetLangBtn;
        internal Label Label10;
        internal HotkeyControl SaveHotkey;
        internal HotkeyControl GotoHotkey;
        internal Label Label13;
        internal HotkeyControl SaveAllHotkey;
        internal Label Label12;
        internal Label Label11;
        internal HotkeyControl ReplaceHotkey;
        internal Label Label15;
        internal HotkeyControl SearchHotkey;
        internal Label Label14;
        internal HotkeyControl GotoBeforeHotkey;
        internal Label Label17;
        internal HotkeyControl GotoNextHotkey;
        internal Label Label16;
        internal Button Button2;
        internal HotkeyControl GotoDefHotkey;
        internal Label label19;
        internal HotkeyControl BuildHotkey;
        internal Label Label18;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn valueColumn;
    }
}