using Interfaces.Helpers;
using Logic.Helpers;
using Ninject.Modules;
using Common;
using Interfaces.Common;

namespace WinForm.Ninject
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppSettings)).To(typeof(AppSettings));
            Bind(typeof(IUrlProvider)).To(typeof(UrlProvider));
            Bind(typeof(IDownloadFileManager)).To(typeof(DownloadFileManager));
        }
    }
}
