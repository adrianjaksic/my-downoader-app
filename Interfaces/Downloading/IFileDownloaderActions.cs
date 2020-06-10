using Models.Files;

namespace Interfaces.Downloading
{
    public interface IFileDownloaderActions
    {
        void DownloadProgressChanged();
        void DownloadErrorHappened(AvailableFile file);
        void DownloadCompleted(AvailableFile file, byte[] data);
    }
}
