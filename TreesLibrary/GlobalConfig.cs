using System.Collections.Generic;
using System.IO;

namespace TreesLibrary
{
    public static class GlobalConfig
    {
        public static string currentDirectory = Directory.GetCurrentDirectory();

        // Path for base folder, which will hold all trees. 
        public static string currentWorkingPath = currentDirectory + $@"\Trees";

        public static string currentThemeStatus = currentDirectory + $@"\Theme.txt";

        public static Dictionary<string, string> trees = new Dictionary<string, string>();
    }
}
