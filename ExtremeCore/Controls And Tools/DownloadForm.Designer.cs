namespace ExtremeStudio.FunctionsForms
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
            this.descLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bytesDl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(12, 9);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(58, 13);
            this.descLabel.TabIndex = 0;
            this.descLabel.Text = "description";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(523, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // bytesDl
            // 
            this.bytesDl.Location = new System.Drawing.Point(15, 63);
            this.bytesDl.Name = "bytesDl";
            this.bytesDl.Size = new System.Drawing.Size(523, 19);
            this.bytesDl.TabIndex = 2;
            this.bytesDl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 91);
            this.ControlBox = false;
            this.Controls.Add(this.bytesDl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.descLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadForm";
            this.Text = "Downloading...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label bytesDl;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label descLabel;
    }
}