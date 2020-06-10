using Interfaces.Downloading;
using Interfaces.Views;
using Interfaces.Helpers;
using Logic.Downloading;
using Models.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.Concurrent;
using Common;

namespace Logic.Controllers
{
    public class FileManagerController : IFileDownloaderActions
    {
        private readonly IFileManagerView _downloaderView;
        private readonly IUrlProvider _urlProvider;
        private readonly IDownloadFileManager _downloadFileReader;
        
        private string _fileStoragePath;
        private IEnumerable<AvailableFile> _availableFiles;
        private readonly Queue<DownloadedFile> _downloadedFiles = new Queue<DownloadedFile>();
        private readonly ConcurrentDictionary<AvailableFile, FileDownloader> _downloaders = new ConcurrentDictionary<AvailableFile, FileDownloader>();

        public FileManagerController(IFileManagerView downloaderView, IUrlProvider urlProvider, IDownloadFileManager downloadFileReader)
        {
            _downloaderView = downloaderView;
            _urlProvider = urlProvider;
            _downloadFileReader = downloadFileReader;
        }

        public void SetFileStoragePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            _fileStoragePath = path;
            _downloadFileReader.EnsureDirectoryExist(_fileStoragePath);
            LoadFiles(_fileStoragePath);
            DeleteOldFiles();
        }

        public void LoadAvailableFiles()
        {
            _availableFiles = _urlProvider.Get();
            DeleteOldFiles();
            _downloaderView.SetAvailableFiles(_availableFiles);
            _downloaderView.SetDownloadedFiles(_downloadedFiles);
        }

        public void StartDownload(AvailableFile file)
        {
            StartDownloadIfAvailable(file);
            _downloaderView.RefreshAvailableFiles();
        }

        public void DownloadAll()
        {
            foreach (var file in _availableFiles)
            {
                StartDownloadIfAvailable(file);
            }
            _downloaderView.RefreshAvailableFiles();
        }

        public void StopDownload(AvailableFile file)
        {
            if (_downloaders.ContainsKey(file))
            {
                _downloaders[file].Stop();
            }
            else if (file.Status == FileStatusEnum.ForDownload)
            {
                file.Status = FileStatusEnum.DownloadStopped;
            }
        }

        public void StopAllDownloads()
        {
            foreach (var file in _availableFiles)
            {
                StopDownload(file);
            }
            DeleteOldFiles();
            _downloaderView.SetDownloadedFiles(_downloadedFiles);
        }

        public void DownloadProgressChanged()
        {
            _downloaderView.RefreshAvailableFiles();        
        }

        public void DownloadErrorHappened(AvailableFile file)
        {
            if (_downloaders.ContainsKey(file))
            {
                _downloaders.TryRemove(file, out FileDownloader downloader);
            }
            _downloaderView.RefreshAvailableFiles();
        }

        public void DownloadCompleted(AvailableFile file, byte[] data)
        {
            _downloaders.TryRemove(file, out FileDownloader downloader);

            AddDownloadedFile(file, data);

            while (AppSettings.NumberOfDownloaders > _downloaders.Count && _availableFiles.Any(f => f.Status == FileStatusEnum.ForDownload))
            {
                var nextFile = _availableFiles.OrderBy(f => f.Modified).FirstOrDefault(f => f.Status == FileStatusEnum.ForDownload);
                StartDownloadIfAvailable(nextFile);
            }

            if (_downloaders.Count == 0)
            {
                DeleteOldFiles();
            }

            _downloaderView.RefreshAvailableFiles();
            _downloaderView.SetDownloadedFiles(_downloadedFiles);
        }

        public bool IsDownloadInProgres()
        {
            return _downloaders.Count > 0;
        }

        private void LoadFiles(string path)
        {
            foreach (var item in _downloadFileReader.LoadAllFilesFromPath(path))
            {
                _downloadedFiles.Enqueue(item);
            }
            _downloaderView.SetDownloadedFiles(_downloadedFiles);
        }

        private void StartDownloadIfAvailable(AvailableFile file)
        {
            file.Modified = DateTime.Now;
            file.Status = FileStatusEnum.ForDownload;
            if (AppSettings.NumberOfDownloaders > _downloaders.Count)
            {
                if (!_downloaders.ContainsKey(file))
                {
                    var fd = new FileDownloader(this, file);
                    _downloaders.TryAdd(file, fd);
                    fd.Start();
                }
            }
        }

        private void AddDownloadedFile(AvailableFile file, byte[] data)
        {
            var downloadedFile = _downloadFileReader.CreateFile(file.Uri.Segments.Last(), _fileStoragePath, data);
            lock (_downloadedFiles)
            {                
                _downloadedFiles.Enqueue(downloadedFile);
            }
        }

        private void DeleteOldFiles()
        {
            List<string> filesForDelete = new List<string>();
            lock (_downloadedFiles)
            {
                while (_downloadedFiles.Count > AppSettings.MaxDownloadedFiles)
                {
                    var fileForDelete = _downloadedFiles.Dequeue();
                    filesForDelete.Add(fileForDelete.Path);
                }
            }
            foreach (var filePath in filesForDelete)
            {
                File.Delete(filePath);
            }
        }
    }
}
