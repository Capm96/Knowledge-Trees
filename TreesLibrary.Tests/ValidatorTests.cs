using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using KnowledgeTrees;

namespace TreesLibrary.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData('a', true)]
        [InlineData('z', true)]
        [InlineData('f', true)]
        [InlineData(' ', true)] 
        [InlineData('!', false)]
        [InlineData('-', false)]
        [InlineData('.', false)]
        [InlineData('3', false)]
        public void IsEnglishLetter_ShouldWork(char c, bool expected)
        {
            bool actual = Validator.IsEnglishLetter(c);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("TEST", "TesT", true)]
        [InlineData("test", "TEsT", true)]
        [InlineData("test", "TEsTt", false)]
        public void IsLowerCaseVersionEquals_ShouldWork(string word1, string word2, bool expected)
        {
            bool actual = Validator.IsLowerCaseVersionEquals(word1, word2);

            Assert.Equal(expected, actual);
        }
    }
}
