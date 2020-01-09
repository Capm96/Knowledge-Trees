using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// Handles all logic involved with Windows' folders manipulation (adding, deleting, getting paths, etc).
    /// </summary>
    public interface IFolderLogicHandler
    {
        /// <summary>
        /// Copies the base directory (and subdirectories, if chosen) to the destination path.
        /// </summary>
        void BackupTrees(string baseDirectory, string destinationDirectory, bool copySubDirectories);

        /// <summary>
        /// Creates a new tree (folder) in the given path.
        /// </summary>
        void CreateNewTreeFolder(string fullTreePath);

        /// <summary>
        /// Deletes the leaf at the given path.
        /// </summary>
        void DeleteLeaf(string leafPath);

        /// <summary>
        /// Deletes the tree at the given path.
        /// </summary>
        void DeleteTree(string treePath);

        /// <summary>
        /// Returns all leaf names in the given tree.
        /// </summary>
        IList<string> GeAllLeafNames(string treePath);

        /// <summary>
        /// Returns all leaf names with no .docx extension to be displayed on the dashboard.
        /// </summary>
        IList<string> GetAllLeafNamesWithNoExtension(string treePath);

        /// <summary>
        /// Returns all three names in the given directory.
        /// </summary>
        IList<string> GetAllTreeNames(string baseDirectory);

        /// <summary>
        /// Returns all three paths in the given directory.
        /// </summary>
        IList<string> GetAllTreePaths(string baseDirectory);

        /// <summary>
        /// Returns the full leaf path for the given leaf at the given tree.
        /// </summary>
        string GetFullLeafPath(string treeName, string leafName);

        /// <summary>
        /// Returns the full tree path for the given tree name.
        /// </summary>
        string GetFullTreePath(string treeName);
    }
}