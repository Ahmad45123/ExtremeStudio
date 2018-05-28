using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.EditorFunctions
{
    public partial class SearchReplaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchReplaceForm));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.findCloseBtn = new System.Windows.Forms.Button();
            this.searchFindAllBtn = new System.Windows.Forms.Button();
            this.searchCountBtn = new System.Windows.Forms.Button();
            this.searchFindBtn = new System.Windows.Forms.Button();
            this.searchFindText = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.replaceReplaceText = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.replaceCloseBtn = new System.Windows.Forms.Button();
            this.replaceReplaceAllBtn = new System.Windows.Forms.Button();
            this.replaceReplaceBtn = new System.Windows.Forms.Button();
            this.replaceFindNextBtn = new System.Windows.Forms.Button();
            this.replaceFindText = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.matchWholeWordCheck = new System.Windows.Forms.CheckBox();
            this.matchCaseCheck = new System.Windows.Forms.CheckBox();
            this.inSelCheck = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.searchRegexRadio = new System.Windows.Forms.RadioButton();
            this.searchNormalRadio = new System.Windows.Forms.RadioButton();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            resources.ApplyResources(this.TabControl1, "TabControl1");
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // TabPage1
            // 
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Controls.Add(this.findCloseBtn);
            this.TabPage1.Controls.Add(this.searchFindAllBtn);
            this.TabPage1.Controls.Add(this.searchCountBtn);
            this.TabPage1.Controls.Add(this.searchFindBtn);
            this.TabPage1.Controls.Add(this.searchFindText);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // findCloseBtn
            // 
            resources.ApplyResources(this.findCloseBtn, "findCloseBtn");
            this.findCloseBtn.Name = "findCloseBtn";
            this.findCloseBtn.UseVisualStyleBackColor = true;
            this.findCloseBtn.Click += new System.EventHandler(this.findCloseBtn_Click);
            // 
            // searchFindAllBtn
            // 
            resources.ApplyResources(this.searchFindAllBtn, "searchFindAllBtn");
            this.searchFindAllBtn.Name = "searchFindAllBtn";
            this.searchFindAllBtn.UseVisualStyleBackColor = true;
            this.searchFindAllBtn.Click += new System.EventHandler(this.searchFindAllBtn_Click);
            // 
            // searchCountBtn
            // 
            resources.ApplyResources(this.searchCountBtn, "searchCountBtn");
            this.searchCountBtn.Name = "searchCountBtn";
            this.searchCountBtn.UseVisualStyleBackColor = true;
            this.searchCountBtn.Click += new System.EventHandler(this.searchCountBtn_Click);
            // 
            // searchFindBtn
            // 
            resources.ApplyResources(this.searchFindBtn, "searchFindBtn");
            this.searchFindBtn.Name = "searchFindBtn";
            this.searchFindBtn.UseVisualStyleBackColor = true;
            this.searchFindBtn.Click += new System.EventHandler(this.seachFindBtn_Click);
            // 
            // searchFindText
            // 
            resources.ApplyResources(this.searchFindText, "searchFindText");
            this.searchFindText.Name = "searchFindText";
            this.searchFindText.TextChanged += new System.EventHandler(this.searchFindText_TextChanged);
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // TabPage2
            // 
            resources.ApplyResources(this.TabPage2, "TabPage2");
            this.TabPage2.Controls.Add(this.replaceReplaceText);
            this.TabPage2.Controls.Add(this.Label3);
            this.TabPage2.Controls.Add(this.replaceCloseBtn);
            this.TabPage2.Controls.Add(this.replaceReplaceAllBtn);
            this.TabPage2.Controls.Add(this.replaceReplaceBtn);
            this.TabPage2.Controls.Add(this.replaceFindNextBtn);
            this.TabPage2.Controls.Add(this.replaceFindText);
            this.TabPage2.Controls.Add(this.Label2);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // replaceReplaceText
            // 
            resources.ApplyResources(this.replaceReplaceText, "replaceReplaceText");
            this.replaceReplaceText.Name = "replaceReplaceText";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.Name = "Label3";
            // 
            // replaceCloseBtn
            // 
            resources.ApplyResources(this.replaceCloseBtn, "replaceCloseBtn");
            this.replaceCloseBtn.Name = "replaceCloseBtn";
            this.replaceCloseBtn.UseVisualStyleBackColor = true;
            // 
            // replaceReplaceAllBtn
            // 
            resources.ApplyResources(this.replaceReplaceAllBtn, "replaceReplaceAllBtn");
            this.replaceReplaceAllBtn.Name = "replaceReplaceAllBtn";
            this.replaceReplaceAllBtn.UseVisualStyleBackColor = true;
            this.replaceReplaceAllBtn.Click += new System.EventHandler(this.replaceReplaceAllBtn_Click);
            // 
            // replaceReplaceBtn
            // 
            resources.ApplyResources(this.replaceReplaceBtn, "replaceReplaceBtn");
            this.replaceReplaceBtn.Name = "replaceReplaceBtn";
            this.replaceReplaceBtn.UseVisualStyleBackColor = true;
            this.replaceReplaceBtn.Click += new System.EventHandler(this.replaceReplaceBtn_Click);
            // 
            // replaceFindNextBtn
            // 
            resources.ApplyResources(this.replaceFindNextBtn, "replaceFindNextBtn");
            this.replaceFindNextBtn.Name = "replaceFindNextBtn";
            this.replaceFindNextBtn.UseVisualStyleBackColor = true;
            this.replaceFindNextBtn.Click += new System.EventHandler(this.replaceFindNextBtn_Click);
            // 
            // replaceFindText
            // 
            resources.ApplyResources(this.replaceFindText, "replaceFindText");
            this.replaceFindText.Name = "replaceFindText";
            this.replaceFindText.TextChanged += new System.EventHandler(this.replaceFindText_replaceReplaceText_TextChanged);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // matchWholeWordCheck
            // 
            resources.ApplyResources(this.matchWholeWordCheck, "matchWholeWordCheck");
            this.matchWholeWordCheck.Name = "matchWholeWordCheck";
            this.matchWholeWordCheck.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheck
            // 
            resources.ApplyResources(this.matchCaseCheck, "matchCaseCheck");
            this.matchCaseCheck.Name = "matchCaseCheck";
            this.matchCaseCheck.UseVisualStyleBackColor = true;
            // 
            // inSelCheck
            // 
            resources.ApplyResources(this.inSelCheck, "inSelCheck");
            this.inSelCheck.Name = "inSelCheck";
            this.inSelCheck.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            resources.ApplyResources(this.GroupBox1, "GroupBox1");
            this.GroupBox1.Controls.Add(this.searchRegexRadio);
            this.GroupBox1.Controls.Add(this.searchNormalRadio);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.TabStop = false;
            // 
            // searchRegexRadio
            // 
            resources.ApplyResources(this.searchRegexRadio, "searchRegexRadio");
            this.searchRegexRadio.Name = "searchRegexRadio";
            this.searchRegexRadio.TabStop = true;
            this.searchRegexRadio.UseVisualStyleBackColor = true;
            // 
            // searchNormalRadio
            // 
            resources.ApplyResources(this.searchNormalRadio, "searchNormalRadio");
            this.searchNormalRadio.Checked = true;
            this.searchNormalRadio.Name = "searchNormalRadio";
            this.searchNormalRadio.TabStop = true;
            this.searchNormalRadio.UseVisualStyleBackColor = true;
            // 
            // SearchReplaceForm
            // 
            this.AcceptButton = this.searchFindBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.inSelCheck);
            this.Controls.Add(this.matchCaseCheck);
            this.Controls.Add(this.matchWholeWordCheck);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchReplaceForm";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.SearchReplaceForm_Activated);
            this.Deactivate += new System.EventHandler(this.SearchReplaceForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchReplaceForm_FormClosing);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal TabControl TabControl1;
        internal TabPage TabPage1;
        internal TabPage TabPage2;
        internal CheckBox matchWholeWordCheck;
        internal CheckBox matchCaseCheck;
        internal CheckBox inSelCheck;
        internal GroupBox GroupBox1;
        internal RadioButton searchRegexRadio;
        internal RadioButton searchNormalRadio;
        internal Button findCloseBtn;
        internal Button searchFindAllBtn;
        internal Button searchCountBtn;
        internal Button searchFindBtn;
        internal TextBox searchFindText;
        internal Label Label1;
        internal TextBox replaceFindText;
        internal Label Label2;
        internal Button replaceFindNextBtn;
        internal Button replaceReplaceAllBtn;
        internal Button replaceReplaceBtn;
        internal Button replaceCloseBtn;
        internal TextBox replaceReplaceText;
        internal Label Label3;
    }
}