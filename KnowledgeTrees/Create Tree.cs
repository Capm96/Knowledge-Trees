using System;
using System.Linq;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    public partial class createTreeForm : Form
    {
        knowledgeTreesDashboard callingDashboard;

        public createTreeForm(knowledgeTreesDashboard dashboard)
        {
            InitializeComponent();

            // We need to keep track of the caller dashboard so that we can update the list.
            callingDashboard = dashboard;
        }

        private void createNewTreeButton_Click(object sender, EventArgs e)
        {
            string treeName = "";
            string errorMessage = TreeNameValidator();

            if (errorMessage.Length == 0)
            {
                treeName = treeNameValue.Text;

                FolderLogic.CreateNewTreeFolder(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treeName));

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

            // Checks if there is a name without any characters.
            if (treeNameValue.Text.Length == 0) 
            {
                output = "Please enter a valid Tree name.";
            }

            for (int i = 0; i < GlobalConfig.trees.Count; i++) 
            {
                // Checks for equal names, regardless of casing.
                if (Validator.IsLowerCaseVersionEquals(treeNameValue.Text, GlobalConfig.trees.ElementAt(i).Key.ToString())) 
                {
                    output = "This name already exists, please enter another name.";
                }
            }

            // Checks for any non-alphabetic characters.
            foreach (char character in nameToBeChecked) 
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
