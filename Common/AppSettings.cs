using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace Common
{
    public static class AppSettings
    {
        public static int RefreshProgresIntervalInMiliseconds => Get<int>(nameof(RefreshProgresIntervalInMiliseconds));
        public static int MaxDownloadedFiles => Get<int>(nameof(MaxDownloadedFiles));
        public static int NumberOfDownloaders => Get<int>(nameof(NumberOfDownloaders));
        public static string FileStoragePath => Get<string>(nameof(FileStoragePath));

        private static T Get<T>(string key)
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
