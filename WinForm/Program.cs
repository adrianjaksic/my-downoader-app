using Interfaces.Views;
using System;
using System.Threading;
using System.Windows.Forms;
using WinForm.Ninject;

namespace WinForm
{
    static class Program
    {
        private static IMainView _mainView;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CompositionRoot.Wire(new ApplicationModule());
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _mainView = CompositionRoot.Resolve<FrmFileManager>();
            Application.Run(_mainView as Form);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            _mainView.ShowExceptionMessage(e.Exception);
        }
    }
}
