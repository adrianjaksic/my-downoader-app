using AisUriProviderApi;
using Interfaces.Helpers;
using Models.Files;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Helpers
{
    public class UrlProvider : IUrlProvider
    {
        public IEnumerable<AvailableFile> Get()
        {
            return new AisUriProvider().Get().Select(f => new AvailableFile()
             {
                 Uri = f,
                 Modified = DateTime.Now,
                 DownloadPercent = 0,
                 Status = FileStatusEnum.Available,
             }).ToList();
        }
    }
}
