using System.IO;

namespace Services.Constants
{
    /// <summary>
    /// Keeps track of the directory which the Trees folder (the base folder that contains all trees) will be stored in.
    /// </summary>
    public static class DirectoryConstants
    {
        private static string currentBaseDirectory = Directory.GetCurrentDirectory();
        public static string CurrentWorkingPath = currentBaseDirectory + $@"\Trees";
    }
}
