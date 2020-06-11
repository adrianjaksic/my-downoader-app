namespace Interfaces.Common
{
    public interface IAppSettings
    {
        int RefreshProgresIntervalInMiliseconds { get; }
        int MaxDownloadedFiles { get; }
        int NumberOfDownloaders { get; }
        string FileStoragePath { get; }
    }
}
