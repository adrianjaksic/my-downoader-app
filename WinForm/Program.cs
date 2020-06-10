using Interfaces.Views;
using System;
using System.Threading;
using System.Windows.Forms;

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
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _mainView = new FrmFileManager();
            Application.Run(_mainView as Form);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            _mainView.ShowExceptionMessage(e.Exception);
        }
    }
}
