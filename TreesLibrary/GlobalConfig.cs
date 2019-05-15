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

        public static string currentWorkingPath = currentDirectory + $@"\Trees"; // Creates a path for our base folder, which will hold all of our Trees. 

        public static Dictionary<string, string> trees = new Dictionary<string, string>();
    }
}
