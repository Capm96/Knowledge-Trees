using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeTrees
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void returnToDashboardButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VisitLink(string path)
        {
            //Call the Process.Start method to open the default browser   
            //with a URL:  
            System.Diagnostics.Process.Start($"{path}");
        }

        private void IconTrackPath_Click(object sender, EventArgs e)
        {
            VisitLink(IconTrackPath.Text.ToString());
        }

        private void SmartIconsPath_Click(object sender, EventArgs e)
        {
            VisitLink(SmartIconsPath.Text.ToString());
        }

        private void TomasKnopPath_Click(object sender, EventArgs e)
        {
            VisitLink(TomasKnopPath.Text.ToString());
        }

        private void ScubaPath_Click(object sender, EventArgs e)
        {
            VisitLink(ScubaPath.Text.ToString());
        }
    }
}
