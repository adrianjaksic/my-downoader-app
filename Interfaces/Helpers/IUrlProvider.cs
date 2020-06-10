using Models.Files;
using System.Collections.Generic;

namespace Interfaces.Helpers
{
    public interface IUrlProvider
    { 
        IEnumerable<AvailableFile> Get();
    }
}
