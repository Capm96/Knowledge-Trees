using Microsoft.Office.Interop.Word;
using System;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    public partial class createLeafForm : Form
    {
        knowledgeTreesDashboard callingDashboard;
        string parentTreeName;

        public createLeafForm(knowledgeTreesDashboard dashboard, string nameOfCallingTree)
        {
            InitializeComponent();

            callingDashboard = dashboard;
            parentTreeName = nameOfCallingTree;
        }

        private void createNewLeafButton_Click(object sender, EventArgs e)
        {
            string leafName = "";
            string errorMessage = LeafNameValidator();

            if (errorMessage.Length == 0)
            {
                leafName = leafNameValue.Text;

                // Gets full leaf path.
                string treePath = GlobalConfig.currentWorkingPath + $@"\{parentTreeName}\";
                string leafPath = FolderLogic.GetFullLeafName(leafName);
                string fullPath = treePath + leafPath;

                // Instantiates new word document on full leaf path, and inserts default text.
                Word.Application application = new Word.Application();

                Document newLeaf = application.Documents.Add();

                Range range = newLeaf.Range(0, 0);
                range.Text = $"Welcome to your {leafName} Leaf in the {parentTreeName} Tree! Delete this message and write anything you'd like. " +
                $"Do not forget to always hit the Save button when you are done writing. " +
                $"One last thing: try to always use the 'Save' button instead of 'Save As'. Just to make sure your leaf is in its proper tree.";

                // Saves newly created document.
                newLeaf.SaveAs2(fullPath);

                // Opens document.
                Document wordDocument = application.Documents.Open(fullPath);

                // Wires up dashboard with new leaf.
                callingDashboard.WireUpLeavesList();
                this.Close();
            }
            else
            {
                MessageBox.Show($"{errorMessage}", "Invalid input");
                return;
            }
        }

        private string LeafNameValidator()
        {
            string output = "";

            // Checks if there is a name without any characters.
            if (leafNameValue.Text.Length == 0) 
            {
                output = "Please enter a valid Leaf name.";
            }

            string[] currentLeafNames = FolderLogic.GetAllLeafNamesWithNoExtension(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, parentTreeName));

            for (int i = 0; i < currentLeafNames.Length; i++) 
            {
                // Checks for equal names, regardless of casing.
                if (Validator.IsLowerCaseVersionEquals(leafNameValue.Text, currentLeafNames[i].ToString()))
                {
                    output = "This name already exists, please enter another name.";
                }
            }

            string nameToBeChecked = leafNameValue.Text.ToString();

            // Checks for any non-alphabetic characters.
            foreach (char character in nameToBeChecked) 
            {
                if (Validator.IsEnglishLetter(character) == false)
                {
                    output = "Please enter a valid Leaf name (only alphabetic characters)";
                }
            }

            return output;
        }
    }
}
