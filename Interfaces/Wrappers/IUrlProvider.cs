using System;
using System.Collections.Generic;

namespace Interfaces.Wrappers
{
    public interface IUrlProvider
    { 
        IEnumerable<Uri> Get();
    }
}
