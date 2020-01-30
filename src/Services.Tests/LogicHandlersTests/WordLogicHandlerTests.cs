using NUnit.Framework;
using Services.Constants;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using Services.LogicHandlers;
using Services.LogicHandlers.Helpers;

namespace Services.Tests.LogicHandlersTests
{
    [TestFixture]
    class WordLogicHandlerTests
    {
        // Paths.
        private string _baseDirectory = DirectoryConstants.CurrentWorkingPath;
        private string _testingTreeName = "Test Tree";
        private string _testingLeafName = "Test Leaf";
        private string _fullTreePath = "";
        private string _fullLeafPath = "";

        // Handlers.
        private MockFileSystem _mockFileSystem;
        private FolderLogicHandler _folderLogicHandler;
        private WordLogicHandler _wordLogicHandler;

        public WordLogicHandlerTests()
        {
            // Get handlers.
            _mockFileSystem = new MockFileSystem();
            _folderLogicHandler = new FolderLogicHandler(_mockFileSystem);
            _wordLogicHandler = new WordLogicHandler(_mockFileSystem);
        }

        [Test]
        public void CreateNewLeaf_WorksAsExpected()
        {
            // Act - Create leaf.
            CreateTestLeaf();

            // Assert - Check that leaf exists, that it is in the correct format, and that it has the correct name.
            Assert.True(File.Exists(_fullLeafPath));
            Assert.True(Path.GetExtension(_fullLeafPath) == ".docx");
            Assert.True(Path.GetFileNameWithoutExtension(_fullLeafPath) == _testingLeafName);

            // Delete directory which was created.
            Directory.Delete(_baseDirectory, true);
        }

        [Test]
        public void CreateWordInstance_WorksAsExpected()
        {
            // Act - Get word instance.
            var wordInstance = _wordLogicHandler.CreateNewWordInstance();

            // Assert - Check that the instance was created.
            Assert.True(wordInstance != null);

            // Dispose of wordInstance;
            Dispatcher.DisposeOfWordInstance(wordInstance);
        }

        [Test]
        public void GetTreeStatistics_WorksAsExpected()
        {
            // Arrange - Create a test leaf.
            CreateTestLeaf();

            // Act - Get statistics
            var statistics = _wordLogicHandler.GetTotalTreeStatistics(_testingTreeName);

            // Assert - Check that there is at least one leaf in this tree and that it has words and characters in its.
            Assert.True(statistics[StatsNamingConstants.LeafCount] == 1);
            Assert.True(statistics[StatsNamingConstants.WordCount] > 10);
            Assert.True(statistics[StatsNamingConstants.CharacterCount] > 50);
        }

        #region Helpers

        public void CreateTestLeaf()
        {
            // Get test tree directory.
            _fullTreePath = _folderLogicHandler.GetFullTreePath(_testingTreeName);
            Directory.CreateDirectory(_fullTreePath);

            // Create tree.
            _fullLeafPath = _folderLogicHandler.GetFullLeafPath(_testingTreeName, _testingLeafName);
            _wordLogicHandler.CreateNewLeaf(_fullLeafPath, _testingLeafName, _testingTreeName);
        }

        #endregion
    }
}
