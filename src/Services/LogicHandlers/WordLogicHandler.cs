using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Services.Interfaces;
using System.Windows;
using Application = Microsoft.Office.Interop.Word.Application;
using Window = Microsoft.Office.Interop.Word.Window;
using System.IO;
using Services.Constants;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using Services.Entities;

namespace Services
{
    public class WordLogicHandler : IWordLogicHandler
    {
        private Application _wordInstance;

        public void CreateNewLeaf(string path, string leafName, string treeName)
        {
            // Create word instance.
            Application wordInstance = CreateWordInstance();

            try
            {
                // Add document.
                object missing = Type.Missing;
                Document leaf = wordInstance.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                // Insert placeholder text in newly created document.
                InsertGenericTextOnLeaf(leafName, treeName, leaf);

                // Save and close leaf.
                leaf.SaveAs2(path);
                leaf.Close();
            }
            catch (COMException e)
            {
                throw new COMException(e.ToString());
            }
            finally
            {
                // Dispose word instance.
                wordInstance.Quit();
                GC.Collect();
            }
        }

        private Application CreateWordInstance()
        {
            var wordInstance = new Application();
            wordInstance.Visible = false;
            wordInstance.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            return wordInstance;
        }

        private void InsertGenericTextOnLeaf(string leafName, string treeName, Document leaf)
        {
            leaf.Range(0,0).Text = $"Welcome to your {leafName} Leaf in the {treeName} Tree! Delete this message and write anything you'd like. " +
            $"Do not forget to always hit the Save button when you are done writing. " +
            $"One last thing: try to always use the 'Save' button instead of 'Save As'. Just to make sure your leaf is in its proper tree.";
        }

        public void SaveAndCloseAllLeaves()
        {
            try
            {
                if (Process.GetProcessesByName("winword").Count() > 0)
                {
                    Application wordInstance = (Application)Marshal.GetActiveObject("Word.Application");

                    foreach (Document doc in wordInstance.Documents)
                    {
                        doc.Save();
                        doc.Close();
                    }

                    wordInstance.Quit();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public IList<string> GetAllOpenLeafNames()
        {
            List<string> documentNames = new List<string>();
            Window wordWindow;

            try
            {
                if (_wordInstance == null)
                {
                    _wordInstance = (Application)Marshal.GetActiveObject("Word.Application") ?? null;
                }

                // If there are any open windows (documents), get their names.
                if (_wordInstance.Windows.Count > 0)
                {
                    for (int i = 0; i < _wordInstance.Windows.Count; i++)
                    {
                        object a = i + 1;
                        wordWindow = _wordInstance.Windows.get_Item(ref a);
                        documentNames.Add(wordWindow.Document.FullName);
                    }
                }
            }
            catch (COMException ex)
            {
                _wordInstance = CreateWordInstance();
                return new List<string>();
                //throw new COMException(ex.Message);
            }

            return documentNames;
        }

        public void OpenExistingLeaf(string path)
        {
            IList<string> openedWordDocuments = GetAllOpenLeafNames();

            // Checks if current file is already open.
            foreach (string name in openedWordDocuments)
            {
                if (name.Equals(path))
                {
                    MessageBox.Show($"This leaf is already open, check your open word documents.", "Leaf Already Opened");
                    return;
                }
            }

            if (_wordInstance == null)
            {
                _wordInstance = (Application)Marshal.GetActiveObject("Word.Application");
            }

            try
            {
                _wordInstance.Visible = true;
                Document wordDocument = _wordInstance.Documents.Open(path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckIfLeafIsOpen(string currentPath)
        {
            IList<string> openedWordDocumentsPaths = GetAllOpenLeafNames();

            // Checks if current file is already open.
            foreach (string documentPath in openedWordDocumentsPaths)
                if (documentPath.Equals(currentPath))
                    return true;

            return false;
        }

        public Dictionary<string,int> GetTotalTreeStatistics(string treeName)
        {
            // Gets names of all the leaves we will look through.
            var folderLogic = new FolderLogicHandler();
            var treePath = folderLogic.GetFullTreePath(treeName);
            var leavesInTree = folderLogic.GetAllLeafNamesWithNoExtension(treePath);

            // Open an instance of word to open the documents in.
            var application = new Application();

            var statistics = GetStatisticsContainer();
            foreach (string leaf in leavesInTree)
            {
                // Open current leaf.
                string fullLeafPath = folderLogic.GetFullLeafPath(treeName, leaf);
                Document document = application.Documents.Open(fullLeafPath);

                // Prepare to get statistics.
                object includeFootnotesAndEndnotes = true;
                WdStatistic wordStats = WdStatistic.wdStatisticWords;
                WdStatistic charStats = WdStatistic.wdStatisticCharacters;

                // Update statistics.
                statistics[StatsNamingConstants.WordCount] += document.ComputeStatistics(wordStats, ref includeFootnotesAndEndnotes);
                statistics[StatsNamingConstants.CharacterCount] += document.ComputeStatistics(charStats, ref includeFootnotesAndEndnotes);
                statistics[StatsNamingConstants.LeafCount]++;

                document.Close();
            }

            application.Quit();
            GC.Collect();

            return statistics;
        }

        private Dictionary<string, int> GetStatisticsContainer()
        {
            var output = new Dictionary<string, int>();
            output.Add(StatsNamingConstants.WordCount, 0);
            output.Add(StatsNamingConstants.LeafCount, 0);
            output.Add(StatsNamingConstants.CharacterCount, 0);
            return output;
        }
    }
}
