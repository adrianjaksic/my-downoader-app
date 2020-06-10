using AisUriProviderApi;
using Interfaces.Wrappers;
using System;
using System.Collections.Generic;

namespace Logics.UrlProvider
{
    public class UrlProviderService : IUrlProvider
    {
        public IEnumerable<Uri> Get()
        {
            return new AisUriProvider().Get();
        }
    }
}
