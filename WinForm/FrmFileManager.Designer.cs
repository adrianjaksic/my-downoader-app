namespace WinForm
{
    partial class FrmFileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileManager));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewAvailableFiles = new System.Windows.Forms.DataGridView();
            this.uriDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionNameGridViewButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.availableFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewDownloadedFiles = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previewTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.downloadedFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSync = new System.Windows.Forms.Button();
            this.timerSyncInterval = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSyncWithDownloadAll = new System.Windows.Forms.Button();
            this.buttonCancelAllDownloads = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadedFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadedFileBindingSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.9F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.1F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewAvailableFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewDownloadedFiles, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewAvailableFiles
            // 
            this.dataGridViewAvailableFiles.AllowUserToAddRows = false;
            this.dataGridViewAvailableFiles.AllowUserToDeleteRows = false;
            this.dataGridViewAvailableFiles.AllowUserToResizeRows = false;
            this.dataGridViewAvailableFiles.AutoGenerateColumns = false;
            this.dataGridViewAvailableFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uriDataGridViewTextBoxColumn,
            this.downloadPercentDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.actionNameGridViewButtonColumn});
            this.dataGridViewAvailableFiles.DataSource = this.availableFileBindingSource;
            this.dataGridViewAvailableFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAvailableFiles.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAvailableFiles.Name = "dataGridViewAvailableFiles";
            this.dataGridViewAvailableFiles.ReadOnly = true;
            this.dataGridViewAvailableFiles.Size = new System.Drawing.Size(547, 521);
            this.dataGridViewAvailableFiles.TabIndex = 0;
            this.dataGridViewAvailableFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // uriDataGridViewTextBoxColumn
            // 
            this.uriDataGridViewTextBoxColumn.DataPropertyName = "Uri";
            this.uriDataGridViewTextBoxColumn.FillWeight = 220F;
            this.uriDataGridViewTextBoxColumn.HeaderText = "Uri";
            this.uriDataGridViewTextBoxColumn.Name = "uriDataGridViewTextBoxColumn";
            this.uriDataGridViewTextBoxColumn.ReadOnly = true;
            this.uriDataGridViewTextBoxColumn.Width = 220;
            // 
            // downloadPercentDataGridViewTextBoxColumn
            // 
            this.downloadPercentDataGridViewTextBoxColumn.DataPropertyName = "DownloadPercent";
            this.downloadPercentDataGridViewTextBoxColumn.FillWeight = 70F;
            this.downloadPercentDataGridViewTextBoxColumn.HeaderText = "Percent";
            this.downloadPercentDataGridViewTextBoxColumn.Name = "downloadPercentDataGridViewTextBoxColumn";
            this.downloadPercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.downloadPercentDataGridViewTextBoxColumn.Width = 70;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionNameGridViewButtonColumn
            // 
            this.actionNameGridViewButtonColumn.DataPropertyName = "ActionName";
            this.actionNameGridViewButtonColumn.HeaderText = "Action";
            this.actionNameGridViewButtonColumn.Name = "actionNameGridViewButtonColumn";
            this.actionNameGridViewButtonColumn.ReadOnly = true;
            this.actionNameGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.actionNameGridViewButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // availableFileBindingSource
            // 
            this.availableFileBindingSource.DataSource = typeof(Models.Files.AvailableFile);
            // 
            // dataGridViewDownloadedFiles
            // 
            this.dataGridViewDownloadedFiles.AllowUserToAddRows = false;
            this.dataGridViewDownloadedFiles.AllowUserToDeleteRows = false;
            this.dataGridViewDownloadedFiles.AllowUserToResizeRows = false;
            this.dataGridViewDownloadedFiles.AutoGenerateColumns = false;
            this.dataGridViewDownloadedFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDownloadedFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.previewTextDataGridViewTextBoxColumn,
            this.imageDataGridViewImageColumn});
            this.dataGridViewDownloadedFiles.DataSource = this.downloadedFileBindingSource;
            this.dataGridViewDownloadedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDownloadedFiles.Location = new System.Drawing.Point(556, 3);
            this.dataGridViewDownloadedFiles.Name = "dataGridViewDownloadedFiles";
            this.dataGridViewDownloadedFiles.ReadOnly = true;
            this.dataGridViewDownloadedFiles.RowTemplate.Height = 44;
            this.dataGridViewDownloadedFiles.Size = new System.Drawing.Size(449, 521);
            this.dataGridViewDownloadedFiles.TabIndex = 1;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // previewTextDataGridViewTextBoxColumn
            // 
            this.previewTextDataGridViewTextBoxColumn.DataPropertyName = "PreviewText";
            this.previewTextDataGridViewTextBoxColumn.HeaderText = "PreviewText";
            this.previewTextDataGridViewTextBoxColumn.Name = "previewTextDataGridViewTextBoxColumn";
            this.previewTextDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // imageDataGridViewImageColumn
            // 
            this.imageDataGridViewImageColumn.DataPropertyName = "Image";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Image";
            this.imageDataGridViewImageColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.imageDataGridViewImageColumn.HeaderText = "Image";
            this.imageDataGridViewImageColumn.Image = global::WinForm.Properties.Resources.NoImage;
            this.imageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.imageDataGridViewImageColumn.Name = "imageDataGridViewImageColumn";
            this.imageDataGridViewImageColumn.ReadOnly = true;
            // 
            // downloadedFileBindingSource
            // 
            this.downloadedFileBindingSource.DataSource = typeof(Models.Files.DownloadedFile);
            // 
            // buttonSync
            // 
            this.buttonSync.Location = new System.Drawing.Point(3, 3);
            this.buttonSync.Name = "buttonSync";
            this.buttonSync.Size = new System.Drawing.Size(120, 23);
            this.buttonSync.TabIndex = 2;
            this.buttonSync.Text = "Sync";
            this.buttonSync.UseVisualStyleBackColor = true;
            this.buttonSync.Click += new System.EventHandler(this.buttonSync_Click);
            // 
            // timerSyncInterval
            // 
            this.timerSyncInterval.Enabled = true;
            this.timerSyncInterval.Interval = 300000;
            this.timerSyncInterval.Tick += new System.EventHandler(this.timerSyncInterval_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonSync);
            this.flowLayoutPanel1.Controls.Add(this.buttonSyncWithDownloadAll);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancelAllDownloads);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 530);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(547, 28);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // buttonSyncWithDownloadAll
            // 
            this.buttonSyncWithDownloadAll.Location = new System.Drawing.Point(129, 3);
            this.buttonSyncWithDownloadAll.Name = "buttonSyncWithDownloadAll";
            this.buttonSyncWithDownloadAll.Size = new System.Drawing.Size(120, 23);
            this.buttonSyncWithDownloadAll.TabIndex = 3;
            this.buttonSyncWithDownloadAll.Text = "Sync with download";
            this.buttonSyncWithDownloadAll.UseVisualStyleBackColor = true;
            this.buttonSyncWithDownloadAll.Click += new System.EventHandler(this.buttonSyncWithDownloadAll_Click);
            // 
            // buttonCancelAllDownloads
            // 
            this.buttonCancelAllDownloads.Location = new System.Drawing.Point(255, 3);
            this.buttonCancelAllDownloads.Name = "buttonCancelAllDownloads";
            this.buttonCancelAllDownloads.Size = new System.Drawing.Size(120, 23);
            this.buttonCancelAllDownloads.TabIndex = 4;
            this.buttonCancelAllDownloads.Text = "Cancel all downloads";
            this.buttonCancelAllDownloads.UseVisualStyleBackColor = true;
            this.buttonCancelAllDownloads.Click += new System.EventHandler(this.buttonCancelAllDownloads_Click);
            // 
            // FrmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmFileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My File Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileManager_FormClosing);
            this.Load += new System.EventHandler(this.FrmFileManager_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadedFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadedFileBindingSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewAvailableFiles;
        private System.Windows.Forms.BindingSource availableFileBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewDownloadedFiles;
        private System.Windows.Forms.BindingSource downloadedFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previewTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonSync;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.Timer timerSyncInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn uriDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn actionNameGridViewButtonColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonSyncWithDownloadAll;
        private System.Windows.Forms.Button buttonCancelAllDownloads;
    }
}

