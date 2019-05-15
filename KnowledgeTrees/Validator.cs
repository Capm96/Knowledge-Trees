using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTrees
{
    public static class Validator
    {
        public static bool IsLowerCaseVersionEquals(string a, string b) // We want our names to be case-insensitive. "Test" and "TeST" should be equal.
        {
            return a.ToUpper().Equals(b.ToUpper());
        }

        public static bool IsEnglishLetter(char c) // We accept spaces as true values because trees/leave names might be larger than one word.
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ';
        }
    }
}
