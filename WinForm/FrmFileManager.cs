using Common;
using Interfaces.Helpers;
using Interfaces.Views;
using Logic.Controllers;
using Logic.Helpers;
using Models.Files;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmFileManager : Form, IFileManagerView, IMainView
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly FileManagerController _controller;

        public FrmFileManager(IUrlProvider urlProvider, IDownloadFileManager downloadFileReader)
        {
            _controller = new FileManagerController(this, urlProvider, downloadFileReader);
            InitializeComponent();            
        }

        #region IFileManagerView

        public void SetAvailableFiles(IEnumerable<AvailableFile> availableFiles)
        {
            if (InvokeRequired)
            {
                var action = new Action<IEnumerable<AvailableFile>>(SetAvailableFiles);
                Invoke(action, new object[] { availableFiles });
            }
            else
            {
                availableFileBindingSource.DataSource = availableFiles;
            }
        }

        public void RefreshAvailableFiles()
        {
            if (InvokeRequired)
            {
                var action = new Action(RefreshAvailableFiles);
                Invoke(action);
            }
            else
            {
                dataGridViewAvailableFiles.Refresh();
            }           
        }

        public void SetDownloadedFiles(IEnumerable<DownloadedFile> downloadedFiles)
        {
            if (InvokeRequired)
            {
                var action = new Action<IEnumerable<DownloadedFile>>(SetDownloadedFiles);
                Invoke(action, new object[] { downloadedFiles });
            }
            else
            {
                downloadedFileBindingSource.DataSource = null;
                downloadedFileBindingSource.DataSource = downloadedFiles;
            }            
        }

        #endregion

        #region IMainView

        public void ShowExceptionMessage(Exception exc)
        {
            _logger.Error(exc);
            MessageBox.Show(this, exc.Message, "Error happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region Events

        private void FrmFileManager_Load(object sender, EventArgs e)
        {
            _controller.SetFileStoragePath(AppSettings.FileStoragePath);
            _controller.LoadAvailableFiles();
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            _controller.LoadAvailableFiles();
        }

        private void buttonSyncWithDownloadAll_Click(object sender, EventArgs e)
        {
            _controller.LoadAvailableFiles();
            _controller.DownloadAll();
        }

        private void buttonCancelAllDownloads_Click(object sender, EventArgs e)
        {
            _controller.StopAllDownloads();
        }

        private void timerSyncInterval_Tick(object sender, EventArgs e)
        {
            _controller.LoadAvailableFiles();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == actionNameGridViewButtonColumn.Index)
            {
                var file = availableFileBindingSource[e.RowIndex] as AvailableFile;
                if (file.Status == FileStatusEnum.Downloading)
                {
                    _controller.StopDownload(file);
                }
                else if (file.Status != FileStatusEnum.Downloaded)
                {
                    _controller.StartDownload(file);
                }
            }
        }

        private void FrmFileManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controller.IsDownloadInProgres())
            {
                if (MessageBox.Show(this, "Files are still downloading. Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }    
        }

        #endregion
    }
}
