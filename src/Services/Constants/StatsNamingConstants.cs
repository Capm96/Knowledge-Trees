namespace Services.Constants
{
    /// <summary>
    /// Keeps track of the naming constants being used to generate the analysis of a given tree 
    /// (i.e. how many words, characters, and leaves it has).
    /// </summary>
    public static class StatsNamingConstants
    {
        public static string WordCount { get; private set; } = "WordCount";
        public static string LeafCount { get; private set; } = "LeafCount";
        public static string CharacterCount { get; private set; } = "CharacterCount";
    }
}
