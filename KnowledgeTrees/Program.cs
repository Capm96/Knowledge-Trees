using System;
using System.Diagnostics;
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

            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Knowledge Trees is already running. Only one instance of this application is allowed at a time.", "Application Already Running");
                return;
            }

            Application.Run(new knowledgeTreesDashboard());
        }
    }
}
