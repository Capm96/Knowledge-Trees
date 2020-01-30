using NUnit.Framework;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;
using Services.Constants;

namespace Services.Tests.LogicHandlersTests
{
    [TestFixture]
    public class FolderLogicHandlerTests
    {
        #region Constants

        // Paths.
        private string _baseDirectory = DirectoryConstants.CurrentWorkingPath;
        private string _testingTreeName = "Test Tree";
        private string _testingLeafName = "Test Leaf";

        // Handlers.
        private MockFileSystem _mockFileSystem;
        private FolderLogicHandler _folderLogicHandler;

        #endregion 

        #region Constructors

        public FolderLogicHandlerTests()
        {
            // Get handlers.
            _mockFileSystem = new MockFileSystem();
            _folderLogicHandler = new FolderLogicHandler(_mockFileSystem);
        }

        #endregion

        #region Tests

        [Test]
        public void GetAllTreeNames_ReturnTheCorrectNames()
        {
            ResetHandlers();

            // Arrange - Create tree folders.
            var treePathOne = _baseDirectory + @"\treeOne";
            _mockFileSystem.Directory.CreateDirectory(treePathOne);

            var treePathTwo = _baseDirectory + @"\treeTwo";
            _mockFileSystem.Directory.CreateDirectory(treePathTwo);

            var treePathThree = _baseDirectory + @"\treeThree";
            _mockFileSystem.Directory.CreateDirectory(treePathThree);

            // Act - Try to get the names of the trees.
            var folderLogicHandler = new FolderLogicHandler(_mockFileSystem);
            var actual = folderLogicHandler.GetAllTreeNames(_baseDirectory);

            // Assert - Check names.
            Assert.AreEqual(actual[0], "treeOne");
            Assert.AreEqual(actual[1], "treeTwo");
            Assert.AreEqual(actual[2], "treeThree");
        }

        [Test]
        public void GetAllLeafNamesWithoutExtension_ReturnTheCorrectNames()
        {
            ResetHandlers();

            // Arrange - Create files on the directory.
            var mockInputFile = new MockFileData("line1\nline2\nline3");

            _mockFileSystem.AddFile(_baseDirectory + $@"\zero.docx", mockInputFile);
            _mockFileSystem.AddFile(_baseDirectory + $@"\one.docx", mockInputFile);
            _mockFileSystem.AddFile(_baseDirectory + $@"\two.docx", mockInputFile);

            // Act - Try to get the names of the files.
            var actual = _folderLogicHandler.GetAllLeafNamesWithNoExtension(_baseDirectory);

            // Assert - Check names.
            Assert.AreEqual(actual[0], "zero");
            Assert.AreEqual(actual[1], "one");
            Assert.AreEqual(actual[2], "two");
        }

        [Test]
        public void CreateNewTree_WorksAsExpected()
        {
            ResetHandlers();

            // Arrange - Get tree path.
            var treePath = _folderLogicHandler.GetFullTreePath(_testingTreeName);

            // Act - Create tree.
            _folderLogicHandler.CreateNewTreeFolder(treePath);

            // Assert - Check that file exists, and that its name matches.
            Assert.True(_mockFileSystem.Directory.Exists(treePath));

            var basedirectory = _mockFileSystem.DirectoryInfo.FromDirectoryName(_baseDirectory);
            var subdirectories = basedirectory.GetDirectories();
            Assert.AreEqual(subdirectories[0].FullName, treePath);
            Assert.True(subdirectories.Length == 1);
        }

        [Test]
        public void DeleteTree_WorksAsExpected()
        {
            ResetHandlers();

            // Arrange - Get tree path.
            var treePath = _baseDirectory + _testingTreeName;

            // Act - Create tree and delete it.
            _folderLogicHandler.CreateNewTreeFolder(treePath);
            _folderLogicHandler.DeleteTree(treePath);

            // Assert - Check that the tree does not exist.
            Assert.True(_mockFileSystem.Directory.Exists(treePath) == false);
        }

        [Test]
        public void DeleteLeaf_WorksAsExpected()
        {
            ResetHandlers();

            // Arrange - Get tree path.
            var treePath = _baseDirectory + _testingTreeName;

            // Act - Create tree.
            _folderLogicHandler.CreateNewTreeFolder(treePath);

            // Act - Add in leaf (generic file, not actually being created from the internal methods).
            var leafPath = _folderLogicHandler.GetFullLeafPath(_testingTreeName, _testingLeafName);
            var mockInputFile = new MockFileData("line1\nline2\nline3");
            _mockFileSystem.AddFile(leafPath, mockInputFile);

            // Assert - Check that leaf was created as expected.
            Assert.True(_mockFileSystem.File.Exists(leafPath));
            Assert.True(_mockFileSystem.Path.GetFileNameWithoutExtension(leafPath) == $"{_testingLeafName}");

            // Act - Delete leaf.
            _folderLogicHandler.DeleteLeaf(leafPath);

            // Assert - Check that leaf was deleted.
            Assert.True(_mockFileSystem.File.Exists(leafPath) == false);
        }

        [Test]
        public void BackupTrees_SavesFilesAsExpected()
        {
            ResetHandlers();

            // Arrange - Create tree folders.
            var mockInputFile = new MockFileData("line1\nline2\nline3");

            var treePathZero = _baseDirectory + @"\treeZero";
            _mockFileSystem.Directory.CreateDirectory(treePathZero);
            _mockFileSystem.AddFile(treePathZero + "zero.docx", mockInputFile);

            var treePathOne = _baseDirectory + @"\treeOne";
            _mockFileSystem.Directory.CreateDirectory(treePathOne);
            _mockFileSystem.AddFile(treePathOne + "one.docx", mockInputFile);

            var treePathTwo = _baseDirectory + @"\treeTwo";
            _mockFileSystem.Directory.CreateDirectory(treePathTwo);
            _mockFileSystem.AddFile(treePathTwo + "two.docx", mockInputFile);

            // Act - Try to backup.
            var backupDestination = @"C:\temp\destination\";
            _folderLogicHandler.BackupTrees(_baseDirectory, backupDestination, true);

            // Assert - Check files have been transferred.
            var trees = _mockFileSystem.DirectoryInfo.FromDirectoryName(backupDestination).GetDirectories()
                .Select(d => d.Name).ToList();
            Assert.AreEqual(trees[0], "treeZero");
            Assert.AreEqual(trees[1], "treeOne");
            Assert.AreEqual(trees[2], "treeTwo");

            Assert.IsTrue(_mockFileSystem.File.Exists(treePathZero + "zero.docx"));
            Assert.IsTrue(_mockFileSystem.File.Exists(treePathOne + "one.docx"));
            Assert.IsTrue(_mockFileSystem.File.Exists(treePathTwo + "two.docx"));
        }

        [Test]
        public void GetFullTreePath_WorksAsExpected()
        {
            // Arrange - get target path.
            var expected = DirectoryConstants.CurrentWorkingPath + $@"\{_testingTreeName}";

            // Act - get actual path.
            var actual = _folderLogicHandler.GetFullTreePath(_testingTreeName);

            // Assert - Check paths are equal.
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFullLeafPath_WorksAsExpected()
        {
            // Arrange - get target path.
            var expected = DirectoryConstants.CurrentWorkingPath + $@"\{_testingTreeName}\{_testingLeafName}.docx";

            // Act - get actual path.
            var actual = _folderLogicHandler.GetFullLeafPath(_testingTreeName, _testingLeafName);

            // Assert - Check paths are equal.
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Helpers

        private void ResetHandlers()
        {
            _mockFileSystem = new MockFileSystem();
            _folderLogicHandler = new FolderLogicHandler(_mockFileSystem);
        }

        #endregion
    }
}
