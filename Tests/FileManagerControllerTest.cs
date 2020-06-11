using Common;
using Interfaces.Helpers;
using Interfaces.Views;
using Logic.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Files;
using Moq;
using System.Collections.Generic;
using Interfaces.Common;

namespace Tests
{
    [TestClass]
    public class FileManagerControllerTest
    {
        private const string TestPath = "Test//";
        private const int MaxDownloadedFiles = 10;

        [TestMethod]
        public void TestDeletionOfExceedingElements()
        {
            Mock<IAppSettings> appSettings = new Mock<IAppSettings>();
            Mock<IFileManagerView> view = new Mock<IFileManagerView>();
            Mock<IUrlProvider> urlProvider = new Mock<IUrlProvider>();
            Mock<IDownloadFileManager> fileManager = new Mock<IDownloadFileManager>();
            appSettings.Setup(a => a.MaxDownloadedFiles).Returns(MaxDownloadedFiles);
            var maxDownloadedFilesPlusOne = MaxDownloadedFiles + 1;
            var files = GetDownloadedFiles(maxDownloadedFilesPlusOne);
            fileManager.Setup(fm => fm.LoadAllFilesFromPath(TestPath)).Returns(files);
            var controller = new FileManagerController(view.Object, urlProvider.Object, fileManager.Object, appSettings.Object);

            controller.SetFileStoragePath(TestPath);

            fileManager.Verify(fm => fm.Delete(files[0].Path), Times.Once());
        }

        private List<DownloadedFile> GetDownloadedFiles(int number)
        {
            var list = new List<DownloadedFile>();
            for (int i = 0; i < number; i++)
            {
                list.Add(new DownloadedFile()
                {
                    Name = i.ToString(),
                    Path = i.ToString(),
                });
            }
            return list;
        }
    }
}
