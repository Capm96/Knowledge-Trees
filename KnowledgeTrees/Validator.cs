namespace KnowledgeTrees
{
    public static class Validator
    {
        /// <summary>
        /// The application requires that names be case-insensitive for document creation purposes.
        /// This method ensures that two names like "Test" and "TEST" are equal for the app's purposes.
        /// </summary>
        /// <param name="a">Name 1</param>
        /// <param name="b">Name 2</param>
        /// <returns>True or false (are they the same?)</returns>
        public static bool IsLowerCaseVersionEquals(string a, string b)
        {
            return a.ToUpper().Equals(b.ToUpper());
        }

        /// <summary>
        /// Checks if the given character is an alphabetic character or white space.
        /// </summary>
        /// <param name="c">Character to check.</param>
        /// <returns>True or false.</returns>
        public static bool IsEnglishLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ';
        }
    }
}
