using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreesLibrary;
using System.Configuration;

namespace KnowledgeTrees
{
    public partial class createTreeForm : Form
    {
        knowledgeTreesDashboard callingDashboard;

        public createTreeForm(knowledgeTreesDashboard dashboard)
        {
            InitializeComponent();
            callingDashboard = dashboard;
        }

        private void createNewTreeButton_Click(object sender, EventArgs e)
        {
            string treeName = "";
            string errorMessage = TreeNameValidator();

            if (errorMessage.Length == 0)
            {
                treeName = treeNameValue.Text;

                FolderLogic.CreateNewTreeFolder(FolderLogic.GetFullTreePath(GlobalConfig.currentPath, treeName));

                callingDashboard.WireUpTreesList();

                this.Close();
            }
            else
            {
                MessageBox.Show($"{errorMessage}", "Invalid Input:");
                return;
            }
        }

        private string TreeNameValidator()
        {
            string output = "";
            string nameToBeChecked = treeNameValue.Text.ToString();

            if (treeNameValue.Text.Length == 0) // Checks if there is a name without any characters.
            {
                output = "Please enter a valid Tree name.";
            }

            for (int i = 0; i < GlobalConfig.trees.Count; i++) // Checks for equal names, regardless of casing.
            {
                if (Validator.IsLowerCaseVersionEquals(treeNameValue.Text, GlobalConfig.trees.ElementAt(i).Key.ToString()))
                {
                    output = "This name already exists, please enter another name.";
                }
            }

            foreach (char character in nameToBeChecked) // Checks for any non-alphabetic characters.
            {
                if (Validator.IsEnglishLetter(character) == false)
                {
                    output = "Please enter a valid Tree name (only alphabetic characters)";
                }
            }

            return output;
        }
    }
}
