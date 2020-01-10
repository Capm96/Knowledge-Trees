using System.IO;

namespace Services.Constants
{
    /// <summary>
    /// Keeps track of the directory where the Trees folder (the base folder that contains all other trees) 
    /// will be stored in.
    /// </summary>
    public static class DirectoryConstants
    {
        private static string currentBaseDirectory = Directory.GetCurrentDirectory();

        public static string CurrentWorkingPath = currentBaseDirectory + $@"\Trees";
    }
}
