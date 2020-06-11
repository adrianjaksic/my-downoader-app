using Common;
using Interfaces.Downloading;
using Models.Files;
using NLog;
using System;
using System.Net;

namespace Logic.Downloading
{
    public class FileDownloader
    {
        private const int MaxDownloadPercentage = 100;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IFileDownloaderActions _actions;
        private readonly int _refreshProgresIntervalInMiliseconds;
        private readonly AvailableFile _file;
        private readonly WebClient _webClient;
        private DateTime _lastUpdateTime;

        public FileDownloader(IFileDownloaderActions actions, AvailableFile file, int refreshProgresIntervalInMiliseconds)
        {
            _actions = actions;
            _file = file;
            _refreshProgresIntervalInMiliseconds = refreshProgresIntervalInMiliseconds;
             _webClient = new WebClient();
        }

        public void Start()
        {
            _file.Status = FileStatusEnum.Downloading;
            _lastUpdateTime = DateTime.Now;
            _webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DownloadDataCompleted);
            _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            _webClient.DownloadDataAsync(_file.Uri);
        }

        public void Stop()
        {
            _webClient.CancelAsync();            
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _file.DownloadPercent = e.ProgressPercentage;
            if ((DateTime.Now - _lastUpdateTime).TotalMilliseconds >= _refreshProgresIntervalInMiliseconds)
            {
                _lastUpdateTime = DateTime.Now;
                _actions.DownloadProgressChanged();
            }        
        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {            
            try
            {                
                _file.Status = FileStatusEnum.Downloaded;
                _file.DownloadPercent = MaxDownloadPercentage;
                _actions.DownloadCompleted(_file, e.Result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                _file.Status = e.Cancelled ? FileStatusEnum.DownloadStopped : FileStatusEnum.DownloadError;
                _file.DownloadPercent = 0;
                _actions.DownloadErrorHappened(_file);                
            }
            finally
            {
                _webClient.Dispose();
            }         
        }
    }
}
