using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Services
{

    public class FolderLogicHandler : IFolderLogicHandler
    {
        //public string GetFullTreePath(string baseDirectory, string treeName)
        //{
        //    return $@"{ baseDirectory }\{ treeName }";
        //}

        //public string GetFullLeafNameWithExtension(string currentLeafName) // Adds in .docx extension.
        //{
        //    return string.Concat(currentLeafName, ".docx");
        //}

        public IList<string> GetAllTreePaths(string baseDirectory)
        {
            return Directory.GetDirectories(baseDirectory).ToList();
        }

        public IList<string> GetAllTreeNames(string baseDirectory)
        {
            return Directory.GetDirectories(baseDirectory).Select(Path.GetFileName).ToList();
        }

        public IList<string> GeAllLeafNames(string treePath)
        {
            // Includes meta word files.
            List<string> allNames = Directory.GetFiles(treePath).Select(Path.GetFileName).ToList();

            // Will only include actual files.
            List<string> cleanNames = new List<string>();

            // Excludes meta files (which include "~" in their name. These files exist while the actual file is being modified).
            foreach (string name in allNames)
            {
                if (name.Contains("~") == false)
                {
                    cleanNames.Add(name);
                }
            }

            return cleanNames.ToArray();
        }

        public IList<string> GetAllLeafNamesWithNoExtension(string treePath)
        {
            string[] current = Directory.GetFiles(treePath).Select(Path.GetFileName).ToArray();

            List<string> output = new List<string>();
            for (int i = 0; i < current.Length; i++)
            {
                // Word documents create meta files when they are running, this method excludes these files from our leaves list.
                if (current[i].Contains("~"))
                    continue;

                output.Add(current[i].Substring(0, current[i].Length - 5)); // 5 is length of .docx extension.
            }

            return output.ToArray();
        }

        public void CreateNewTreeFolder(string fullTreePath)
        {
            Directory.CreateDirectory(fullTreePath);
        }

        public void DeleteTree(string treePath)
        {
            Directory.Delete(treePath, true);
        }

        public void DeleteLeaf(string leafPath)
        {
            File.Delete(leafPath);
        }

        public void BackupTrees(string baseDirectory, string destinationDirectory, bool copySubDirectories)
        {
            // Check if directory with data exists.
            DirectoryInfo sourceDirectory = new DirectoryInfo(baseDirectory);
            if (sourceDirectory.Exists == false)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {baseDirectory}");
            }

            // If the destination directory doesn't exist, create it.
            if (Directory.Exists(destinationDirectory) == false)
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Get the files in the base directory and copy them to the new location.
            FileInfo[] files = sourceDirectory.GetFiles();
            foreach (FileInfo file in files)
            {
                string temporaryPath = Path.Combine(destinationDirectory, file.Name);
                file.CopyTo(temporaryPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            DirectoryInfo[] sourceDirectories = sourceDirectory.GetDirectories();
            if (copySubDirectories)
            {
                foreach (DirectoryInfo subDirectory in sourceDirectories)
                {
                    string temporaryPath = Path.Combine(destinationDirectory, subDirectory.Name);
                    BackupTrees(subDirectory.FullName, temporaryPath, copySubDirectories);
                }
            }
        }
    }
}
