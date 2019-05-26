using Xunit;

namespace TreesLibrary.Tests
{
    public class FolderLogicTests
    {
        [Fact]
        public void GetFullTreePath_ShouldWork()
        {
            string pathName = $@"path";
            string treeName = $@"tree";
            string expected = $@"path\tree";

            string actual = FolderLogic.GetFullTreePath(pathName, treeName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetFullLeafName_ShouldWork()
        {
            string leafName = $@"leaf";
            string expected = $@"leaf.docx";

            string actual = FolderLogic.GetFullLeafName(leafName);

            Assert.Equal(expected, actual);
        }
    }
}
