using System;
using System.IO;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Directory.CreateDirectory(GlobalConfig.currentWorkingPath);

            Application.Run(new knowledgeTreesDashboard());
        }
    }
}
