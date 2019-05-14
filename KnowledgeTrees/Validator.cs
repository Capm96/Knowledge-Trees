using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTrees
{
    public static class Validator
    {
        public static bool IsLowerCaseVersionEquals(string a, string b)
        {
            return a.ToUpper().Equals(b.ToUpper());
        }

        public static bool IsEnglishLetter(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ';
        }
    }
}
