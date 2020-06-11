using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Common
{
    public class AppSettings : Interfaces.Common.IAppSettings
    {
        public int RefreshProgresIntervalInMiliseconds => Get<int>(nameof(RefreshProgresIntervalInMiliseconds));
        public int MaxDownloadedFiles => Get<int>(nameof(MaxDownloadedFiles));
        public int NumberOfDownloaders => Get<int>(nameof(NumberOfDownloaders));
        public string FileStoragePath => Get<string>(nameof(FileStoragePath));

        private T Get<T>(string key)
        {
            string setting = ConfigurationManager.AppSettings[key];
            if (setting == null)
            {
                throw new KeyNotFoundException(key);
            }
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(setting);
        }
    }
}
