using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.EditorFunctions
{
    partial class GotoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GotoForm));
            this.linenumberRadio = new System.Windows.Forms.RadioButton();
            this.positionRadio = new System.Windows.Forms.RadioButton();
            this.theLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.GoBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.curLabel = new System.Windows.Forms.Label();
            this.maxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linenumberRadio
            // 
            resources.ApplyResources(this.linenumberRadio, "linenumberRadio");
            this.linenumberRadio.Checked = true;
            this.linenumberRadio.Name = "linenumberRadio";
            this.linenumberRadio.TabStop = true;
            this.linenumberRadio.UseVisualStyleBackColor = true;
            this.linenumberRadio.CheckedChanged += new System.EventHandler(this.linenumberRadio_CheckedChanged);
            // 
            // positionRadio
            // 
            resources.ApplyResources(this.positionRadio, "positionRadio");
            this.positionRadio.Name = "positionRadio";
            this.positionRadio.TabStop = true;
            this.positionRadio.UseVisualStyleBackColor = true;
            this.positionRadio.CheckedChanged += new System.EventHandler(this.positionRadio_CheckedChanged);
            // 
            // theLabel
            // 
            resources.ApplyResources(this.theLabel, "theLabel");
            this.theLabel.Name = "theLabel";
            // 
            // valueTextBox
            // 
            resources.ApplyResources(this.valueTextBox, "valueTextBox");
            this.valueTextBox.Name = "valueTextBox";
            // 
            // GoBtn
            // 
            resources.ApplyResources(this.GoBtn, "GoBtn");
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // CancelBtn
            // 
            resources.ApplyResources(this.CancelBtn, "CancelBtn");
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // curLabel
            // 
            resources.ApplyResources(this.curLabel, "curLabel");
            this.curLabel.Name = "curLabel";
            // 
            // maxLabel
            // 
            resources.ApplyResources(this.maxLabel, "maxLabel");
            this.maxLabel.Name = "maxLabel";
            // 
            // GotoForm
            // 
            this.AcceptButton = this.GoBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.maxLabel);
            this.Controls.Add(this.curLabel);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.GoBtn);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.theLabel);
            this.Controls.Add(this.positionRadio);
            this.Controls.Add(this.linenumberRadio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GotoForm";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.GotoForm_Activated);
            this.Deactivate += new System.EventHandler(this.GotoForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GotoForm_FormClosing);
            this.Load += new System.EventHandler(this.GotoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal RadioButton linenumberRadio;
        internal RadioButton positionRadio;
        internal Label theLabel;
        internal TextBox valueTextBox;
        internal Button GoBtn;
        internal Button CancelBtn;
        internal Label curLabel;
        internal Label maxLabel;
    }
}