using Models.Files;
using System.Collections.Generic;

namespace Interfaces.Views
{
    public interface IFileManagerView
    {
        void SetAvailableFiles(IEnumerable<UriFile> files);
    }
}
