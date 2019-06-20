using System;
using System.Drawing;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using TreesLibrary;
using System.IO;
using System.Collections.Generic;

namespace KnowledgeTrees
{
    public partial class knowledgeTreesDashboard : Form
    {
        public List<string> openedWordDocuments = new List<string>();

        public Dictionary<string, string> themeColors = new Dictionary<string, string>();

        public bool IsThemeDark = false;

        public knowledgeTreesDashboard()
        {
            InitializeComponent();

            // Populates our lists.
            WireUpTreesList();
            WireUpLeavesList();

            // Fill in dictionary with colors we want.
            FillInThemeColors();
        }

        private void FillInThemeColors()
        {
            // Update dark theme colors.
            themeColors.Add("DarkBackground", "#373134");
            themeColors.Add("DarkButtons", "#299FB5");
            themeColors.Add("DarkLabels", "#299FB5");
            themeColors.Add("DarkLabelsText", "#cfcfcf");
            themeColors.Add("DarkLists", "#C2C2C2");
            themeColors.Add("DarkTexts", "#C2C2C2");

            // Update default theme colors.
            themeColors.Add("DefaultBackground", "#ffffff");
            themeColors.Add("DefaultButtons", "#58d68d");
            themeColors.Add("DefaultLabels", "#229954");
            themeColors.Add("DefaultLabelsText", "#9c9999");
            themeColors.Add("DefaultLists", "#ffffff");
            themeColors.Add("DefaultTexts", "#ffffff");
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

        private void createTreeButton_Click(object sender, EventArgs e)
        {
            bool isOpen = CheckIfFormIsOpen("Create New Tree");

            if (isOpen == false)
            {
                createTreeForm form = new createTreeForm(this);
                form.UpdateTheme(this, themeColors);
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
                    form.UpdateTheme(this, themeColors);
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
                    form.UpdateTheme(this, themeColors);
                    form.Show();
                }
            }
        }

        private void viewLeafButton_Click(object sender, EventArgs e)
        {
            List<string> openedWordDocuments = WordProcessor.CheckOpenedWordDocuments();

            bool isDocOpen = false;

            if (leavesListBox.SelectedItem != null)
            {
                // Gets full leaf path.
                string path = WordProcessor.GetFullLeafPath(treesListBox.SelectedItem.ToString(), leavesListBox.SelectedItem.ToString());

                // Checks if current file is already open.
                foreach (string name in openedWordDocuments)
                {
                    if (name.Equals(path))
                        isDocOpen = true;
                }

                if (isDocOpen)
                {
                    MessageBox.Show($"This leaf is already open, check your open word documents.", "Leaf Already Opened");
                    return;
                }
                else // Open leaf.
                {
                    try
                    {
                        Microsoft.Office.Interop.Word.Application wordApp;

                        // Instantiates a new word application if there is none.
                        if (openedWordDocuments.Count == 0)
                        {
                            wordApp = new Microsoft.Office.Interop.Word.Application();
                            wordApp.Visible = true;
                            Document wordDocument = wordApp.Documents.Open(path);

                            this.WindowState = FormWindowState.Minimized;
                        }
                        else // Opens from existing word application.
                        {
                            wordApp = WordProcessor.CreateWordDocumentFromExistingInstance(path);

                            this.WindowState = FormWindowState.Minimized;
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
                        treesListBox_SelectedIndexChanged(sender, e);
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
                    openedWordDocuments = WordProcessor.CheckOpenedWordDocuments();

                    if (openedWordDocuments.Count > 0)
                    {
                        MessageBox.Show("Please close all leaves before deleting", "Close Opened Leaves");
                        return;
                    }

                    string path = WordProcessor.GetFullLeafPath(treesListBox.SelectedItem.ToString(), leavesListBox.SelectedItem.ToString());

                    FolderLogic.DeleteLeaf(path);

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
            if (treesListBox.SelectedItem != null)
            {
                // Update Leaves list when we move between items in Tree list.
                WireUpLeavesList();
                leavesLabel.Text = $"{treesListBox.SelectedItem.ToString()} Leaves";
            }
            else
            {
                WireUpLeavesList();
                leavesLabel.Text = $"Leaves List";
            }
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

            // Checks if we need to increase the horizontal extent (to allow for horizontal scrollbar).
            int newHorizontalExtent = (int)(e.Graphics.MeasureString(treesListBox.SelectedItem.ToString(), e.Font).Width + 2);

            if (treesListBox.HorizontalExtent < newHorizontalExtent)
            {
                treesListBox.HorizontalExtent = newHorizontalExtent;
            }
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

            // Checks if we need to increase the horizontal extent (to allow for horizontal scrollbar).
            int newHorizontalExtent = (int)(e.Graphics.MeasureString(leavesListBox.SelectedItem.ToString(), e.Font).Width + 2);

            if (leavesListBox.HorizontalExtent < newHorizontalExtent)
            {
                leavesListBox.HorizontalExtent = newHorizontalExtent;
            }
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            Credits form = new Credits();
            form.Show();
        }

        private void changeTheme_Click(object sender, EventArgs e)
        {
            ChangeTheme();
        }

        // TODO: Create a checker on theme button to see if there is more than one form open -- if yes, close
        // all before changing theme.

        // To check: Upper forms bar (with closing buttons) / dialogue boxes. see if its possible to change these colors.

        // Fix individual buttons / labels which are being generically modified.

        private void ChangeTheme()
        {
            if (IsThemeDark)
            {
                this.UpdateTheme(this, themeColors);
                IsThemeDark = false;
            }
            else
            {
                this.UpdateTheme(this, themeColors);
                IsThemeDark = true;
            }

            // Gives option for user to select their own colors.
            //ColorDialog cd = new ColorDialog();
            //if (cd.ShowDialog() == DialogResult.OK)
            //    this.BackColor = cd.Color;
        }

        //private void UpdateColors()
        //{
        //    // Get colors (https://htmlcolorcodes.com/)
        //    Color backgroundColor = ColorTranslator.FromHtml("#373134");
        //    ChangeBackgroundsColor(backgroundColor);

        //    Color buttonsColor = ColorTranslator.FromHtml("#299FB5");
        //    ChangeButtonsColor(buttonsColor);

        //    Color labelsColor = ColorTranslator.FromHtml("#1A8A9F");
        //    ChangeLabelsColor(buttonsColor);

        //    Color listsColor = ColorTranslator.FromHtml("#C2C2C2");
        //    ChangeListsColor(listsColor);

        //}

        //private void ChangeListsColor(Color listsColor)
        //{
        //    if (IsThemeDark)
        //    {
        //        leavesListBox.BackColor = Color.White;
        //        treesListBox.BackColor = Color.White;
        //    }
        //    else
        //    {
        //        treesListBox.BackColor = listsColor;
        //        leavesListBox.BackColor = listsColor;
        //    }
        //}

        //private void ChangeButtonsColor(Color darkThemeColor)
        //{
        //    if (IsThemeDark)
        //    {
        //        createTreeButton.BackColor = Color.LightGreen;
        //        removeTreeButton.BackColor = Color.LightGreen;
        //        viewTreeButton.BackColor = Color.LightGreen;
        //        createLeafButton.BackColor = Color.LightGreen;
        //        removeLeafButton.BackColor = Color.LightGreen;
        //        viewLeafButton.BackColor = Color.LightGreen;
        //    }
        //    else
        //    {
        //        createTreeButton.BackColor = darkThemeColor;
        //        removeTreeButton.BackColor = darkThemeColor;
        //        viewTreeButton.BackColor = darkThemeColor;
        //        createLeafButton.BackColor = darkThemeColor;
        //        removeLeafButton.BackColor = darkThemeColor;
        //        viewLeafButton.BackColor = darkThemeColor;
        //    }
        //}

        //private void ChangeBackgroundsColor(Color darkThemeColor)
        //{
        //    if (IsThemeDark)
        //    {
        //        this.BackColor = Color.White;
        //    }
        //    else
        //    {
        //        this.BackColor = darkThemeColor;
        //    }
        //}

        //private void ChangeLabelsColor(Color darkThemeColor)
        //{
        //    if (IsThemeDark)
        //    {
        //        treesLabel.BackColor = Color.ForestGreen;
        //        leavesLabel.BackColor = Color.ForestGreen;
        //        dashboardLabel.BackColor = Color.ForestGreen;

        //        treesLabel.ForeColor = Color.White;
        //        leavesLabel.ForeColor = Color.White;
        //        dashboardLabel.ForeColor = Color.White;
        //    }
        //    else
        //    {
        //        treesLabel.ForeColor = Color.Black;
        //        leavesLabel.ForeColor = Color.Black;
        //        dashboardLabel.ForeColor = Color.Black;

        //        treesLabel.BackColor = darkThemeColor;
        //        leavesLabel.BackColor = darkThemeColor;
        //        dashboardLabel.BackColor = darkThemeColor;
        //    }
        //}
    }
}
