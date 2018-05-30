using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainDock = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainRibbon = new System.Windows.Forms.Ribbon();
            this.RibbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.RibbonOrbRecentItem1 = new System.Windows.Forms.RibbonOrbRecentItem();
            this.closeProjectButton = new System.Windows.Forms.RibbonButton();
            this.fileTab = new System.Windows.Forms.RibbonTab();
            this.prjPanel = new System.Windows.Forms.RibbonPanel();
            this.saveFileButton = new System.Windows.Forms.RibbonButton();
            this.saveAllButton = new System.Windows.Forms.RibbonButton();
            this.downloadPanel = new System.Windows.Forms.RibbonPanel();
            this.includesButton = new System.Windows.Forms.RibbonButton();
            this.pluginsButton = new System.Windows.Forms.RibbonButton();
            this.editTab = new System.Windows.Forms.RibbonTab();
            this.clipboardPanel = new System.Windows.Forms.RibbonPanel();
            this.cutButton = new System.Windows.Forms.RibbonButton();
            this.copyButton = new System.Windows.Forms.RibbonButton();
            this.pasteButton = new System.Windows.Forms.RibbonButton();
            this.searchPanel = new System.Windows.Forms.RibbonPanel();
            this.searchButton = new System.Windows.Forms.RibbonButton();
            this.replaceButton = new System.Windows.Forms.RibbonButton();
            this.gotoButton = new System.Windows.Forms.RibbonButton();
            this.indentPanel = new System.Windows.Forms.RibbonPanel();
            this.addIndentButton = new System.Windows.Forms.RibbonButton();
            this.removeIndentButton = new System.Windows.Forms.RibbonButton();
            this.ideTab = new System.Windows.Forms.RibbonTab();
            this.viewPanel = new System.Windows.Forms.RibbonPanel();
            this.prjExplrerView = new System.Windows.Forms.RibbonButton();
            this.objExplorerView = new System.Windows.Forms.RibbonButton();
            this.errorsWarningsView = new System.Windows.Forms.RibbonButton();
            this.syntaxHighPanel = new System.Windows.Forms.RibbonPanel();
            this.RibbonButton1 = new System.Windows.Forms.RibbonButton();
            this.BuildPanel = new System.Windows.Forms.RibbonPanel();
            this.compileScriptBtn = new System.Windows.Forms.RibbonButton();
            this.CompileAndRunBtn = new System.Windows.Forms.RibbonButton();
            this.customTab = new System.Windows.Forms.RibbonTab();
            this.pluginManagePanel = new System.Windows.Forms.RibbonPanel();
            this.esPluginsManage = new System.Windows.Forms.RibbonButton();
            this.installedPlugins = new System.Windows.Forms.RibbonPanel();
            this.CompilerWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStripTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDock
            // 
            resources.ApplyResources(this.MainDock, "MainDock");
            this.MainDock.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.MainDock.DockBackColor = System.Drawing.SystemColors.Control;
            this.MainDock.Name = "MainDock";
            this.MainDock.ActiveDocumentChanged += new System.EventHandler(this.MainDock_ActiveDocumentChanged);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.StatusStrip1, "StatusStrip1");
            this.StatusStrip1.Name = "StatusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // mainRibbon
            // 
            resources.ApplyResources(this.mainRibbon, "mainRibbon");
            this.mainRibbon.Minimized = false;
            this.mainRibbon.Name = "mainRibbon";
            // 
            // 
            // 
            this.mainRibbon.OrbDropDown.BorderRoundness = 8;
            this.mainRibbon.OrbDropDown.Location = ((System.Drawing.Point)(resources.GetObject("mainRibbon.OrbDropDown.Location")));
            this.mainRibbon.OrbDropDown.MenuItems.Add(this.RibbonOrbMenuItem1);
            this.mainRibbon.OrbDropDown.Name = "";
            this.mainRibbon.OrbDropDown.RecentItems.Add(this.RibbonOrbRecentItem1);
            this.mainRibbon.OrbDropDown.Size = ((System.Drawing.Size)(resources.GetObject("mainRibbon.OrbDropDown.Size")));
            this.mainRibbon.OrbDropDown.TabIndex = ((int)(resources.GetObject("mainRibbon.OrbDropDown.TabIndex")));
            this.mainRibbon.OrbImage = null;
            this.mainRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.mainRibbon.OrbText = "File";
            this.mainRibbon.OrbVisible = false;
            // 
            // 
            // 
            this.mainRibbon.QuickAcessToolbar.Items.Add(this.closeProjectButton);
            this.mainRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.mainRibbon.Tabs.Add(this.fileTab);
            this.mainRibbon.Tabs.Add(this.editTab);
            this.mainRibbon.Tabs.Add(this.ideTab);
            this.mainRibbon.Tabs.Add(this.customTab);
            this.mainRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.mainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // RibbonOrbMenuItem1
            // 
            this.RibbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.RibbonOrbMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("RibbonOrbMenuItem1.Image")));
            this.RibbonOrbMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("RibbonOrbMenuItem1.SmallImage")));
            resources.ApplyResources(this.RibbonOrbMenuItem1, "RibbonOrbMenuItem1");
            // 
            // RibbonOrbRecentItem1
            // 
            this.RibbonOrbRecentItem1.AltKey = "";
            this.RibbonOrbRecentItem1.Image = global::ExtremeStudio.Properties.Resources.ribbon_closeProject;
            this.RibbonOrbRecentItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("RibbonOrbRecentItem1.SmallImage")));
            resources.ApplyResources(this.RibbonOrbRecentItem1, "RibbonOrbRecentItem1");
            // 
            // closeProjectButton
            // 
            this.closeProjectButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_closeProject;
            this.closeProjectButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.closeProjectButton.SmallImage = global::ExtremeStudio.Properties.Resources.ribbon_closeProject;
            resources.ApplyResources(this.closeProjectButton, "closeProjectButton");
            this.closeProjectButton.Click += new System.EventHandler(this.closeProjectButton_Click);
            // 
            // fileTab
            // 
            this.fileTab.Panels.Add(this.prjPanel);
            this.fileTab.Panels.Add(this.downloadPanel);
            resources.ApplyResources(this.fileTab, "fileTab");
            // 
            // prjPanel
            // 
            this.prjPanel.ButtonMoreVisible = false;
            this.prjPanel.Items.Add(this.saveFileButton);
            this.prjPanel.Items.Add(this.saveAllButton);
            resources.ApplyResources(this.prjPanel, "prjPanel");
            // 
            // saveFileButton
            // 
            this.saveFileButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_saveFile;
            this.saveFileButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("saveFileButton.SmallImage")));
            resources.ApplyResources(this.saveFileButton, "saveFileButton");
            this.saveFileButton.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // saveAllButton
            // 
            this.saveAllButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_saveFileAll;
            this.saveAllButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("saveAllButton.SmallImage")));
            resources.ApplyResources(this.saveAllButton, "saveAllButton");
            this.saveAllButton.Click += new System.EventHandler(this.SaveAllFiles);
            // 
            // downloadPanel
            // 
            this.downloadPanel.ButtonMoreVisible = false;
            this.downloadPanel.Items.Add(this.includesButton);
            this.downloadPanel.Items.Add(this.pluginsButton);
            resources.ApplyResources(this.downloadPanel, "downloadPanel");
            // 
            // includesButton
            // 
            this.includesButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_includes;
            this.includesButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("includesButton.SmallImage")));
            resources.ApplyResources(this.includesButton, "includesButton");
            this.includesButton.Click += new System.EventHandler(this.ToolStripButton4_Click);
            // 
            // pluginsButton
            // 
            this.pluginsButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_plugins;
            this.pluginsButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pluginsButton.SmallImage")));
            resources.ApplyResources(this.pluginsButton, "pluginsButton");
            this.pluginsButton.Click += new System.EventHandler(this.ToolStripButton5_Click);
            // 
            // editTab
            // 
            this.editTab.Panels.Add(this.clipboardPanel);
            this.editTab.Panels.Add(this.searchPanel);
            this.editTab.Panels.Add(this.indentPanel);
            resources.ApplyResources(this.editTab, "editTab");
            // 
            // clipboardPanel
            // 
            this.clipboardPanel.ButtonMoreEnabled = false;
            this.clipboardPanel.ButtonMoreVisible = false;
            this.clipboardPanel.Items.Add(this.cutButton);
            this.clipboardPanel.Items.Add(this.copyButton);
            this.clipboardPanel.Items.Add(this.pasteButton);
            resources.ApplyResources(this.clipboardPanel, "clipboardPanel");
            // 
            // cutButton
            // 
            this.cutButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_cut;
            this.cutButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("cutButton.SmallImage")));
            resources.ApplyResources(this.cutButton, "cutButton");
            this.cutButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_copy;
            this.copyButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("copyButton.SmallImage")));
            resources.ApplyResources(this.copyButton, "copyButton");
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_paste;
            this.pasteButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("pasteButton.SmallImage")));
            resources.ApplyResources(this.pasteButton, "pasteButton");
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.ButtonMoreVisible = false;
            this.searchPanel.Items.Add(this.searchButton);
            this.searchPanel.Items.Add(this.replaceButton);
            this.searchPanel.Items.Add(this.gotoButton);
            resources.ApplyResources(this.searchPanel, "searchPanel");
            // 
            // searchButton
            // 
            this.searchButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_search;
            this.searchButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("searchButton.SmallImage")));
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_searchAndReplace;
            this.replaceButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("replaceButton.SmallImage")));
            resources.ApplyResources(this.replaceButton, "replaceButton");
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // gotoButton
            // 
            this.gotoButton.AltKey = "";
            this.gotoButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_goto;
            this.gotoButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("gotoButton.SmallImage")));
            resources.ApplyResources(this.gotoButton, "gotoButton");
            this.gotoButton.Click += new System.EventHandler(this.gotoButton_Click);
            // 
            // indentPanel
            // 
            this.indentPanel.ButtonMoreVisible = false;
            this.indentPanel.Items.Add(this.addIndentButton);
            this.indentPanel.Items.Add(this.removeIndentButton);
            resources.ApplyResources(this.indentPanel, "indentPanel");
            // 
            // addIndentButton
            // 
            this.addIndentButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_addIndent;
            this.addIndentButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("addIndentButton.SmallImage")));
            resources.ApplyResources(this.addIndentButton, "addIndentButton");
            this.addIndentButton.Click += new System.EventHandler(this.addIndentButton_Click);
            // 
            // removeIndentButton
            // 
            this.removeIndentButton.Image = global::ExtremeStudio.Properties.Resources.ribbon_removeIndent;
            this.removeIndentButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("removeIndentButton.SmallImage")));
            resources.ApplyResources(this.removeIndentButton, "removeIndentButton");
            this.removeIndentButton.Click += new System.EventHandler(this.removeIndentButton_Click);
            // 
            // ideTab
            // 
            this.ideTab.Panels.Add(this.viewPanel);
            this.ideTab.Panels.Add(this.syntaxHighPanel);
            this.ideTab.Panels.Add(this.BuildPanel);
            resources.ApplyResources(this.ideTab, "ideTab");
            // 
            // viewPanel
            // 
            this.viewPanel.ButtonMoreVisible = false;
            this.viewPanel.Items.Add(this.prjExplrerView);
            this.viewPanel.Items.Add(this.objExplorerView);
            this.viewPanel.Items.Add(this.errorsWarningsView);
            resources.ApplyResources(this.viewPanel, "viewPanel");
            // 
            // prjExplrerView
            // 
            this.prjExplrerView.Image = global::ExtremeStudio.Properties.Resources.dirs_projexplorer;
            this.prjExplrerView.SmallImage = ((System.Drawing.Image)(resources.GetObject("prjExplrerView.SmallImage")));
            this.prjExplrerView.ToolTipTitle = "Project Explorer";
            this.prjExplrerView.Click += new System.EventHandler(this.ProjectExplorerToolStripMenuItem_Click);
            // 
            // objExplorerView
            // 
            this.objExplorerView.Image = global::ExtremeStudio.Properties.Resources.ribbon_objectExplrer;
            this.objExplorerView.SmallImage = ((System.Drawing.Image)(resources.GetObject("objExplorerView.SmallImage")));
            resources.ApplyResources(this.objExplorerView, "objExplorerView");
            this.objExplorerView.Click += new System.EventHandler(this.ObjectExplorerToolStripMenuItem_Click);
            // 
            // errorsWarningsView
            // 
            this.errorsWarningsView.Image = global::ExtremeStudio.Properties.Resources.ribbon_errors;
            this.errorsWarningsView.SmallImage = ((System.Drawing.Image)(resources.GetObject("errorsWarningsView.SmallImage")));
            resources.ApplyResources(this.errorsWarningsView, "errorsWarningsView");
            this.errorsWarningsView.Click += new System.EventHandler(this.ErrorsAndWarningsToolStripMenuItem_Click);
            // 
            // syntaxHighPanel
            // 
            this.syntaxHighPanel.ButtonMoreVisible = false;
            this.syntaxHighPanel.Items.Add(this.RibbonButton1);
            resources.ApplyResources(this.syntaxHighPanel, "syntaxHighPanel");
            // 
            // RibbonButton1
            // 
            this.RibbonButton1.Image = global::ExtremeStudio.Properties.Resources.ribbon_settings;
            this.RibbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("RibbonButton1.SmallImage")));
            resources.ApplyResources(this.RibbonButton1, "RibbonButton1");
            this.RibbonButton1.Click += new System.EventHandler(this.RibbonButton1_Click);
            // 
            // BuildPanel
            // 
            this.BuildPanel.ButtonMoreVisible = false;
            this.BuildPanel.Items.Add(this.compileScriptBtn);
            this.BuildPanel.Items.Add(this.CompileAndRunBtn);
            resources.ApplyResources(this.BuildPanel, "BuildPanel");
            // 
            // compileScriptBtn
            // 
            this.compileScriptBtn.Image = global::ExtremeStudio.Properties.Resources.ribbon_compile;
            this.compileScriptBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("compileScriptBtn.SmallImage")));
            resources.ApplyResources(this.compileScriptBtn, "compileScriptBtn");
            this.compileScriptBtn.Click += new System.EventHandler(this.compileScriptBtn_Click);
            // 
            // CompileAndRunBtn
            // 
            this.CompileAndRunBtn.Image = global::ExtremeStudio.Properties.Resources.ribbon_compileandrun;
            this.CompileAndRunBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("CompileAndRunBtn.SmallImage")));
            this.CompileAndRunBtn.Click += new System.EventHandler(this.CompileAndRunBtn_Click);
            // 
            // customTab
            // 
            this.customTab.Panels.Add(this.pluginManagePanel);
            this.customTab.Panels.Add(this.installedPlugins);
            resources.ApplyResources(this.customTab, "customTab");
            // 
            // pluginManagePanel
            // 
            this.pluginManagePanel.ButtonMoreVisible = false;
            this.pluginManagePanel.Items.Add(this.esPluginsManage);
            resources.ApplyResources(this.pluginManagePanel, "pluginManagePanel");
            // 
            // esPluginsManage
            // 
            this.esPluginsManage.Image = global::ExtremeStudio.Properties.Resources.ribbon_esPlugins;
            this.esPluginsManage.SmallImage = ((System.Drawing.Image)(resources.GetObject("esPluginsManage.SmallImage")));
            resources.ApplyResources(this.esPluginsManage, "esPluginsManage");
            this.esPluginsManage.Click += new System.EventHandler(this.esPluginsManage_Click);
            // 
            // installedPlugins
            // 
            this.installedPlugins.ButtonMoreVisible = false;
            resources.ApplyResources(this.installedPlugins, "installedPlugins");
            // 
            // CompilerWorker
            // 
            this.CompilerWorker.WorkerReportsProgress = true;
            this.CompilerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CompilerWorker_DoWork);
            this.CompilerWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CompilerWorker_ProgressChanged);
            this.CompilerWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CompilerWorker_RunWorkerCompleted);
            // 
            // statusStripTimer
            // 
            this.statusStripTimer.Tick += new System.EventHandler(this.statusStripTimer_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainRibbon);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MainDock);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DockPanel MainDock;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel statusLabel;
        internal Ribbon mainRibbon;
        internal RibbonTab editTab;
        internal RibbonPanel clipboardPanel;
        internal RibbonButton copyButton;
        internal RibbonOrbMenuItem RibbonOrbMenuItem1;
        internal RibbonOrbRecentItem RibbonOrbRecentItem1;
        internal RibbonButton cutButton;
        internal RibbonButton pasteButton;
        internal RibbonButton closeProjectButton;
        internal RibbonPanel searchPanel;
        internal RibbonButton searchButton;
        internal RibbonButton replaceButton;
        internal RibbonButton gotoButton;
        internal RibbonTab fileTab;
        internal RibbonPanel prjPanel;
        internal RibbonButton saveFileButton;
        internal RibbonButton saveAllButton;
        internal RibbonPanel downloadPanel;
        internal RibbonButton includesButton;
        internal RibbonButton pluginsButton;
        internal RibbonTab customTab;
        internal RibbonTab ideTab;
        internal RibbonPanel syntaxHighPanel;
        internal RibbonButton RibbonButton1;
        internal RibbonPanel viewPanel;
        internal RibbonPanel pluginManagePanel;
        internal RibbonPanel installedPlugins;
        internal RibbonButton prjExplrerView;
        internal RibbonButton objExplorerView;
        internal RibbonButton errorsWarningsView;
        internal RibbonButton esPluginsManage;
        internal RibbonPanel BuildPanel;
        internal RibbonButton compileScriptBtn;
        internal BackgroundWorker CompilerWorker;
        internal Timer statusStripTimer;
        internal RibbonPanel indentPanel;
        internal RibbonButton addIndentButton;
        internal RibbonButton removeIndentButton;
        internal RibbonButton CompileAndRunBtn;
    }
}