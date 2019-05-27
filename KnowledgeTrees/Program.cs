using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    static class Program
    {
        static Mutex mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool first = false;
            mutex = new Mutex(true, Application.ProductName.ToString(), out first);
            if ((first))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Directory.CreateDirectory(GlobalConfig.currentWorkingPath);
                Application.Run(new knowledgeTreesDashboard());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("The Application Is Already Running", "Knowledge Trees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
