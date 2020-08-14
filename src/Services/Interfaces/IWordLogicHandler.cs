using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// Handles the interaction with Microsoft Word and its documents (creating, deleting, saving, closing, etc).
    /// Handles the interaction with Microsoft word (creating, deleting, saving, closing, etc).
    /// </summary>
    public interface IWordLogicHandler
    {
        /// <summary>
        /// Creates a new word document and saves it at the given path.
        /// </summary>
        void CreateNewLeaf(string path, string newLeafName, string parentTree);

        /// <summary>
        /// Saves and closes all currently opened word documents.
        /// </summary>
        void SaveAndCloseAllLeaves();

        /// <summary>
        /// Gets the list of names for all open word documents.
        /// </summary>
        IList<string> GetAllOpenLeavesPaths();

        /// <summary>
        /// Opens an existing leaf for modification.
        /// </summary>
        void OpenExistingLeaf(string path);

        /// <summary>
        /// Checks if given leaf is open.
        /// </summary>
        bool CheckIfLeafIsOpen(string path);

        /// <summary>
        /// Gets all the statistics from the tree.
        /// </summary>
        Dictionary<string,int> GetTotalTreeStatistics(string treeName);
    }
}