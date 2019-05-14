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
    public partial class leafEditor : Form
    {
        knowledgeTreesDashboard callingDashboard;

        string fullLeafName; // including .rtf extension.
        string leafName;
        string treeName;

        public leafEditor(knowledgeTreesDashboard dashboard, string nameOfLeaf, string nameOfTree)
        {
            InitializeComponent();

            treeName = nameOfTree;
            leafName = nameOfLeaf;
            fullLeafName = FolderLogic.GetFullLeafName(nameOfLeaf);

            callingDashboard = dashboard;

            DisplayWelcomeTextMessage();
            DisplayLeafAndTreeNamesInTitle();
        }

        public leafEditor()
        {
            InitializeComponent();
        }

        private void saveLeafButton_Click(object sender, EventArgs e)
        {
            textControl1.Save(GlobalConfig.currentPath + $@"\{treeName}\{fullLeafName}", TXTextControl.StreamType.RichTextFormat);
            MessageBox.Show($"The {leafName} Leaf has been saved. You may exit if you wish.", "Save Successful");

            callingDashboard.WireUpLeavesList();
        }

        public void LoadExistingLeaf(string treePath, string leafName)
        {
            textControl1.Load(GlobalConfig.currentPath + $@"\{treeName}\{fullLeafName}", TXTextControl.StreamType.RichTextFormat);
            this.Show();
        }

        public void DisplayWelcomeTextMessage()
        {
            textControl1.Text = $"Welcome to your {leafName} Leaf in the {treeName} Tree! Delete this message and write anything you'd like. " +
                $"DO NOT FORGET to always hit the Save button above when you are done writing, as this will ensure your Leaf is properly saved.";
        }

        public void DisplayLeafAndTreeNamesInTitle()
        {
            this.Text = $"{treeName} -- {leafName} ";
        }
    }
}
