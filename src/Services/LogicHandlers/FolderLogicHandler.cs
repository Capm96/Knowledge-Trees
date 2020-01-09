using System.Collections.Generic;
using System.Linq;
using System.IO;
using Services.Interfaces;
<<<<<<< HEAD
using Services.Constants;
=======
>>>>>>> d2b9d017515476da329690706a1471df68883430

namespace Services
{
    public class FolderLogicHandler : IFolderLogicHandler
    {
        public IList<string> GetAllTreePaths(string baseDirectory)
        {
<<<<<<< HEAD
            if (Directory.Exists(baseDirectory))
            {
                try
                {
                    return Directory.GetDirectories(baseDirectory).ToList();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }
            else
            {
                Directory.CreateDirectory(baseDirectory);
                return new List<string>();
            }
=======
            return Directory.GetDirectories(baseDirectory).ToList();
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public IList<string> GetAllTreeNames(string baseDirectory)
        {
<<<<<<< HEAD
            bool baseDirectoryExists = Directory.Exists(baseDirectory);
            if (baseDirectoryExists)
            {
                try
                {
                    return Directory.GetDirectories(baseDirectory).Select(Path.GetFileName).ToList();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }
            else
            {
                Directory.CreateDirectory(baseDirectory);
                return new List<string>();
            }
=======
            return Directory.GetDirectories(baseDirectory).Select(Path.GetFileName).ToList();
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public IList<string> GeAllLeafNames(string treePath)
        {
<<<<<<< HEAD
            if (Directory.Exists(treePath))
            {
                try
                {
                    // Includes meta word files.
                    var allNames = Directory.GetFiles(treePath).Select(Path.GetFileName).ToList();

                    // Will only include actual files.
                    var cleanNames = new List<string>();

                    // Excludes meta files (which include "~" in their name. These files exist while the actual file is being modified).
                    foreach (string name in allNames)
                    {
                        if (name.Contains("~") == false)
                            cleanNames.Add(name);
                    }

                    return cleanNames.ToArray();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }

            return new List<string>();
=======
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
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public IList<string> GetAllLeafNamesWithNoExtension(string treePath)
        {
<<<<<<< HEAD
            if (Directory.Exists(treePath))
            {
                try
                {
                    var current = Directory.GetFiles(treePath).Select(Path.GetFileName).ToArray();

                    var output = new List<string>();
                    for (int i = 0; i < current.Length; i++)
                    {
                        // Word documents create meta files when they are running, this method excludes these files from our leaves list.
                        if (current[i].Contains("~"))
                            continue;

                        output.Add(current[i].Substring(0, current[i].Length - 5)); // 5 is length of .docx extension.
                    }

                    return output.ToArray();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }

            return new List<string>();
=======
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
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public void CreateNewTreeFolder(string fullTreePath)
        {
<<<<<<< HEAD
            if (Directory.Exists(fullTreePath) == false)
                Directory.CreateDirectory(fullTreePath);
=======
            Directory.CreateDirectory(fullTreePath);
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public void DeleteTree(string treePath)
        {
<<<<<<< HEAD
            if (Directory.Exists(treePath))
                Directory.Delete(treePath, true);
=======
            Directory.Delete(treePath, true);
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public void DeleteLeaf(string leafPath)
        {
<<<<<<< HEAD
            if (File.Exists(leafPath))
                File.Delete(leafPath);
=======
            File.Delete(leafPath);
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }

        public void BackupTrees(string baseDirectory, string destinationDirectory, bool copySubDirectories)
        {
<<<<<<< HEAD
            try
            {
                // Check if directory with data exists.
                var sourceDirectory = new DirectoryInfo(baseDirectory);
                if (sourceDirectory.Exists == false)
                    throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {baseDirectory}");

                // If the destination directory doesn't exist, create it.
                if (Directory.Exists(destinationDirectory) == false)
                    Directory.CreateDirectory(destinationDirectory);

                // Get the files in the base directory and copy them to the new location.
                var files = sourceDirectory.GetFiles();
                foreach (FileInfo file in files)
                {
                    var temporaryPath = Path.Combine(destinationDirectory, file.Name);
                    file.CopyTo(temporaryPath, false);
                }

                // If copying subdirectories, copy them and their contents to new location.
                DirectoryInfo[] sourceDirectories = sourceDirectory.GetDirectories();
                if (copySubDirectories)
                    foreach (DirectoryInfo subDirectory in sourceDirectories)
                    {
                        string temporaryPath = Path.Combine(destinationDirectory, subDirectory.Name);
                        BackupTrees(subDirectory.FullName, temporaryPath, copySubDirectories);
                    }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
=======
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
>>>>>>> d2b9d017515476da329690706a1471df68883430
            }
        }

        public string GetFullLeafPath(string treeName, string leafName)
        {
<<<<<<< HEAD
            return Path.GetFullPath($@"{DirectoryConstants.CurrentWorkingPath}\{treeName}\{leafName}.docx");
        }

        public string GetFullTreePath(string treeName)
        {
            return Path.GetFullPath($@"{DirectoryConstants.CurrentWorkingPath}\{treeName}");
=======
            string treePath = Directory.GetCurrentDirectory() + $@"\{treeName}\";
            string leafPath = string.Concat(leafName, ".docx");

            return treePath + leafPath;
>>>>>>> d2b9d017515476da329690706a1471df68883430
        }
    }
}
