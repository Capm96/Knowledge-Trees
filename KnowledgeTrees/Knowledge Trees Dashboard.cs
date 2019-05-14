using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    public partial class knowledgeTreesDashboard : Form
    {
        public knowledgeTreesDashboard()
        {
            InitializeComponent();

            WireUpTreesList();
            WireUpLeavesList();
        }

        public void WireUpTreesList()
        {
            string[] allTreePaths = FolderLogic.GetAllTreePaths(GlobalConfig.currentPath);
            string[] allTreeNames = FolderLogic.GetAllTreeNames(GlobalConfig.currentPath);

            GlobalConfig.trees.Clear();

            for (int i = 0; i < allTreePaths.Length; i++)
            {
                GlobalConfig.trees.Add(allTreeNames[i], allTreePaths[i]); // Adds to a dictionary type the key (tree name) and value (tree path).
            }

            treesListBox.DataSource = allTreeNames;
            treesListBox.HorizontalScrollbar = true;
        }

        public void WireUpLeavesList()
        {
            if (treesListBox.SelectedItem != null)
            {
                string parentTreeName = treesListBox.SelectedItem.ToString();
                leavesListBox.DataSource = FolderLogic.GetAllLeafNamesWithNoExtension(FolderLogic.GetFullTreePath(GlobalConfig.currentPath, parentTreeName));
            }
        }

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            createTreeForm form = new createTreeForm(this);
            form.Show();
        }

        private void createLeafButton_Click(object sender, EventArgs e)
        {
            if (treesListBox.SelectedItem != null)
            {
                string selectedTreeName = treesListBox.SelectedItem.ToString();

                createLeafForm form = new createLeafForm(this, selectedTreeName);
                form.Show();
            }
        }

        private void viewTreeButton_Click(object sender, EventArgs e)
        {
            if (treesListBox.SelectedItem != null)
            {
                treeView form = new treeView(this, treesListBox.SelectedItem.ToString());
                form.Show();
            }
        }

        private void viewLeafButton_Click(object sender, EventArgs e)
        {
            if (leavesListBox.SelectedItem != null)
            {
                leafEditor form = new leafEditor(this, leavesListBox.SelectedItem.ToString(), treesListBox.SelectedItem.ToString());
                form.Show();
                form.LoadExistingLeaf(GlobalConfig.currentPath + $@"\{treesListBox.SelectedItem.ToString()}", $"{leavesListBox.SelectedItem.ToString()}");
            }
        }

        private void removeTreeButton_Click(object sender, EventArgs e)
        {
            if (treesListBox.SelectedItem != null)
            {
                var confirmResult = MessageBox.Show($"Are you sure you want to delete {treesListBox.SelectedItem}? Every leaf in the tree will also be deleted. This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    FolderLogic.DeleteTree(FolderLogic.GetFullTreePath(GlobalConfig.currentPath, treesListBox.SelectedItem.ToString()));

                    WireUpTreesList();
                    WireUpLeavesList();
                }
                else
                {
                    return;
                } 
            }
        }

        private void removeLeafButton_Click(object sender, EventArgs e)
        {
            if (leavesListBox.SelectedItem != null)
            {
                var confirmResult = MessageBox.Show($"Are you sure you want to delete {leavesListBox.SelectedItem}? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    string fullTreePath = FolderLogic.GetFullTreePath(GlobalConfig.currentPath, treesListBox.SelectedItem.ToString());
                    string fullLeafName = String.Concat(@"\", FolderLogic.GetFullLeafName(leavesListBox.SelectedItem.ToString()));
                    string fullLeafPath = String.Concat(fullTreePath, fullLeafName);

                    FolderLogic.DeleteLeaf(fullLeafPath);

                    WireUpTreesList();
                    WireUpLeavesList();
                }
                else
                {
                    return;
                }
            }
        }

        private void treesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WireUpLeavesList(); // Updates leaves list when we move between items in tree list.
        }
    }
}
