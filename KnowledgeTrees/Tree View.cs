using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using TreesLibrary;

namespace KnowledgeTrees
{
    public partial class treeView : Form
    {
        // Initializes background worker for progress bar.
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        static knowledgeTreesDashboard callingDashboard;
        static int leavesCount;
        static int wordCount;
        static int characterCount;
        static bool countingWords = false;
        static string treeName;

        public treeView(knowledgeTreesDashboard dashboard, string NameOfTree)
        {
            // Initialize form.

            InitializeComponent();
            InitializeBackgroundWorker();

            callingDashboard = dashboard;
            treeName = NameOfTree;

            DisplayWelcomeMessage();
            DisplayLeafCountMessage();
            DisplayNiceMessage();
            DisplayTreePicture();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private int GetLeafCount()
        {
            string[] output = FolderLogic.GetAllLeafNames(FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treeName));

            return output.Length;
        }

        private void HandleUIWhileCountingWords()
        {
            if (countingWords == false)
            {
                countingWords = true;

                getWordCountButton.Text = "Counting...";
                getWordCountButton.Enabled = false;

                returnToDashboardButton.Text = "Just a moment while we count the words";
                returnToDashboardButton.Enabled = false;

            }
            else
            {
                countingWords = false;

                getWordCountButton.Text = "Get Word Count";
                getWordCountButton.Enabled = true;

                returnToDashboardButton.Text = "Return To Dashboard";
                returnToDashboardButton.Enabled = true;
            }
        }

        public static int GetFullTreeWordCount(string treeName, BackgroundWorker worker, DoWorkEventArgs e)
        {
            int treeWordCount = 0;
            int treeCharacterCount = 0;

            string treePath = FolderLogic.GetFullTreePath(GlobalConfig.currentWorkingPath, treeName);

            string[] leavesInTree = FolderLogic.GetAllLeafNamesWithNoExtension(treePath);

            foreach (string leaf in leavesInTree)
            {
                string fullLeafPath = WordProcessor.GetFullLeafPath(treeName, leaf);

                // Open a doc file.
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                Document document = application.Documents.Open(fullLeafPath);

                // Prepare to get statistics.
                object includeFootnotesAndEndnotes = true;
                WdStatistic wordStats = WdStatistic.wdStatisticWords;
                WdStatistic charStats = WdStatistic.wdStatisticCharacters;

                // Get word and character count.
                treeWordCount += document.ComputeStatistics(wordStats, ref includeFootnotesAndEndnotes);
                treeCharacterCount += document.ComputeStatistics(charStats, ref includeFootnotesAndEndnotes);

                // Close docs.
                document.Close();
                application.Quit();

                // Report progress for progress bar.
                worker.ReportProgress(100 / leavesCount);
            }

            // Update form's word count.
            wordCount = treeWordCount;
            characterCount = treeCharacterCount;

            return treeWordCount;
        }

        private void DisplayWelcomeMessage()
        {
            welcomeLabel.Text = $"Welcome! This is your {treeName} tree.";
        }

        private void DisplayLeafCountMessage()
        {
            leavesCount = GetLeafCount();

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

        private void DisplayNiceMessage()
        {
            leavesCount = GetLeafCount();

            if (leavesCount <= 5)
            {
                niceMessageLabel.Text = "Your tree is looking a little empty! Create more leaves by writing the awesome stuff you know into your knowledge tree!";
            }

            else if (leavesCount <= 10 && leavesCount > 5)
            {
                niceMessageLabel.Text = "Your tree is looking better! Keep writing. The only way to grow is to learn.";
            }

            else if (leavesCount <= 20 && leavesCount > 10)
            {
                niceMessageLabel.Text = " 'The important thing is to not stop questioning. Curiosity has its own reason for existing. - Albert Einstein' ";
            }

            else if (leavesCount <= 50 && leavesCount > 20)
            {
                niceMessageLabel.Text = $"You are doing great! {treeName} must be second nature to you by now. Good work!";
            }

            else if (leavesCount <= 100 && leavesCount > 50)
            {
                niceMessageLabel.Text = $"Have you really written over fifty leaves in your {treeName} tree? That is incredible! Excellent work. ";
            }

            else if (leavesCount > 100)
            {
                niceMessageLabel.Text = $"{leavesCount} leaves?! We are speechless. Congratulations on your journey! You have built a solid Knowledge Tree.";
            }
        }

        private void DisplayTreePicture()
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream($@"KnowledgeTrees.Tree_Images.{leavesCount}.jpg"); // Path of where our embedded resources (images) are.
            var bmp = new Bitmap(myStream);

            Image treeImage = bmp;
            treePicture.Image = treeImage;
        }

        private void DisplayWordCount(int wordCount)
        {
            wordCountText.Text = $"Done! You have a total of {wordCount} words, and {characterCount} characters in your {treeName} tree.";
        }

        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getWordCountButton_Click(object sender, EventArgs e)
        {
            // Calls parent dashboard and updates how many word docs are open.
            callingDashboard.openedWordDocuments = WordProcessor.CheckOpenedWordDocuments();

            if (callingDashboard.openedWordDocuments.Count > 0)
            {
                MessageBox.Show("Please close out all leaves before counting.", "Close Open Leaves");
                return;
            }

            // UI changes while counting.
            countLeavesProgressBar.Visible = true;
            getWordCountButton.Enabled = false;
            HandleUIWhileCountingWords();

            // Run counting process.
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            e.Result = GetFullTreeWordCount(treeName, backgroundWorker, e);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Once we are done, display the wordcount, and re-set the UI & progress bar.
            DisplayWordCount(wordCount);
            countLeavesProgressBar.Value = 100;

            HandleUIWhileCountingWords();

            countLeavesProgressBar.Visible = false;
            countLeavesProgressBar.Minimum = 0;
            countLeavesProgressBar.Maximum = 100;
            countLeavesProgressBar.Value = 0;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            countLeavesProgressBar.Value += e.ProgressPercentage;
        }
    }
}
