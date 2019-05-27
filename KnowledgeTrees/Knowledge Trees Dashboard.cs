using System;
using System.Drawing;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using TreesLibrary;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KnowledgeTrees
{
    public partial class knowledgeTreesDashboard : Form
    {
        List<string> openedWordDocuments = new List<string>();

        public knowledgeTreesDashboard()
        {
            InitializeComponent();

            // Populates our lists.
            WireUpTreesList();
            WireUpLeavesList();
        }

        public void WireUpTreesList()
        {
            string[] allTreePaths = FolderLogic.GetAllTreePaths(GlobalConfig.currentWorkingPath);
            string[] allTreeNames = FolderLogic.GetAllTreeNames(GlobalConfig.currentWorkingPath);

            GlobalConfig.trees.Clear();

            for (int i = 0; i < allTreePaths.Length; i++)
            {
                // Add to our Tree Dictionary the key (Tree name) and value (Tree path).
                GlobalConfig.trees.Add(allTreeNames[i], allTreePaths[i]); 
            }

            treesListBox.DataSource = allTreeNames;
            treesListBox.HorizontalScrollbar = true;
        }

        public void WireUpLeavesList()
        {
            if (treesListBox.SelectedItem != null)
            {
                string parentTreeName = treesListBox.SelectedItem.ToString();
                leavesListBox.DataSource = FolderLogic.GetAllLeafNamesWithNoExtension(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, parentTreeName));
            }
            if (treesListBox.SelectedItem == null)
            {
                leavesListBox.DataSource = null;
            }
        }

        private static bool CheckIfFormIsOpen(string formName)
        {
            bool output = false;

            foreach (Form form in System.Windows.Forms.Application.OpenForms)
            {
                if (form.Text == formName)
                {
                    output = true;
                    form.BringToFront();
                    break;
                }
            }

            return output;
        }

        private static List<string> CheckOpenedWordDocuments()
        {
            List<string> documents = new List<string>();

            try
            {
                Window objectWindow;
                Microsoft.Office.Interop.Word.Application wordObject;
                wordObject = (Microsoft.Office.Interop.Word.Application)Marshal.GetActiveObject("Word.Application");
                for (int i = 0; i < wordObject.Windows.Count; i++)
                {
                    object a = i + 1;
                    objectWindow = wordObject.Windows.get_Item(ref a);
                    documents.Add(objectWindow.Document.FullName);
                }
                objectWindow = null;

            }
            catch
            {
                // No documents opened
            }

            return documents;
        }

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            bool isOpen = CheckIfFormIsOpen("Create New Tree");

            if (isOpen == false)
            {
                createTreeForm form = new createTreeForm(this);
                form.Show();
            }
        }

        private void createLeafButton_Click(object sender, EventArgs e)
        {
            bool isOpen = CheckIfFormIsOpen("Create New Leaf");

            if (isOpen == false)
            {
                if (treesListBox.SelectedItem != null)
                {
                    string selectedTreeName = treesListBox.SelectedItem.ToString();

                    createLeafForm form = new createLeafForm(this, selectedTreeName);
                    form.Show();
                }
            }
        }

        private void viewTreeButton_Click(object sender, EventArgs e)
        {
            bool isOpen = CheckIfFormIsOpen("Tree View");

            if (isOpen == false)
            {
                if (treesListBox.SelectedItem != null)
                {
                    treeView form = new treeView(this, treesListBox.SelectedItem.ToString());
                    form.Show();
                }
            }
        }

        private void viewLeafButton_Click(object sender, EventArgs e) // TODO: Don't let another one open if its already.
        {
            List<string> openedWordDocuments = CheckOpenedWordDocuments();

            bool isDocOpen = false;

            if (leavesListBox.SelectedItem != null)
            {
                // Gets full leaf path.
                string treePath = GlobalConfig.currentWorkingPath + $@"\{treesListBox.SelectedItem.ToString()}\";
                string leafPath = FolderLogic.GetFullLeafName(leavesListBox.SelectedItem.ToString());
                string path = treePath + leafPath;

                // Checks if current file is already open.
                foreach (string name in openedWordDocuments)
                {
                    if (name.Equals(path))
                        isDocOpen = true;
                }

                if (isDocOpen)
                {
                    MessageBox.Show($"This word document is already open", "Word Doc Already Opened");
                    return;
                }
                else
                {
                    // Opens leaf.
                    try
                    {
                        Microsoft.Office.Interop.Word.Application wordApp;

                        if (openedWordDocuments.Count == 0)
                        {
                            wordApp = new Microsoft.Office.Interop.Word.Application();
                            wordApp.Visible = true;
                            Document wordDocument = wordApp.Documents.Open(path);
                        }
                        else
                        {
                            wordApp = (Microsoft.Office.Interop.Word.Application)Marshal.GetActiveObject("Word.Application");
                            object inputFile = path;
                            object confirmConversions = false;
                            object readOnly = false;
                            object visible = true;
                            object missing = Type.Missing;

                            Document doc = wordApp.Documents.Open(
                                ref inputFile, ref confirmConversions, ref readOnly, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref visible,
                                ref missing, ref missing, ref missing, ref missing);
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"{ex}", "Error");
                    }
                }
            }
        }

        private void removeTreeButton_Click(object sender, EventArgs e)
        {
            if (treesListBox.SelectedItem != null)
            {
                // Prompt deletion message:
                var confirmResult = MessageBox.Show($"Are you sure you want to delete {treesListBox.SelectedItem}? Every leaf in the tree will also be deleted. This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes) // Delete tree.
                {
                    try
                    {
                        FolderLogic.DeleteTree(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treesListBox.SelectedItem.ToString()));

                        // Update lists.
                        WireUpTreesList();
                        WireUpLeavesList();
                    }
                    catch
                    {
                        MessageBox.Show("Please close all word documents before deleting tree.", "Word Documents Open");
                    }
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
                    // Get full path of selected Tree, the name of current selected Leaf, and create the full Leaf path
                    // Which we will use to delete it.
                    string fullTreePath = FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treesListBox.SelectedItem.ToString());
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
            // Update Leaves list when we move between items in Tree list.
            WireUpLeavesList();
            leavesLabel.Text = $"{treesListBox.SelectedItem.ToString()} Leaves";
        }

        private void treesListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            // If the item state is selected them change the back color.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics,
                                          new System.Drawing.Font("Segoe UI", 16.2f, FontStyle.Bold),
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.LightGray); //Choose the color
            }

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text.
            e.Graphics.DrawString(treesListBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void leavesListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          new System.Drawing.Font("Segoe UI", 16.2f, FontStyle.Bold),
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.LightGray);

            e.DrawBackground();
            e.Graphics.DrawString(leavesListBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            Credits form = new Credits();
            form.Show();
        }
    }
}
