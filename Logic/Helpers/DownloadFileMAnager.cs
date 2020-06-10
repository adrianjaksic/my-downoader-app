using Interfaces.Helpers;
using Models.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Logic.Helpers
{
    public class DownloadFileManager : IDownloadFileManager
    {
        public void EnsureDirectoryExist(string fileStoragePath)
        {
            Directory.CreateDirectory(fileStoragePath);
        }

        public List<DownloadedFile> LoadAllFilesFromPath(string fileStoragePath)
        {
            List<DownloadedFile> files = new List<DownloadedFile>();
            foreach (string filePath in Directory.EnumerateFiles(fileStoragePath))
            {
                var file = new DownloadedFile()
                {
                    Name = Path.GetFileName(filePath),
                    Path = filePath,
                    Modified = File.GetLastWriteTime(filePath),
                };
                LoadPreviewData(file);
                files.Add(file);
            }
            return files.OrderBy(f => f.Modified).ToList();
        }

        public DownloadedFile CreateFile(string fileName, string folderPath, byte[] data)
        {
            string filePath = GetUniqueFilename(ref fileName, folderPath);
            File.WriteAllBytes(filePath, data);
            var file = new DownloadedFile()
            {
                Name = fileName,
                Modified = DateTime.Now,
                Path = filePath,

            };
            LoadPreviewData(file);
            return file;
        }

        private string GetUniqueFilename(ref string fileName, string folderPath)
        {
            var filePath = $"{folderPath}{fileName}";
            var fileCountNumber = 0;
            while (File.Exists(filePath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{++fileCountNumber}{Path.GetExtension(fileName)}";
                filePath = $"{folderPath}{fileName}";
            }
            return filePath;
        }

        private void LoadPreviewData(DownloadedFile file)
        {
            var extension = Path.GetExtension(file.Path);
            switch (extension)
            {
                case ".txt":
                case ".js":
                case ".css":
                    file.PreviewText = ReadChars(file.Path, 100);
                    break;
                case ".jpg":
                case ".png":
                    using (var bmpTemp = new Bitmap(file.Path))
                    {
                        file.Image = new Bitmap(bmpTemp);
                    }
                    break;
            }
        }

        private string ReadChars(string filename, int count)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    char[] buffer = new char[count];
                    int n = reader.ReadBlock(buffer, 0, count);
                    char[] result = new char[n];
                    Array.Copy(buffer, result, n);
                    return new string(result);
                }
            }
        }
    }
}
