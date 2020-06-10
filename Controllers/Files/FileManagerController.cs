using Controllers.Downloader;
using Interfaces.Views;
using Interfaces.Wrappers;
using Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Controllers.Files
{
    public class FileManagerController
    {
        private readonly IFileManagerView _downloaderView;
        private readonly IUrlProvider _urlProvider;
        private readonly string _fileStoragePath;
        private int _numberOfDownloaders;

        private readonly List<UriFile> _files = new List<UriFile>();
        private readonly Queue<UriFile> _downloadedFiles = new Queue<UriFile>();

        private readonly Dictionary<WebClient, UriFile> _downloaders = new Dictionary<WebClient, UriFile>();

        public FileManagerController(IFileManagerView downloaderView, IUrlProvider urlProvider, string fileStoragePath)
        {
            _downloaderView = downloaderView;
            _urlProvider = urlProvider;
            _fileStoragePath = fileStoragePath;
        }

        public void Initialization()
        {
            //TODO load files from _fileStoragePath  
            //_files and _downloadedFiles
            _downloaderView.SetAvailableFiles(_files);
        }

        public void LoadNew()
        {
            var uris = _urlProvider.Get();
            _downloaderView.SetAvailableFiles(_files);
        }

        public void StartDownloadIfAvailable()
        {
            var file = _files.FirstOrDefault(f => f.Status == FileStatusEnum.ForDownload);
            if (file != null && _numberOfDownloaders > _downloaders.Count)
            {
                WebClient client = new WebClient();
                client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DownloadDataCompleted);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                client.DownloadDataAsync(file.Uri);
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //TODO fine file set progres
        }

        private void DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            //TODO fine file set status to completed
            //update view progress
            //dispose webclient
            StartDownloadIfAvailable();
        }

        public void StopDownload(UriFile file)
        {

        }

        public void SetNumberOfDownloaders(int number)
        {
            _numberOfDownloaders = number;
        }
    }
}
