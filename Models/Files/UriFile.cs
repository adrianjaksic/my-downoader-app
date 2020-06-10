using System;
using System.Drawing;

namespace Models.Files
{
    public class UriFile
    {
        public Uri Uri { get; set; }
        public int DownloadPercent { get; set; }
        public string PreviewText { get; set; }
        public Image Image { get; set; }
        public DateTime Modified { get; set; }
        public FileStatusEnum Status { get; set; }
    }
}
