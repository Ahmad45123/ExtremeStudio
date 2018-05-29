using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using Resources;
using ScintillaNET;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.EditorFunctions
{
    partial class SearchReplaceForm : Form
    {
        public SearchReplaceForm()
        {
            InitializeComponent();
        }

        #region General

        private void findCloseBtn_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Visible = false;
                return true;
            }

            if (keyData == (Keys.Control | Keys.Space))
            {
                replaceReplaceBtn.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SearchReplaceForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1.00;
        }

        private void SearchReplaceForm_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.50;
        }

        private void SearchReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

        #endregion

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                searchFindText.Select();
                AcceptButton = searchFindBtn;
            }
            else if (e.TabPageIndex == 1)
            {
                replaceFindText.Select();
                AcceptButton = replaceFindNextBtn;
            }
        }

        public void ResetSettings()
        {
            //Set targets.
            if (inSelCheck.Checked == false)
            {
                Program.MainForm.CurrentScintilla?.TargetWholeDocument();
            }
            else
            {
                Program.MainForm.CurrentScintilla?.TargetFromSelection();
            }

            //Set configs.
            Program.MainForm.CurrentScintilla.SearchFlags = SearchFlags.None;
            if (searchNormalRadio.Checked == false && searchRegexRadio.Checked)
            {
                Program.MainForm.CurrentScintilla.SearchFlags = SearchFlags.Regex;
            }

            if (matchWholeWordCheck.Checked)
            {
                Program.MainForm.CurrentScintilla.SearchFlags = Program.MainForm.CurrentScintilla.SearchFlags | SearchFlags.WholeWord;
            }

            if (matchCaseCheck.Checked)
            {
                Program.MainForm.CurrentScintilla.SearchFlags = Program.MainForm.CurrentScintilla.SearchFlags | SearchFlags.MatchCase;
            }
        }

        private void searchCountBtn_Click(object sender, EventArgs e)
        {
            if (searchFindText.Text == "")
            {
                return;
            }

            ResetSettings();

            int numberOfTimes = 0;
            while (Program.MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) != -1)
            {
                numberOfTimes++;

                //Prepare For Next.
                Program.MainForm.CurrentScintilla.TargetStart =
                    Program.MainForm.CurrentScintilla.TargetEnd; //Start from the last end and continue to end.
                Program.MainForm.CurrentScintilla.TargetEnd = Program.MainForm.CurrentScintilla.TextLength;
            }

            MessageBox.Show(Convert.ToString(
                translations.SearchReplaceForm_searchCountBtn_Click_NumberItemsFound + numberOfTimes));
        }

        bool _isAlreadySearching;

        public void SearchAndMark(string searchText, bool opposite = false)
        {
            //Only reset the settings if its new, or else:
            //If its old, Just go with old settings to find literally next.
            if (_isAlreadySearching == false)
            {
                ResetSettings();
            }
            else
            {
                //Prepare For Next:
                if (opposite)
                {
                    Program.MainForm.CurrentScintilla.TargetStart = Math.Min(Program.MainForm.CurrentScintilla.CurrentPosition,
                        Program.MainForm.CurrentScintilla.AnchorPosition);
                    Program.MainForm.CurrentScintilla.TargetEnd = 0;
                }
                else
                {
                    Program.MainForm.CurrentScintilla.TargetStart = Math.Max(Program.MainForm.CurrentScintilla.CurrentPosition,
                        Program.MainForm.CurrentScintilla.AnchorPosition);
                    Program.MainForm.CurrentScintilla.TargetEnd = Program.MainForm.CurrentScintilla.TextLength;
                }
            }

            //No WHILE because we don't want to get all but just the next.
            if (Program.MainForm.CurrentScintilla?.SearchInTarget(searchText) != -1)
            {
                //First set the selection:
                Program.MainForm.CurrentScintilla?.SetSelection(Program.MainForm.CurrentScintilla.TargetStart,
                    Program.MainForm.CurrentScintilla.TargetEnd);

                //Scroll to it:
                Program.MainForm.CurrentScintilla?.ScrollCaret();
                //Set the var to true:
                _isAlreadySearching = true;
            }
            else
            {
                Program.MainForm.ShowStatus(translations.SearchReplaceForm_SearchAndMark_ReachedEndDocument, 2000, true);
                _isAlreadySearching = false;
            }
        }

        private void searchFindText_TextChanged(object sender, EventArgs e)
        {
            //New search is being done:
            _isAlreadySearching = false;
        }

        private void seachFindBtn_Click(object sender, EventArgs e)
        {
            if (searchFindText.Text == "")
            {
                return;
            }

            SearchAndMark(Convert.ToString(searchFindText.Text));
        }

        public List<KeyValuePair<int, int>> travelList = new List<KeyValuePair<int, int>>();

        private void searchFindAllBtn_Click(object sender, EventArgs e)
        {
            if (searchFindText.Text == "")
            {
                return;
            }

            ResetSettings();
            Program.MainForm.CurrentScintilla.IndicatorClearRange(0, Program.MainForm.CurrentScintilla.TextLength);
            travelList.Clear();

            int numberOfTimes = 0;
            while (Program.MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) != -1)
            {
                numberOfTimes++;

                //Mark the found.
                Program.MainForm.CurrentScintilla.IndicatorCurrent = (int)EditorDock.IndicatorIDs.IndicatorSearchItem;
                Program.MainForm.CurrentScintilla.IndicatorFillRange(Program.MainForm.CurrentScintilla.TargetStart,
                    Program.MainForm.CurrentScintilla.TargetEnd - Program.MainForm.CurrentScintilla.TargetStart);

                //Add to the travel list to enable CTRL+SHIFT+N fast-travelling.
                travelList.Add(new KeyValuePair<int, int>(Program.MainForm.CurrentScintilla.TargetStart,
                    Program.MainForm.CurrentScintilla.TargetEnd));

                //Prepare For Next.
                Program.MainForm.CurrentScintilla.TargetStart =
                    Program.MainForm.CurrentScintilla.TargetEnd; //Start from the last end and continue to end.
                Program.MainForm.CurrentScintilla.TargetEnd = Program.MainForm.CurrentScintilla.TextLength;
            }

            MessageBox.Show(Convert.ToString(
                translations.SearchReplaceForm_searchCountBtn_Click_NumberItemsFound + numberOfTimes +
                "\r\n" + "\r\n" + translations.SearchReplaceForm_searchFindAllBtn_Click_UseKeysForTravel));
        }

        private void replaceFindNextBtn_Click(object sender, EventArgs e)
        {
            if (replaceFindText.Text == "")
            {
                return;
            }

            SearchAndMark(Convert.ToString(replaceFindText.Text));
        }

        private void replaceFindText_replaceReplaceText_TextChanged(object sender, EventArgs e)
        {
            _isAlreadySearching = false;
        }

        private void replaceReplaceBtn_Click(object sender, EventArgs e)
        {
            if (_isAlreadySearching)
            {
                if (searchRegexRadio.Checked)
                {
                    Program.MainForm.CurrentScintilla.ReplaceTargetRe(replaceReplaceText.Text);
                }
                else
                {
                    Program.MainForm.CurrentScintilla.ReplaceTarget(replaceReplaceText.Text);
                }

                replaceFindNextBtn.PerformClick();
            }
        }

        private void replaceReplaceAllBtn_Click(object sender, EventArgs e)
        {
            if (replaceFindText.Text == "")
            {
                return;
            }

            ResetSettings();

            int numberOfTimes = 0;
            while (Program.MainForm.CurrentScintilla?.SearchInTarget(replaceFindText.Text) != -1)
            {
                numberOfTimes++;

                //Replace
                if (searchRegexRadio.Checked)
                {
                    Program.MainForm.CurrentScintilla.ReplaceTargetRe(replaceReplaceText.Text);
                }
                else
                {
                    Program.MainForm.CurrentScintilla.ReplaceTarget(replaceReplaceText.Text);
                }

                //Prepare For Next.
                Program.MainForm.CurrentScintilla.TargetStart =
                    Program.MainForm.CurrentScintilla.TargetEnd; //Start from the last end and continue to end.
                Program.MainForm.CurrentScintilla.TargetEnd = Program.MainForm.CurrentScintilla.TextLength;
            }

            MessageBox.Show(Convert.ToString(
                translations.SearchReplaceForm_replaceReplaceAllBtn_Click_NumberItemsReplaced +
                numberOfTimes));
        }
    }
}