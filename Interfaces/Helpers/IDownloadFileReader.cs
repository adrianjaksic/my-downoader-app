using Models.Files;
using System.Collections.Generic;

namespace Interfaces.Helpers
{
    public interface IDownloadFileManager
    {
        void EnsureDirectoryExist(string fileStoragePath);
        List<DownloadedFile> LoadAllFilesFromPath(string fileStoragePath);
        DownloadedFile CreateFile(string fileName, string folderPath, byte[] data);
        void Delete(string filePath);
    }
}
