using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeTrees
{
    public static class ThemeChanger
    {
        public static void UpdateTheme(this Form callingForm, knowledgeTreesDashboard dashboard, Dictionary<string, string> colors)
        {
            // Update background color.
            if (dashboard.IsThemeDark)
            {
                ChangeBackground(callingForm, dashboard, colors["DefaultBackground"]);
            }
            else
            {
                ChangeBackground(callingForm, dashboard, colors["DarkBackground"]);
            }
        }


        public static void ChangeBackground(this Form callingForm, knowledgeTreesDashboard dashboard, string colorCode)
        {
            Color backgroundColor = ColorTranslator.FromHtml($"{colorCode}");

            callingForm.BackColor = backgroundColor;
        }
    }
}
