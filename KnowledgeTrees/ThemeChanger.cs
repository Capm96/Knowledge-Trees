using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TreesLibrary;

namespace KnowledgeTrees
{
    public static class ThemeChanger
    {
        public static void UpdateTheme(this Form callingForm, knowledgeTreesDashboard dashboard, Dictionary<string, string> colors)
        {
            var typeOfForm = callingForm.GetType();

            if (typeOfForm == typeof(knowledgeTreesDashboard))
            {
                if (dashboard.isThemeDark)
                {
                    SetDefaultTheme(callingForm, dashboard, colors);
                }
                else
                {
                    SetDarkTheme(callingForm, dashboard, colors);
                }
            }
            else
            {
                if (dashboard.isThemeDark)
                {
                    SetDarkTheme(callingForm, dashboard, colors);
                }
                else
                {
                    SetDefaultTheme(callingForm, dashboard, colors);
                }
            }

            UpdateCurrentThemeStatus(dashboard);
        }

        private static void SetDarkTheme(Form callingForm, knowledgeTreesDashboard dashboard, Dictionary<string, string> colors)
        {
            ChangeBackground(callingForm, dashboard, colors["DarkBackground"]);
            ChangeButtons(callingForm, dashboard, colors["DarkButtons"]);
            ChangeLabels(callingForm, dashboard, colors["DarkLabels"], colors["DarkLabelsText"]);
            ChangeLists(callingForm, dashboard, colors["DarkLists"]);
            ChangeTexts(callingForm, dashboard, colors["DarkTexts"]);
        }

        private static void SetDefaultTheme(Form callingForm, knowledgeTreesDashboard dashboard, Dictionary<string, string> colors)
        {
            ChangeBackground(callingForm, dashboard, colors["DefaultBackground"]);
            ChangeButtons(callingForm, dashboard, colors["DefaultButtons"]);
            ChangeLabels(callingForm, dashboard, colors["DefaultLabels"], colors["DefaultLabelsText"]);
            ChangeLists(callingForm, dashboard, colors["DefaultLists"]);
            ChangeTexts(callingForm, dashboard, colors["DefaultTexts"]);
        }

        private static void ChangeLists(Form callingForm, knowledgeTreesDashboard dashboard, string colorCode)
        {
            Color listsColor = ColorTranslator.FromHtml($"{colorCode}");

            foreach (var list in callingForm.Controls.OfType<ListBox>())
            {
                list.BackColor = listsColor;
            }
        }

        private static void ChangeTexts(Form callingForm, knowledgeTreesDashboard dashboard, string colorCode)
        {
            Color textsColor = ColorTranslator.FromHtml($"{colorCode}");

            foreach (var text in callingForm.Controls.OfType<TextBox>())
            {
                text.BackColor = textsColor;
            }
        }

        private static void ChangeLabels(Form callingForm, knowledgeTreesDashboard dashboard, string backColor, string textColor)
        {
            var formType = callingForm.GetType();

            Color labelBackColor = ColorTranslator.FromHtml($"{backColor}");
            Color labelTextColor = ColorTranslator.FromHtml($"{textColor}");

            if (formType == typeof(knowledgeTreesDashboard))
            {
                foreach (var label in callingForm.Controls.OfType<Label>())
                {
                    label.BackColor = labelBackColor;

                    if (dashboard.isThemeDark)
                        label.ForeColor = Color.White;
                    else
                        label.ForeColor = Color.Black;
                }
            }
            else
            {
                foreach (var label in callingForm.Controls.OfType<Label>())
                {
                    label.ForeColor = labelTextColor;
                }
            }
        }

        private static void ChangeButtons(Form callingForm, knowledgeTreesDashboard dashboard, string colorCode)
        {
            Color buttonColor = ColorTranslator.FromHtml($"{colorCode}");

            foreach (var button in callingForm.Controls.OfType<Button>())
            {
                button.BackColor = buttonColor;

                if (dashboard.isThemeDark == false)
                {
                    if (button.Name == "creditsButton" || button.Name == "themeButton" || button.Name == "backupButton")
                    {
                        button.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (button.Name == "creditsButton" || button.Name == "themeButton" || button.Name == "backupButton")
                    {
                        button.ForeColor = Color.White;
                    }
                }
            }
        }

        private static void ChangeBackground(this Form callingForm, knowledgeTreesDashboard dashboard, string colorCode)
        {
            Color backgroundColor = ColorTranslator.FromHtml($"{colorCode}");

            callingForm.BackColor = backgroundColor;
        }

        private static void UpdateCurrentThemeStatus(knowledgeTreesDashboard dashboard)
        {
            string pathForThemeStatus = GlobalConfig.currentThemeStatus;

            // If this is first time changing, create a CSV file containing the current status. 
            if (!File.Exists(pathForThemeStatus))
            {
                File.Create(pathForThemeStatus);
            }

            string status = "";

            try
            {
                // Update status according to what is currently set.
                status = (dashboard.isThemeDark) ? "true" : "false";

                // Clear current content.
                File.WriteAllText(pathForThemeStatus, string.Empty);

                // Write new.
                File.WriteAllText(pathForThemeStatus, status);
            }
            catch
            {

            }
        }
    }
}
