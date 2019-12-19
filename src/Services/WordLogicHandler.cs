using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Services.Interfaces;

namespace Services
{
    public class WordLogicHandler : IWordLogicHandler
    {
        public IList<string> GetNamesOfAllOpenWordDocuments()
        {
            List<string> documentNames = new List<string>();

            try
            {
                Window objectWindow;
                Application wordInstance;
                wordInstance = (Application)Marshal.GetActiveObject("Word.Application");

                for (int i = 0; i <= wordInstance.Windows.Count; i++)
                {
                    object a = i + 1;
                    objectWindow = wordInstance.Windows.get_Item(ref a);
                    documentNames.Add(objectWindow.Document.FullName);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return documentNames;
        }

        public void SaveAndCloseAllOpenedWordDocuments()
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

        public Application CreateWordDocumentFromExistingWordInstance(string path)
        {
            try
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
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
