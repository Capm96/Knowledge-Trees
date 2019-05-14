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

        public createLeafForm(knowledgeTreesDashboard dashboard, string nameOfTree)
        {
            InitializeComponent();

            callingDashboard = dashboard;
            parentTreeName = nameOfTree;
        }

        private void createNewLeafButton_Click(object sender, EventArgs e)
        {
            string leafName = "";
            string errorMessage = LeafNameValidator();

            if (errorMessage.Length == 0)
            {
                leafName = leafNameValue.Text;

                leafEditor form = new leafEditor(callingDashboard, leafName, parentTreeName);
                form.Show();

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

            if (leafNameValue.Text.Length == 0) // Checks if there is a name without any characters.
            {
                output = "Please enter a valid Leaf name.";
            }

            string[] currentLeafNames = FolderLogic.GetAllLeafNamesWithNoExtension(FolderLogic.GetFullTreePath(GlobalConfig.currentPath, parentTreeName));

            for (int i = 0; i < currentLeafNames.Length; i++) // Checks for equal names, regardless of casing.
            {
                if (Validator.IsLowerCaseVersionEquals(leafNameValue.Text, currentLeafNames[i].ToString()))
                {
                    output = "This name already exists, please enter another name.";
                }
            }

            string nameToBeChecked = leafNameValue.Text.ToString();

            foreach (char character in nameToBeChecked) // Checks for any non-alphabetic characters.
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
