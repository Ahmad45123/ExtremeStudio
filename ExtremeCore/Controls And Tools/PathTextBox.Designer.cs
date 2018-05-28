using System.ComponentModel;
using System.Windows.Forms;

namespace ExtremeCore.Controls_And_Tools
{
    partial class PathTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathText = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathText
            // 
            this.PathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathText.Location = new System.Drawing.Point(0, 0);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(395, 20);
            this.PathText.TabIndex = 0;
            this.PathText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PathText_MouseDoubleClick);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseBtn.Location = new System.Drawing.Point(398, 0);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(49, 20);
            this.BrowseBtn.TabIndex = 1;
            this.BrowseBtn.Text = "...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // PathTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.PathText);
            this.Name = "PathTextBox";
            this.Size = new System.Drawing.Size(447, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextBox PathText;
        public Button BrowseBtn;
    }
}
