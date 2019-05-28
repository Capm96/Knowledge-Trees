using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    public partial class treeView : Form
    {
        knowledgeTreesDashboard callingDashboard;
        int leavesCount;
        string treeName;

        public treeView(knowledgeTreesDashboard dashboard, string NameOfTree)
        {
            InitializeComponent();

            callingDashboard = dashboard;
            treeName = NameOfTree;

            leavesCount = GetLeafCount();
            niceMessageLabel.Text = DisplayNiceMessage();

            DisplayWelcomeMessage();
            DisplayLeafCountMessage();
            DisplayTreePicture();
        }

        private int GetLeafCount()
        {
            string[] output = FolderLogic.GetAllLeafNames(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treeName));

            return output.Length;
        }

        private void DisplayLeafCountMessage()
        {
            if (leavesCount == 1)
            {
                // Returns singular "Leaf" in our text because we only have one.
                leafCountText.Text = $"So far, your tree has {leavesCount} leaf in it."; 
            }
            else
            {
                // Else it returns "Leaves" in our text since they are plural (more than one or zero).
                leafCountText.Text = $"So far, your tree has {leavesCount} leaves in it."; 
            }
        }

        private void DisplayWordCount()
        {
            string wordCount = WordProcessor.GetFullTreeWordCount(treeName).ToString();

            wordCountText.Text = $"You have a total {wordCount} words in your {treeName} tree.";
        }

        private void DisplayWelcomeMessage()
        {
            welcomeLabel.Text = $"Welcome! This is your {treeName} tree.";
        }

        private void DisplayTreePicture()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream($@"KnowledgeTrees.Tree_Images.{leavesCount}.jpg"); // Path of where our embedded resources (images) are.
            var bmp = new Bitmap(myStream);

            Image treeImage = bmp;
            treePicture.Image = treeImage;
        }

        private string DisplayNiceMessage()
        {
            string output = "";

            if (leavesCount <= 5)
            {
                output = "Your tree is looking a little empty! Create more leaves by writing the awesome stuff you know into your knowledge tree!";
            }

            else if (leavesCount <= 10 && leavesCount > 5)
            {
                output = "Your tree is looking better! Keep writing. The only way to grow is to learn.";
            }

            else if (leavesCount <= 20 && leavesCount > 10)
            {
                output = " 'The important thing is to not stop questioning. Curiosity has its own reason for existing. - Albert Einstein' ";
            }

            else if (leavesCount <= 50 && leavesCount > 20)
            {
                output = $"You are doing great! {treeName} must be second nature to you by now. Good work!";
            }

            else if (leavesCount <= 100 && leavesCount > 50)
            {
                output = $"Have you really written over fifty leaves in your {treeName} tree? That is incredible! Excellent work. ";
            }

            else if (leavesCount > 100)
            {
                output = $"{leavesCount} leaves?! We are speechless. Congratulations on your journey! You have built a solid Knowledge Tree.";
            }

            return output;
        }

        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getWordCountButton_Click(object sender, EventArgs e)
        {
            DisplayWordCount();
        }
    }
}
