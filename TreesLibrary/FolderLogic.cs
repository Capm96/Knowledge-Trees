using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreesLibrary
{
    public static class FolderLogic
    {
        public static string GetFullTreePath(string baseDirectory, string treeName)
        {
            return $@"{ baseDirectory }\{ treeName }";
        }

        public static string GetFullLeafName(string currentLeafName) // Adds in .docx extension.
        {
            string output = String.Concat(currentLeafName, ".docx");

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

        public static string[] GetAllLeafNamesWithNoExtension(string treePath) // Takes out .docx extension so we can display the names in the dashboard.
        {
            string[] current = Directory.GetFiles(treePath).Select(Path.GetFileName).ToArray();
            List<string> output = new List<string>();

            for (int i = 0; i < current.Length; i++)
            {
                // Word documents create metafiles when they are running -- this method excludes these files from our leaves list.
                if (current[i].Contains("~"))
                    continue;

                output.Add(current[i].Substring(0, current[i].Length - 5));
            }

            return output.ToArray();
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
