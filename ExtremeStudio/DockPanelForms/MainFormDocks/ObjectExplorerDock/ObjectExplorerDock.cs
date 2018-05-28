using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExtremeCore.Classes;
using ExtremeParser;
using ExtremeStudio.DockPanelForms.MainFormDocks.EditorDock.AutoComplete;
using WeifenLuo.WinFormsUI.Docking;

namespace ExtremeStudio.DockPanelForms.MainFormDocks.ObjectExplorerDock
{
    public partial class ObjectExplorerDock : DockContent
    {
        public ObjectExplorerDock()
        {
            InitializeComponent();
        }

        TreeNodeStateSaver _nodeState = new TreeNodeStateSaver();

        #region Funcs

        [Localizable(false)]
        private dynamic GetTreeViewPart(CodeParts parser, string searchTerm, string tag)
        {
            if (ReferenceEquals(parser, null))
            {
                return null;
            }

            TreeNode mainNode = new TreeNode
            {
                Text = Path.GetFileNameWithoutExtension(Convert.ToString(parser.FilePath))
            };

            TreeNode defines = null;
            TreeNode macros = null;
            TreeNode functions = null;
            TreeNode publics = null;
            TreeNode stocks = null;
            TreeNode natives = null;

            if (parser.Defines.FindAll(x => x.DefineName.Contains(searchTerm)).Any())
            {
                defines = mainNode.Nodes.Add("Defines");
            }

            if (parser.Macros.FindAll(x => x.DefineName.Contains(searchTerm)).Any())
            {
                macros = mainNode.Nodes.Add("Macros");
            }

            if (parser.Functions.FindAll(x => x.FuncName.Contains(searchTerm)).Any())
            {
                functions = mainNode.Nodes.Add("Functions");
            }

            if (parser.Publics.FindAll(x => x.FuncName.Contains(searchTerm)).Any())
            {
                publics = mainNode.Nodes.Add("Publics");
            }

            if (parser.Stocks.FindAll(x => x.FuncName.Contains(searchTerm)).Any())
            {
                stocks = mainNode.Nodes.Add("Stocks");
            }

            if (parser.Natives.FindAll(x => x.FuncName.Contains(searchTerm)).Any())
            {
                natives = mainNode.Nodes.Add("Natives");
            }

            //Create the custom Roots.
            List<TreeNode> listCustom = new List<TreeNode>();
            foreach (var itm in Program.MainForm.CurrentProject.ObjectExplorerItems)
            {
                var bla = mainNode.Nodes.Add(itm.Name);
                bla.Tag = itm
                    .Identifier; //Here I set its tag to the identifer temporarly, It will be changed to `Root` again in Functions loop.
                listCustom.Add(bla);
            }

            //Start
            foreach (var key in parser.Defines.FindAll(x => x.DefineName.Contains(searchTerm)))
            {
                var nde = defines.Nodes.Add(key.DefineName);
                nde.ToolTipText = "Define Value: " + "\r\n" + key.DefineValue;
                nde.Tag = "define|" + tag;
            }

            foreach (var key in parser.Macros.FindAll(x => x.DefineName.Contains(searchTerm)))
            {
                var nde = macros.Nodes.Add(key.DefineName);
                nde.ToolTipText = "Define Value: " + "\r\n" + key.DefineValue;
                nde.Tag = "define|" + tag;
            }

            foreach (var funcs in parser.Functions.FindAll(x => x.FuncName.Contains(searchTerm)))
            {
                bool done = false;

                //Check if it crosponds to a custom one first.
                foreach (var itm in listCustom)
                {
                    if (funcs.FuncName.StartsWith((string)itm.Tag))
                    {
                        var node = itm.Nodes.Add(funcs.FuncName);
                        node.ToolTipText =
                            new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs)
                                .ToolTipText;
                        done = true; //To skip the `Else if it wasn't used.`
                        node.Tag = "function|" + tag;
                        break;
                    }
                }

                if (done)
                {
                    continue;
                }

                //Else if it wasn't used.
                var nde = functions.Nodes.Add(funcs.FuncName);
                nde.ToolTipText = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs)
                    .ToolTipText;
                nde.Tag = "function|" + tag;
            }

            foreach (var publicFunc in parser.Publics.FindAll(x => x.FuncName.Contains(searchTerm)))
            {
                bool done = false;

                //Check if it crosponds to a custom one first.
                foreach (var itm in listCustom)
                {
                    if (publicFunc.FuncName.StartsWith((string)itm.Tag))
                    {
                        var node = itm.Nodes.Add(publicFunc.FuncName);
                        node.ToolTipText =
                            new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc)
                                .ToolTipText;
                        done = true; //To skip the `Else if it wasn't used.`
                        node.Tag = "public|" + tag;
                        break;
                    }
                }

                if (done)
                {
                    continue;
                }

                //Else if it wasn't used.
                var nde = publics.Nodes.Add(publicFunc.FuncName);
                nde.ToolTipText = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc)
                    .ToolTipText;
                nde.Tag = "public|" + tag;
            }

            foreach (var stock in parser.Stocks.FindAll(x => x.FuncName.Contains(searchTerm)))
            {
                bool done = false;

                //Check if it crosponds to a custom one first.
                foreach (var itm in listCustom)
                {
                    if (stock.FuncName.StartsWith((string)itm.Tag))
                    {
                        var node = itm.Nodes.Add(stock.FuncName);
                        node.ToolTipText =
                            new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock)
                                .ToolTipText;
                        done = true; //To skip the `Else if it wasn't used.`
                        node.Tag = "stock|" + tag;
                        break;
                    }
                }

                if (done)
                {
                    continue;
                }

                //Else if it wasn't used.
                var nde = stocks.Nodes.Add(stock.FuncName);
                nde.ToolTipText = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock)
                    .ToolTipText;
                nde.Tag = "stock|" + tag;
            }

            foreach (var native in parser.Natives.FindAll(x => x.FuncName.Contains(searchTerm)))
            {
                bool done = false;

                //Check if it crosponds to a custom one first.
                foreach (var itm in listCustom)
                {
                    if (native.FuncName.StartsWith((string)itm.Tag))
                    {
                        var node = itm.Nodes.Add(native.FuncName);
                        node.ToolTipText =
                            new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native)
                                .ToolTipText;
                        done = true; //To skip the `Else if it wasn't used.`
                        node.Tag = "native|" + tag;
                        break;
                    }
                }

                if (done)
                {
                    continue;
                }

                //Else if it wasn't used.
                var nde = natives.Nodes.Add(native.FuncName);
                nde.ToolTipText = new AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native)
                    .ToolTipText;
                nde.Tag = "native|" + tag;
            }

            return mainNode;
        }

        [Localizable(false)]
        public void RefreshTreeView(CodeParts parts)
        {
            if (parts == null)
                return;

            //Save.
            _nodeState.SaveTreeState(treeView.Nodes);

            //Clear All.
            treeView.Nodes.Clear();

            //Start by adding the current file.
            TreeNode node = GetTreeViewPart(parts, Convert.ToString(SearchTextBox.Text), "current");
            node.Text = "Current File";
            if (node.Nodes.Count > 0)
            {
                treeView.Nodes.Add(node);
            }

            //Loop through all includes and put them.
            TreeNode parentNode = new TreeNode
            {
                Text = "Includes"
            };
            var allIncs = parts.FlattenIncludes();
            var codePartses = allIncs as CodeParts[] ?? allIncs.ToArray();
            for (int i = 1; i <= codePartses.Count() - 1; i++) //Loop through all skipping ID 0.
            {
                var nds = GetTreeViewPart(codePartses[i], Convert.ToString(SearchTextBox.Text),
                    Convert.ToString(codePartses[i].FilePath));
                if (nds.Nodes.Count > 0)
                {
                    parentNode.Nodes.Add(nds);
                }
            }

            //Add to list.
            if (parentNode.Nodes.Count > 0)
            {
                treeView.Nodes.Add(parentNode);
            }

            _nodeState.RestoreTreeState(treeView); //Restore
        }

        #endregion

        private void ObjectExplorerDock_Load(object sender, EventArgs e)
        {
            if (Program.MainForm.CurrentEditor != null)
            {
                RefreshTreeView(Program.MainForm.CurrentEditor.CodeParts);
            }
        }

        private void EditItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ObjectExplorerDockItems().ShowDialog();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshTreeView(Program.MainForm?.CurrentEditor?.CodeParts);
        }

        private void SearchTextBox_Changed(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                Label1.Visible = true;
            }
            else
            {
                Label1.Visible = false;
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            SearchTextBox.Focus();
        }

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                RefreshTreeView(Program.MainForm.CurrentEditor.CodeParts);
                e.Handled = true;
            }
        }

        private void FindAndGoto(string rgx)
        {
            if (ReferenceEquals(Program.MainForm.CurrentScintilla, null))
            {
                return;
            }

            var match = Regex.Match(Program.MainForm.CurrentScintilla.GetTextRange(0, Program.MainForm.CurrentScintilla.TextLength),
                rgx, RegexOptions.Multiline);
            if (match.Index != 0 && match.Length != 0)
            {
                Program.MainForm.CurrentScintilla.SetSelection(match.Index, match.Index + match.Length);
                Program.MainForm.CurrentScintilla.ScrollCaret();
            }

            //I could have just used ScintillaNEts regex here but it for some reason doesn't provide multiline regex which is needed for accurancy.
        }

        [Localizable(false)]
        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            string filepath = Convert.ToString(((string)e.Node.Tag).Split('|')[1]);
            if (filepath != "current")
            {
                //First, Loop throuhg all opened tabs and see if its already opened there.
                bool isFound = false;
                foreach (var doc in Program.MainForm.MainDock.Documents)
                {
                    if ((string)doc.DockHandler.Form.Controls["Editor"].Tag == filepath)
                    {
                        doc.DockHandler.Activate();
                        isFound = true;
                    }
                }

                if (isFound == false)
                {
                    //If not found, Open that file.
                    Program.MainForm.OpenFile(filepath);
                }
            }

            if (((string)e.Node.Tag).StartsWith("define"))
            {
                FindAndGoto("^[ \\t]*[#]define[ \\t]+" + Regex.Escape(e.Node.Text) +
                            "[ \\t]+(?:\\\\\\s+)?(?>(?<value>[^\\\\\\n\\r]+)[ \\t]*(?:\\\\\\s+)?)*");
            }
            else if (((string)e.Node.Tag).StartsWith("function"))
            {
                FindAndGoto("^[ \\t]*(?:\\sstatic\\s+stock\\s+|\\sstock\\s+static\\s+|\\sstatic\\s+)?" +
                            Regex.Escape(e.Node.Text) + "\\((.*)\\)(?!;)\\s*{");
            }
            else if (((string)e.Node.Tag).StartsWith("public"))
            {
                FindAndGoto("public[ \\t]+" + Regex.Escape(e.Node.Text) + "[ \\t]*\\((.*)\\)\\s*{");
            }
            else if (((string)e.Node.Tag).StartsWith("stock"))
            {
                FindAndGoto("stock[ \\t]+" + Regex.Escape(e.Node.Text) + "[ \\t]*\\((.*)\\)\\s*{");
            }
            else if (((string)e.Node.Tag).StartsWith("native"))
            {
                FindAndGoto("native[ \\t]+" + Regex.Escape(e.Node.Text) + "[ \\t]*?\\((.*)\\);");
            }
        }
    }
}