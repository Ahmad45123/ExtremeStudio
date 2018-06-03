using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeStudio
{
    partial class LanguagesForm
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
            this.LangsListBox = new System.Windows.Forms.ListBox();
            this.Acceptbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LangsListBox
            // 
            this.LangsListBox.FormattingEnabled = true;
            this.LangsListBox.Items.AddRange(new object[] {
            "Croatian",
            "English",
            "Hungarian",
            "Portuguese, Brazillian",
            "Spanish",
            "Russian"});
            this.LangsListBox.Location = new System.Drawing.Point(12, 12);
            this.LangsListBox.Name = "LangsListBox";
            this.LangsListBox.Size = new System.Drawing.Size(302, 316);
            this.LangsListBox.TabIndex = 0;
            this.LangsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LangsListBox_MouseDoubleClick);
            // 
            // Acceptbtn
            // 
            this.Acceptbtn.Location = new System.Drawing.Point(12, 334);
            this.Acceptbtn.Name = "Acceptbtn";
            this.Acceptbtn.Size = new System.Drawing.Size(302, 23);
            this.Acceptbtn.TabIndex = 1;
            this.Acceptbtn.Text = "Choose Language";
            this.Acceptbtn.UseVisualStyleBackColor = true;
            this.Acceptbtn.Click += new System.EventHandler(this.Acceptbtn_Click);
            // 
            // LanguagesForm
            // 
            this.AcceptButton = this.Acceptbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 365);
            this.Controls.Add(this.Acceptbtn);
            this.Controls.Add(this.LangsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LanguagesForm";
            this.Text = "Choose UI Language";
            this.Load += new System.EventHandler(this.LanguagesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal ListBox LangsListBox;
        internal Button Acceptbtn;
    }
}
