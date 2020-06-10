using Models.Files;
using System.Collections.Generic;

namespace Interfaces.Views
{
    public interface IFileManagerView
    {
        void SetAvailableFiles(IEnumerable<AvailableFile> availableFiles);
        void RefreshAvailableFiles();
        void SetDownloadedFiles(IEnumerable<DownloadedFile> downloadedFiles);
    }
}
