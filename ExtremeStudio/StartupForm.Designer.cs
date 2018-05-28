using System.ComponentModel;
using System.Windows.Forms;
using ExtremeCore.Controls_And_Tools;

namespace ExtremeStudio
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.locTextBox = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.preExistCheck = new System.Windows.Forms.CheckBox();
            this.CreateProjectBtn = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.verListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.loadProjectBtn = new System.Windows.Forms.Button();
            this.projectVersion = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.pathTextBox = new ExtremeCore.Controls_And_Tools.PathTextBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.recentListBox = new System.Windows.Forms.ListBox();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenGlobalSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.locTextBox);
            this.TabPage1.Controls.Add(this.preExistCheck);
            this.TabPage1.Controls.Add(this.CreateProjectBtn);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.verListBox);
            this.TabPage1.Controls.Add(this.nameTextBox);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.Label1);
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // locTextBox
            // 
            this.locTextBox.Description = null;
            this.locTextBox.Filter = null;
            resources.ApplyResources(this.locTextBox, "locTextBox");
            this.locTextBox.Name = "locTextBox";
            this.locTextBox.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.Folder;
            // 
            // preExistCheck
            // 
            resources.ApplyResources(this.preExistCheck, "preExistCheck");
            this.preExistCheck.Name = "preExistCheck";
            this.preExistCheck.UseVisualStyleBackColor = true;
            this.preExistCheck.Click += new System.EventHandler(this.preExistCheck_CheckedChanged);
            // 
            // CreateProjectBtn
            // 
            resources.ApplyResources(this.CreateProjectBtn, "CreateProjectBtn");
            this.CreateProjectBtn.Name = "CreateProjectBtn";
            this.CreateProjectBtn.UseVisualStyleBackColor = true;
            this.CreateProjectBtn.Click += new System.EventHandler(this.CreateProjectBtn_Click);
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // verListBox
            // 
            this.verListBox.FormattingEnabled = true;
            resources.ApplyResources(this.verListBox, "verListBox");
            this.verListBox.Name = "verListBox";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.loadProjectBtn);
            this.TabPage2.Controls.Add(this.projectVersion);
            this.TabPage2.Controls.Add(this.Label6);
            this.TabPage2.Controls.Add(this.projectName);
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.Label4);
            this.TabPage2.Controls.Add(this.pathTextBox);
            resources.ApplyResources(this.TabPage2, "TabPage2");
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // loadProjectBtn
            // 
            resources.ApplyResources(this.loadProjectBtn, "loadProjectBtn");
            this.loadProjectBtn.Name = "loadProjectBtn";
            this.loadProjectBtn.UseVisualStyleBackColor = true;
            this.loadProjectBtn.Click += new System.EventHandler(this.loadProjectBtn_Click);
            // 
            // projectVersion
            // 
            resources.ApplyResources(this.projectVersion, "projectVersion");
            this.projectVersion.Name = "projectVersion";
            // 
            // Label6
            // 
            resources.ApplyResources(this.Label6, "Label6");
            this.Label6.Name = "Label6";
            // 
            // projectName
            // 
            resources.ApplyResources(this.projectName, "projectName");
            this.projectName.Name = "projectName";
            // 
            // Label5
            // 
            resources.ApplyResources(this.Label5, "Label5");
            this.Label5.Name = "Label5";
            // 
            // Label4
            // 
            resources.ApplyResources(this.Label4, "Label4");
            this.Label4.Name = "Label4";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Description = "Select the project\'s folder.";
            this.pathTextBox.Filter = null;
            resources.ApplyResources(this.pathTextBox, "pathTextBox");
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.PathType = ExtremeCore.Controls_And_Tools.PathTextBox.PathTypes.Folder;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.Button3);
            this.TabPage3.Controls.Add(this.Button1);
            this.TabPage3.Controls.Add(this.recentListBox);
            resources.ApplyResources(this.TabPage3, "TabPage3");
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            resources.ApplyResources(this.Button3, "Button3");
            this.Button3.Name = "Button3";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button1
            // 
            resources.ApplyResources(this.Button1, "Button1");
            this.Button1.Name = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // recentListBox
            // 
            this.recentListBox.FormattingEnabled = true;
            resources.ApplyResources(this.recentListBox, "recentListBox");
            this.recentListBox.Name = "recentListBox";
            this.recentListBox.DoubleClick += new System.EventHandler(this.recentListBox_DoubleClick);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenGlobalSettingsToolStripMenuItem});
            resources.ApplyResources(this.MenuStrip1, "MenuStrip1");
            this.MenuStrip1.Name = "MenuStrip1";
            // 
            // OpenGlobalSettingsToolStripMenuItem
            // 
            this.OpenGlobalSettingsToolStripMenuItem.Name = "OpenGlobalSettingsToolStripMenuItem";
            resources.ApplyResources(this.OpenGlobalSettingsToolStripMenuItem, "OpenGlobalSettingsToolStripMenuItem");
            this.OpenGlobalSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenGlobalSettingsToolStripMenuItem_Click);
            // 
            // StartupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.MenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartupForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartupForm_FormClosed);
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal TabControl TabControl1;
        internal TabPage TabPage1;
        internal TabPage TabPage2;
        internal Label Label2;
        internal Label Label1;
        internal TextBox nameTextBox;
        internal ListBox verListBox;
        internal Label Label3;
        internal Button CreateProjectBtn;
        internal Label Label4;
        internal Label projectName;
        internal Label Label5;
        internal Label Label6;
        internal Label projectVersion;
        internal Button loadProjectBtn;
        internal TabPage TabPage3;
        internal ListBox recentListBox;
        internal Button Button1;
        internal Button Button3;
        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem OpenGlobalSettingsToolStripMenuItem;
        internal PathTextBox pathTextBox;
        internal CheckBox preExistCheck;
        internal PathTextBox locTextBox;
    }
}