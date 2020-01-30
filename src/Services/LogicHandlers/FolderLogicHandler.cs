using System.Collections.Generic;
using System.Linq;
using System.IO;
using Services.Interfaces;
using Services.Constants;
using System.IO.Abstractions;

namespace Services
{
    public class FolderLogicHandler : IFolderLogicHandler
    {
        #region Fields & Properties

        private readonly IFileSystem _fileSystem;

        #endregion

        #region Constructors

        public FolderLogicHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        #endregion

        #region Methods

        public IList<string> GetAllTreeNames(string baseDirectory)
        {
            bool baseDirectoryExists = _fileSystem.Directory.Exists(baseDirectory);
            if (baseDirectoryExists)
            {
                try
                {
                    return _fileSystem.Directory.GetDirectories(baseDirectory).
                        Select(_fileSystem.Path.GetFileName).ToList();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }
            else
            {
                _fileSystem.Directory.CreateDirectory(baseDirectory);
                return new List<string>();
            }
        }

        public IList<string> GetAllLeafNamesWithNoExtension(string treePath)
        {
            if (_fileSystem.Directory.Exists(treePath))
            {
                try
                {
                    var allLeaves = _fileSystem.Directory.GetFiles(treePath)
                        .Select(_fileSystem.Path.GetFileName).ToArray();

                    // Word documents create meta files when they are running, 
                    // this loop excludes these files from our leaves list.
                    var output = new List<string>();
                    for (int i = 0; i < allLeaves.Length; i++)
                    {
                        if (allLeaves[i].Contains("~"))
                            continue;

                        output.Add(allLeaves[i].Substring(0, allLeaves[i].Length - 5)); // 5 is length of .docx extension.
                    }

                    return output.ToArray();
                }
                catch (IOException ex)
                {
                    throw new IOException(ex.Message);
                }
            }

            return new List<string>();
        }

        public void CreateNewTreeFolder(string fullTreePath)
        {
            if (_fileSystem.Directory.Exists(fullTreePath) == false)
                _fileSystem.Directory.CreateDirectory(fullTreePath);
        }

        public void DeleteTree(string treePath)
        {
            if (_fileSystem.Directory.Exists(treePath))
                _fileSystem.Directory.Delete(treePath, true);
        }

        public void DeleteLeaf(string leafPath)
        {
            if (_fileSystem.File.Exists(leafPath))
                _fileSystem.File.Delete(leafPath);
        }

        public void BackupTrees(string baseDirectory, string destinationDirectory, bool copyingSubDirectories)
        {
            try
            {
                // Check if directory with data exists.
                var sourceDirectory = _fileSystem.DirectoryInfo.FromDirectoryName(baseDirectory);
                if (sourceDirectory.Exists == false)
                    throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {baseDirectory}");

                // If the destination directory doesn't exist, create it.
                if (_fileSystem.Directory.Exists(destinationDirectory) == false)
                    _fileSystem.Directory.CreateDirectory(destinationDirectory);

                // Get the files in the base directory and copy them to the new location.
                var files = sourceDirectory.GetFiles();
                foreach (var file in files)
                {
                    var temporaryPath = _fileSystem.Path.Combine(destinationDirectory, file.Name);
                    file.CopyTo(temporaryPath, false);
                }

                // If copying subdirectories, copy them and their contents to new location.
                var sourceDirectories = sourceDirectory.GetDirectories();
                if (copyingSubDirectories)
                {
                    foreach (var subDirectory in sourceDirectories)
                    {
                        string temporaryPath = _fileSystem.Path.Combine(destinationDirectory, subDirectory.Name);
                        BackupTrees(subDirectory.FullName, temporaryPath, copyingSubDirectories);
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public string GetFullLeafPath(string treeName, string leafName)
        {
            return _fileSystem.Path.GetFullPath($@"{DirectoryConstants.CurrentWorkingPath}\{treeName}\{leafName}.docx");
        }

        public string GetFullTreePath(string treeName)
        {
            return _fileSystem.Path.GetFullPath($@"{DirectoryConstants.CurrentWorkingPath}\{treeName}");
        }

        #endregion
    }
}
