using System.Collections.Generic;
using System.Windows.Forms;

namespace ExtremeCore.Classes
{
    public class TreeNodeStateSaver
    {
        private List<string> _nodeStates;

        public void SaveTreeState(TreeNodeCollection nodes, bool newFunc = true)
        {
            if (newFunc)
                _nodeStates = new List<string>();
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded)
                {
                    _nodeStates.Add(node.Text);
                    SaveTreeState(node.Nodes, false);
                }
            }
        }

        public void RestoreTreeState(TreeView tree)
        {
            foreach (string nodeName in _nodeStates)
                RecurseNodes(tree, nodeName);
            _nodeStates = null; // Clear
        }

        private void RecurseNodes(TreeView treeView, string searchValue)
        {
            foreach (TreeNode tn in treeView.Nodes)
            {
                if (tn.Text == searchValue)
                {
                    tn.Expand();
                    break;
                }

                if (tn.Nodes.Count > 0)
                {
                    foreach (TreeNode cTn in tn.Nodes)
                        RecurseChildren(cTn, searchValue);
                }
            }
        }

        private void RecurseChildren(TreeNode tn, string searchValue)
        {
            if (tn.Text == searchValue)
            {
                tn.Expand();
                return;
            }

            if (tn.Nodes.Count > 0)
            {
                foreach (TreeNode tnC in tn.Nodes)
                    RecurseChildren(tnC, searchValue);
            }
        }
    }
}
