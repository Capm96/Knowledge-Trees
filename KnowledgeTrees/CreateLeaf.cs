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

                leafEditor form = new leafEditor(callingDashboard, leafName, parentTreeName);
                form.Show(); // We call our Leaf Editor form immediately after creating a new Leaf.
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
