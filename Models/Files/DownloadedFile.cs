using System;
using System.Drawing;

namespace Models.Files
{
    public class DownloadedFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string PreviewText { get; set; }
        public Image Image { get; set; }
        public DateTime Modified { get; set; }
    }
}
