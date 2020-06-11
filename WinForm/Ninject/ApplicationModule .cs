using Interfaces.Helpers;
using Logic.Helpers;
using Ninject.Modules;

namespace WinForm.Ninject
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IUrlProvider)).To(typeof(UrlProvider));
            Bind(typeof(IDownloadFileManager)).To(typeof(DownloadFileManager));
        }
    }
}
