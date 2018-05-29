using System.ComponentModel;
using System.Windows.Forms;
using AutocompleteMenuNS;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock
{
    partial class EditorDock : DockContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorDock));
            this.Editor = new ScintillaNET.Scintilla();
            this.RefreshWorker = new System.ComponentModel.BackgroundWorker();
            this.AutoCompleteMenu = new AutocompleteMenuNS.AutocompleteMenu();
            this.ACImageList = new System.Windows.Forms.ImageList(this.components);
            this.colorizingWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Editor
            // 
            this.Editor.AdditionalSelectionTyping = true;
            this.Editor.AllowDrop = true;
            resources.ApplyResources(this.Editor, "Editor");
            this.Editor.Lexer = ScintillaNET.Lexer.Cpp;
            this.Editor.MouseDwellTime = 1000;
            this.Editor.MouseSelectionRectangularSwitch = true;
            this.Editor.MultiPaste = ScintillaNET.MultiPaste.Each;
            this.Editor.MultipleSelection = true;
            this.Editor.Name = "Editor";
            this.Editor.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection;
            this.Editor.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.Editor_CharAdded);
            this.Editor.Delete += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.CallTip_Editor_BeforeDelete);
            this.Editor.Insert += new System.EventHandler<ScintillaNET.ModificationEventArgs>(this.CallTip_Editor_Insert);
            this.Editor.InsertCheck += new System.EventHandler<ScintillaNET.InsertCheckEventArgs>(this.Editor_InsertCheck);
            this.Editor.SavePointLeft += new System.EventHandler<System.EventArgs>(this.Editor_SavePointLeft);
            this.Editor.SavePointReached += new System.EventHandler<System.EventArgs>(this.Editor_SavePointReached);
            this.Editor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.Editor_UpdateUI);
            this.Editor.TextChanged += new System.EventHandler(this.Editor_TextChanged);
            this.Editor.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDock_DragDrop);
            this.Editor.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDock_DragEnter);
            this.Editor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Editor_KeyDown);
            // 
            // RefreshWorker
            // 
            this.RefreshWorker.WorkerReportsProgress = true;
            this.RefreshWorker.WorkerSupportsCancellation = true;
            this.RefreshWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RefreshWorker_DoWork);
            this.RefreshWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RefreshWorker_RunWorkerCompleted);
            // 
            // AutoCompleteMenu
            // 
            this.AutoCompleteMenu.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("AutoCompleteMenu.Colors")));
            this.AutoCompleteMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.AutoCompleteMenu.ImageList = this.ACImageList;
            this.AutoCompleteMenu.Items = new string[] {
        "null"};
            this.AutoCompleteMenu.TargetControlWrapper = null;
            this.AutoCompleteMenu.ToolTipDuration = 10000000;
            this.AutoCompleteMenu.Selected += new System.EventHandler<AutocompleteMenuNS.SelectedEventArgs>(this.AutoCompleteMenu_Selected);
            // 
            // ACImageList
            // 
            this.ACImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ACImageList.ImageStream")));
            this.ACImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ACImageList.Images.SetKeyName(0, "Functions");
            this.ACImageList.Images.SetKeyName(1, "Defines");
            // 
            // EditorDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Editor);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Name = "EditorDock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorDock_FormClosing);
            this.Load += new System.EventHandler(this.EditorDock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal BackgroundWorker RefreshWorker;
        public Scintilla Editor;
        internal AutocompleteMenu AutoCompleteMenu;
        internal ImageList ACImageList;
        internal BackgroundWorker colorizingWorker;
    }
}