using Microsoft.Office.Interop.Word;
using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// Handles the interaction with Microsoft word (creating, deleting, saving, closing, etc).
    /// </summary>
    public interface IWordLogicHandler
    {
        /// <summary>
        /// Creates a new word document on the current word instance.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Application CreateWordDocumentFromExistingWordInstance(string path);

        /// <summary>
        /// Gets the list of names for all open word documents.
        /// </summary>
        /// <returns></returns>
        IList<string> GetNamesOfAllOpenWordDocuments();

        /// <summary>
        /// Saves and closes all currently opened word documents.
        /// </summary>
        void SaveAndCloseAllOpenedWordDocuments();
    }
}