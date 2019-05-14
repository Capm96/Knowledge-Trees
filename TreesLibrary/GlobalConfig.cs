using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TreesLibrary
{
    public static class GlobalConfig
    {
        public static string currentDirectory = Directory.GetCurrentDirectory();

        public static string imagesFolderPath = currentDirectory + $@"\Images";

        public static string currentPath = currentDirectory + $@"\Trees";

        public static Dictionary<string, string> trees = new Dictionary<string, string>();
    }
}
