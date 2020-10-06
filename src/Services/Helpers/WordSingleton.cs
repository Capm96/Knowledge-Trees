using System;
using Application = Microsoft.Office.Interop.Word.Application;
using Microsoft.Office.Interop.Word;

namespace Services.LogicHandlers.Helpers
{
    public sealed class WordSingleton
    {
        private static readonly WordSingleton instance = new WordSingleton();
        private static Application _word;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static WordSingleton()
        {
        }

        private WordSingleton()
        {
        }

        public static WordSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        public Application CreateNewWordInstance()
        {
            if (System.Diagnostics.Process.GetProcessesByName("winword").Length == 0)
            {
                _word = new Application();
                _word.Visible = false;
                _word.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                return _word;
            }

            return _word;
        }
    }
}
