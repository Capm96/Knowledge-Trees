using NUnit.Framework;
using System.Linq;
using System.IO.Abstractions.TestingHelpers;
using Services.Constants;

namespace Services.Tests.LogicHandlersTests
{
    [TestFixture]
    public class FolderLogicHandlerTests
    {
        string testDirectory = @"C:\temp\trees\";

        [Test]
        public void GetAllTreeNames_ReturnTheCorrectNames()
        {
            // Arrange - Create tree folders.
            var mockFileSystem = new MockFileSystem();

            var treePathOne = testDirectory + @"\treeOne";
            mockFileSystem.Directory.CreateDirectory(treePathOne);

            var treePathTwo = testDirectory + @"\treeTwo";
            mockFileSystem.Directory.CreateDirectory(treePathTwo);

            var treePathThree = testDirectory + @"\treeThree";
            mockFileSystem.Directory.CreateDirectory(treePathThree);

            // Act - Try to get the names of the trees.
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            var actual = folderLogicHandler.GetAllTreeNames(testDirectory);

            // Assert - Check names.
            Assert.AreEqual(actual[0], "treeOne");
            Assert.AreEqual(actual[1], "treeTwo");
            Assert.AreEqual(actual[2], "treeThree");
        }

        [Test]
        public void GetAllLeafNamesWithoutExtension_ReturnTheCorrectNames()
        {
            // Arrange - Create files on the directory.
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("line1\nline2\nline3");

            mockFileSystem.AddFile(testDirectory + "zero.docx", mockInputFile);
            mockFileSystem.AddFile(testDirectory + "one.docx", mockInputFile);
            mockFileSystem.AddFile(testDirectory + "two.docx", mockInputFile);

            // Act - Try to get the names of the files.
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            var actual = folderLogicHandler.GetAllLeafNamesWithNoExtension(testDirectory);

            // Assert - Check names.
            Assert.AreEqual(actual[0], "zero");
            Assert.AreEqual(actual[1], "one");
            Assert.AreEqual(actual[2], "two");
        }

        [Test]
        public void CreateNewTree_WorksAsExpected()
        {
            // Arrange - Get tree path.
            var treePath = testDirectory + @"newTree";

            // Act - Create tree.
            var mockFileSystem = new MockFileSystem();
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            folderLogicHandler.CreateNewTreeFolder(treePath);

            // Assert - Check that file exists, and that its name matches.
            Assert.True(mockFileSystem.Directory.Exists(treePath));

            var basedirectory = mockFileSystem.DirectoryInfo.FromDirectoryName(testDirectory);
            var subdirectories = basedirectory.GetDirectories();
            Assert.AreEqual(subdirectories[0].FullName, treePath);
            Assert.True(subdirectories.Length == 1);
        }

        [Test]
        public void DeleteTree_WorksAsExpected()
        {
            // Arrange - Get tree path.
            var treePath = testDirectory + @"treeThatWillBeDeleted";

            // Act - Create tree and delete it.
            var mockFileSystem = new MockFileSystem();
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            folderLogicHandler.CreateNewTreeFolder(treePath);
            folderLogicHandler.DeleteTree(treePath);

            // Assert - Check that the tree does not exist.
            Assert.True(mockFileSystem.Directory.Exists(treePath) == false);
        }

        [Test]
        public void DeleteLeaf_WorksAsExpected()
        {
            // Arrange - Get tree path.
            var treePath = testDirectory + @"testTree";

            // Act - Create tree.
            var mockFileSystem = new MockFileSystem();
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            folderLogicHandler.CreateNewTreeFolder(treePath);

            // Act - Add in leaf (generic file, not actually being created from the internal methods).
            var leafPath = treePath + @"\newLeaf.docx";
            var mockInputFile = new MockFileData("line1\nline2\nline3");
            mockFileSystem.AddFile(leafPath, mockInputFile);

            // Assert - Check that leaf was created as expected.
            Assert.True(mockFileSystem.File.Exists(leafPath));
            Assert.True(mockFileSystem.Path.GetFileName(leafPath) == "newLeaf.docx");

            // Act - Delete leaf.
            folderLogicHandler.DeleteLeaf(leafPath);

            // Assert - Check that leaf was deleted.
            Assert.True(mockFileSystem.File.Exists(leafPath) == false);
        }

        [Test]
        public void BackupTrees_SavesFilesAsExpected()
        {
            // Arrange - Create tree folders.
            var mockFileSystem = new MockFileSystem();
            var mockInputFile = new MockFileData("line1\nline2\nline3");

            var treePathZero = testDirectory + @"\treeZero";
            mockFileSystem.Directory.CreateDirectory(treePathZero);
            mockFileSystem.AddFile(treePathZero + "zero.docx", mockInputFile);

            var treePathOne = testDirectory + @"\treeOne";
            mockFileSystem.Directory.CreateDirectory(treePathOne);
            mockFileSystem.AddFile(treePathOne + "one.docx", mockInputFile);

            var treePathTwo = testDirectory + @"\treeTwo";
            mockFileSystem.Directory.CreateDirectory(treePathTwo);
            mockFileSystem.AddFile(treePathTwo + "two.docx", mockInputFile);

            // Act - Try to backup.
            var backupDestination = @"C:\temp\destination\";
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            folderLogicHandler.BackupTrees(testDirectory, backupDestination, true);

            // Assert - Check files have been transferred.
            var trees = mockFileSystem.DirectoryInfo.FromDirectoryName(backupDestination).GetDirectories()
                .Select(d => d.Name).ToList();
            Assert.AreEqual(trees[0], "treeZero");
            Assert.AreEqual(trees[1], "treeOne");
            Assert.AreEqual(trees[2], "treeTwo");

            Assert.IsTrue(mockFileSystem.File.Exists(treePathZero + "zero.docx"));
            Assert.IsTrue(mockFileSystem.File.Exists(treePathOne + "one.docx"));
            Assert.IsTrue(mockFileSystem.File.Exists(treePathTwo + "two.docx"));
        }

        [Test]
        public void GetFullTreePath_WorksAsExpected()
        {
            // Arrange - get target path.
            string treeName = "NewTree";
            var expected = DirectoryConstants.CurrentWorkingPath + $@"\{treeName}";

            // Act - get actual path.
            var mockFileSystem = new MockFileSystem();
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            var actual = folderLogicHandler.GetFullTreePath(treeName);

            // Assert - Check paths are equal.
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFullLeafPath_WorksAsExpected()
        {
            // Arrange - get target path.
            string treeName = "NewTree";
            string leafName = "NewLeaf";
            var expected = DirectoryConstants.CurrentWorkingPath + $@"\{treeName}\{leafName}.docx";

            // Act - get actual path.
            var mockFileSystem = new MockFileSystem();
            var folderLogicHandler = new FolderLogicHandler(mockFileSystem);
            var actual = folderLogicHandler.GetFullLeafPath(treeName, leafName);

            // Assert - Check paths are equal.
            Assert.AreEqual(expected, actual);
        }
    }
}
