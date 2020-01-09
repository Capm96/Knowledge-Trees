<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
>>>>>>> d2b9d017515476da329690706a1471df68883430

namespace Services.Interfaces
{
    /// <summary>
<<<<<<< HEAD
    /// Handles the interaction with Microsoft Word and its documents (creating, deleting, saving, closing, etc).
=======
    /// Handles the interaction with Microsoft word (creating, deleting, saving, closing, etc).
>>>>>>> d2b9d017515476da329690706a1471df68883430
    /// </summary>
    public interface IWordLogicHandler
    {
        /// <summary>
<<<<<<< HEAD
        /// Creates a new word document and saves it at the given path.
        /// </summary>
        void CreateNewLeaf(string path, string newLeafName, string parentTree);

        /// <summary>
        /// Saves and closes all currently opened word documents.
        /// </summary>
        void SaveAndCloseAllLeaves();
=======
        /// Creates a new word document on the current word instance.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Application CreateWordDocumentFromExistingWordInstance(string path);
>>>>>>> d2b9d017515476da329690706a1471df68883430

        /// <summary>
        /// Gets the list of names for all open word documents.
        /// </summary>
<<<<<<< HEAD
        IList<string> GetAllOpenLeafNames();

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
        Dictionary<string, int> GetTotalTreeStatistics(string treeName);
=======
        /// <returns></returns>
        IList<string> GetNamesOfAllOpenWordDocuments();

        /// <summary>
        /// Saves and closes all currently opened word documents.
        /// </summary>
        void SaveAndCloseAllOpenedWordDocuments();
>>>>>>> d2b9d017515476da329690706a1471df68883430
    }
}