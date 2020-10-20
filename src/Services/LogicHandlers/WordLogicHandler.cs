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
using Services.Constants;
using System.IO.Abstractions;
using Services.LogicHandlers.Helpers;
using Services.Helpers;

namespace Services
{
    public class WordLogicHandler : IWordLogicHandler
    {
        #region Fields & Properties

        private Application _wordInstance;
        private readonly IFileSystem _fileSystem;

        #endregion

        #region Constructors

        public WordLogicHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        #endregion

        #region

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public void CreateNewLeaf(string path, string leafName, string treeName)
        {
            // Create word instance.
            var wordInstance = CreateNewWordInstance();

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
        }

        public Application CreateNewWordInstance()
        {
            //var wordInstance = new Application();
            //wordInstance.Visible = false;
            //wordInstance.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            //return wordInstance;
            return WordSingleton.Instance.CreateNewWordInstance();
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
                    var wordInstance = (Application)Marshal.GetActiveObject("Word.Application");

                    foreach (Document doc in wordInstance.Documents)
                    {
                        doc.Save();
                        doc.Close();
                    }

                    Dispatcher.DisposeOfWordInstance(wordInstance);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public IList<string> GetAllOpenLeavesPaths()
        {
            var documentNames = new List<string>();

            try
            {
                if (_wordInstance == null)
                {
                    _wordInstance = (Application)Marshal.GetActiveObject("Word.Application") ?? null;
                }

                // If there are any open windows (documents), get their names.
                if (_wordInstance.Windows.Count > 0)
                {
                    Window wordWindow;

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
                //throw new COMException(ex.Message);
                _wordInstance = CreateNewWordInstance();
                return new List<string>();
            }

            return documentNames;
        }


        private Window GetSpecificWordWindow(string targetName)
        {
            Window window = null;

            try
            {
                if (_wordInstance == null)
                {
                    _wordInstance = (Application)Marshal.GetActiveObject("Word.Application") ?? null;
                }

                // If there are any open windows (documents), get their names.
                if (_wordInstance.Windows.Count > 0)
                {
                    Window wordWindow;

                    for (int i = 0; i < _wordInstance.Windows.Count; i++)
                    {
                        object a = i + 1;
                        wordWindow = _wordInstance.Windows.get_Item(ref a);

                        if(wordWindow.Document.FullName == targetName)
                        {
                            window = wordWindow;
                            break;
                        }
                    }
                }
            }
            catch (COMException ex)
            {
                //throw new COMException(ex.Message);
                _wordInstance = CreateNewWordInstance();
            }
            return window;
        }

        public void OpenExistingLeaf(string path)
        {
            var openedWordDocuments = GetAllOpenLeavesPaths();

            // Checks if current file is already open.
            foreach (string name in openedWordDocuments)
            {
                if (name.Equals(path))
                {
                    MessageBox.Show($"This leaf is already open, check your open word documents.", "Leaf Already Opened");
                    return;
                }
            }

            try
            {
                if (_wordInstance == null)
                {
                    _wordInstance = (Application)Marshal.GetActiveObject("Word.Application");
                }

                _wordInstance.Visible = true;
                Document wordDocument = _wordInstance.Documents.Open(path);

                Window wordWindow = GetSpecificWordWindow(wordDocument.FullName);
                IntPtr hwnd = new IntPtr(wordWindow.Hwnd);
                SetForegroundWindow(hwnd);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckIfLeafIsOpen(string currentPath)
        {
            var openPaths = GetAllOpenLeavesPaths();

            // Checks if current file is already open.
            foreach (string documentPath in openPaths)
                if (documentPath.Equals(currentPath))
                    return true;

            return false;
        }

        public Dictionary<string,int> GetTotalTreeStatistics(string treeName)
        {
            // Gets names of all the leaves we will look through.
            var folderLogic = new FolderLogicHandler(new FileSystem());
            var treePath = folderLogic.GetFullTreePath(treeName);
            var leavesInTree = folderLogic.GetAllLeafNamesWithNoExtension(treePath);

            // Open an instance of word to open the documents in.
            var wordInstance = WordSingleton.Instance.CreateNewWordInstance();

            var statistics = TreeStatsContainerGetter.GetStatisticsContainer();
            foreach (string leaf in leavesInTree)
            {
                // Open current leaf.
                string fullLeafPath = folderLogic.GetFullLeafPath(treeName, leaf);
                Document document = wordInstance.Documents.Open(fullLeafPath);

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
            return statistics;
        }

        #endregion
    }
}
