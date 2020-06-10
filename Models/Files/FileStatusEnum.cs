namespace Models.Files
{
    public enum FileStatusEnum
    {
        Available = 0,
        Downloading = 1,
        ForDownload = 2,
        Downloaded = 3,
        DownloadError = 4,
        DownloadStopped = 5,
    }
}
