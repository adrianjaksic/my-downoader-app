using System;

namespace Models.Files
{
    public class AvailableFile
    {
        public Uri Uri { get; set; }
        public int DownloadPercent { get; set; }
        public DateTime Modified { get; set; }
        public FileStatusEnum Status { get; set; }

        public string ActionName 
        { 
            get
            {
                if (Status == FileStatusEnum.Downloaded)
                {
                    return string.Empty;
                }
                if (Status == FileStatusEnum.Downloading)
                {
                    return "Stop";
                }
                return "Download";
            }
        }
    }
}
