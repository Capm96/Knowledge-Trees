using Services.Constants;
using System.Collections.Generic;

namespace Services.Helpers
{
    public static class TreeStatsContainerGetter
    {
        public static Dictionary<string, int> GetStatisticsContainer()
        {
            var output = new Dictionary<string, int>();
            output.Add(StatsNamingConstants.WordCount, 0);
            output.Add(StatsNamingConstants.LeafCount, 0);
            output.Add(StatsNamingConstants.CharacterCount, 0);
            return output;
        }
    }
}
