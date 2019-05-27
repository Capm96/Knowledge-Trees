using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TreesLibrary
{
    public static class WordProcessor
    {
        public static List<string> CheckOpenedWordDocuments()
        {
            List<string> documents = new List<string>();

            try
            {
                Window objectWindow;
                Application wordObject;
                wordObject = (Application)Marshal.GetActiveObject("Word.Application");
                for (int i = 0; i < wordObject.Windows.Count; i++)
                {
                    object a = i + 1;
                    objectWindow = wordObject.Windows.get_Item(ref a);
                    documents.Add(objectWindow.Document.FullName);
                }
                objectWindow = null;

            }
            catch
            {
                // No documents opened
            }

            return documents;
        }

        public static Application CreateWordDocumentFromExistingInstance(string path)
        {
            Application wordApp = (Application)Marshal.GetActiveObject("Word.Application");
            object inputFile = path;
            object confirmConversions = false;
            object readOnly = false;
            object visible = true;
            object missing = Type.Missing;

            Document doc = wordApp.Documents.Open(
                ref inputFile, ref confirmConversions, ref readOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref visible,
                ref missing, ref missing, ref missing, ref missing);
            return wordApp;
        }

        public static string GetFullLeafPath(string treeName, string leafName)
        {
            string treePath = GlobalConfig.currentWorkingPath + $@"\{treeName}\";
            string leafPath = FolderLogic.GetFullLeafName(leafName);
            string fullPath = treePath + leafPath;

            return fullPath;
        }
    }
}
