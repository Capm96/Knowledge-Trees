using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesLibrary
{
    public static class FolderLogic
    {
        public static string GetFullTreePath(string baseDirectory, string treeName)
        {
            return $@"{ baseDirectory }\{ treeName }";
        }

        public static string GetFullLeafName(string currentLeafName) // Adds in .rtf extension.
        {
            string output = String.Concat(currentLeafName, ".rtf");

            return output;
        }

        public static string[] GetAllTreePaths(string baseDirectory)
        {
            return Directory.GetDirectories(baseDirectory);
        }

        public static string[] GetAllTreeNames(string baseDirectory)
        {
            return Directory.GetDirectories(baseDirectory).Select(Path.GetFileName).ToArray();
        }

        public static string[] GetAllLeafNames(string treePath)
        {
            return Directory.GetFiles(treePath).Select(Path.GetFileName).ToArray();
        }

        public static string[] GetAllLeafNamesWithNoExtension(string treePath) // Takes out .RTF extension so we can display the names in the dashboard.
        {
            string[] output = Directory.GetFiles(treePath).Select(Path.GetFileName).ToArray();

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = output[i].Substring(0, output[i].Length - 4);
            }

            return output;
        }

        public static void CreateNewTreeFolder(string fullTreePath)
        {
            Directory.CreateDirectory(fullTreePath);
        }

        public static void DeleteTree(string treePath)
        {
            Directory.Delete(treePath, true);
        }

        public static void DeleteLeaf(string leafPath)
        {
            File.Delete(leafPath);
        }
    }
}
