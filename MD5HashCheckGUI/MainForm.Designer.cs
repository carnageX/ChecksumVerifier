namespace MD5HashCheckGUI
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TF_labelFileSize = new System.Windows.Forms.Label();
            this.TF_progressBar = new System.Windows.Forms.ProgressBar();
            this.TF_labelResult = new System.Windows.Forms.Label();
            this.TF_buttonCompare = new System.Windows.Forms.Button();
            this.TF_textFileHash = new System.Windows.Forms.TextBox();
            this.TF_contextMenu_checksum = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TF_labelFileHash = new System.Windows.Forms.Label();
            this.TF_textFilePath = new System.Windows.Forms.TextBox();
            this.TF_buttonBrowse = new System.Windows.Forms.Button();
            this.TF_fileLabel = new System.Windows.Forms.Label();
            this.TF_textUserHash = new System.Windows.Forms.TextBox();
            this.TF_hashLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MF_progressBar = new System.Windows.Forms.ProgressBar();
            this.MF_resultList = new System.Windows.Forms.ListBox();
            this.MF_contextMenu_results = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MF_textUserHash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MF_buttonBrowse = new System.Windows.Forms.Button();
            this.MF_buttonCompare = new System.Windows.Forms.Button();
            this.MF_fileList = new System.Windows.Forms.ListBox();
            this.TF_openFile = new System.Windows.Forms.OpenFileDialog();
            this.MF_openFile = new System.Windows.Forms.OpenFileDialog();
            this.listChecksums = new System.Windows.Forms.ComboBox();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MF_buttonExport = new System.Windows.Forms.Button();
            this.MF_exportFile = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TF_contextMenu_checksum.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.MF_contextMenu_results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(583, 233);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.TF_labelFileSize);
            this.tabPage1.Controls.Add(this.TF_progressBar);
            this.tabPage1.Controls.Add(this.TF_labelResult);
            this.tabPage1.Controls.Add(this.TF_buttonCompare);
            this.tabPage1.Controls.Add(this.TF_textFileHash);
            this.tabPage1.Controls.Add(this.TF_labelFileHash);
            this.tabPage1.Controls.Add(this.TF_textFilePath);
            this.tabPage1.Controls.Add(this.TF_buttonBrowse);
            this.tabPage1.Controls.Add(this.TF_fileLabel);
            this.tabPage1.Controls.Add(this.TF_textUserHash);
            this.tabPage1.Controls.Add(this.TF_hashLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text and File";
            // 
            // TF_labelFileSize
            // 
            this.TF_labelFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_labelFileSize.Location = new System.Drawing.Point(100, 70);
            this.TF_labelFileSize.Name = "TF_labelFileSize";
            this.TF_labelFileSize.Size = new System.Drawing.Size(195, 23);
            this.TF_labelFileSize.TabIndex = 10;
            this.TF_labelFileSize.Text = "fileSize";
            // 
            // TF_progressBar
            // 
            this.TF_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_progressBar.Location = new System.Drawing.Point(469, 193);
            this.TF_progressBar.Name = "TF_progressBar";
            this.TF_progressBar.Size = new System.Drawing.Size(88, 10);
            this.TF_progressBar.TabIndex = 9;
            // 
            // TF_labelResult
            // 
            this.TF_labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_labelResult.Location = new System.Drawing.Point(100, 125);
            this.TF_labelResult.Name = "TF_labelResult";
            this.TF_labelResult.Size = new System.Drawing.Size(457, 25);
            this.TF_labelResult.TabIndex = 8;
            this.TF_labelResult.Text = "result";
            this.TF_labelResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TF_buttonCompare
            // 
            this.TF_buttonCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_buttonCompare.Location = new System.Drawing.Point(301, 70);
            this.TF_buttonCompare.Name = "TF_buttonCompare";
            this.TF_buttonCompare.Size = new System.Drawing.Size(75, 29);
            this.TF_buttonCompare.TabIndex = 7;
            this.TF_buttonCompare.Text = "Compare";
            this.TF_buttonCompare.UseVisualStyleBackColor = true;
            this.TF_buttonCompare.Click += new System.EventHandler(this.TF_buttonCompareClick);
            // 
            // TF_textFileHash
            // 
            this.TF_textFileHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_textFileHash.BackColor = System.Drawing.SystemColors.Control;
            this.TF_textFileHash.ContextMenuStrip = this.TF_contextMenu_checksum;
            this.TF_textFileHash.Location = new System.Drawing.Point(100, 105);
            this.TF_textFileHash.Name = "TF_textFileHash";
            this.TF_textFileHash.Size = new System.Drawing.Size(457, 20);
            this.TF_textFileHash.TabIndex = 6;
            this.TF_textFileHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TF_contextMenu_checksum
            // 
            this.TF_contextMenu_checksum.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1});
            this.TF_contextMenu_checksum.Name = "TF_contextMenu_checksum";
            this.TF_contextMenu_checksum.ShowImageMargin = false;
            this.TF_contextMenu_checksum.Size = new System.Drawing.Size(78, 26);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(77, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItem1Click);
            // 
            // TF_labelFileHash
            // 
            this.TF_labelFileHash.Location = new System.Drawing.Point(6, 108);
            this.TF_labelFileHash.Name = "TF_labelFileHash";
            this.TF_labelFileHash.Size = new System.Drawing.Size(122, 20);
            this.TF_labelFileHash.TabIndex = 5;
            this.TF_labelFileHash.Text = "File Checksum: ";
            // 
            // TF_textFilePath
            // 
            this.TF_textFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_textFilePath.Location = new System.Drawing.Point(100, 44);
            this.TF_textFilePath.Name = "TF_textFilePath";
            this.TF_textFilePath.Size = new System.Drawing.Size(376, 20);
            this.TF_textFilePath.TabIndex = 4;
            // 
            // TF_buttonBrowse
            // 
            this.TF_buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_buttonBrowse.Location = new System.Drawing.Point(482, 42);
            this.TF_buttonBrowse.Name = "TF_buttonBrowse";
            this.TF_buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.TF_buttonBrowse.TabIndex = 3;
            this.TF_buttonBrowse.Text = "Browse...";
            this.TF_buttonBrowse.UseVisualStyleBackColor = true;
            this.TF_buttonBrowse.Click += new System.EventHandler(this.TF_buttonBrowseClick);
            // 
            // TF_fileLabel
            // 
            this.TF_fileLabel.Location = new System.Drawing.Point(6, 46);
            this.TF_fileLabel.Name = "TF_fileLabel";
            this.TF_fileLabel.Size = new System.Drawing.Size(88, 18);
            this.TF_fileLabel.TabIndex = 2;
            this.TF_fileLabel.Text = "File to Compare: ";
            // 
            // TF_textUserHash
            // 
            this.TF_textUserHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TF_textUserHash.Location = new System.Drawing.Point(100, 18);
            this.TF_textUserHash.Name = "TF_textUserHash";
            this.TF_textUserHash.Size = new System.Drawing.Size(457, 20);
            this.TF_textUserHash.TabIndex = 1;
            this.TF_textUserHash.TextChanged += new System.EventHandler(this.TF_textUserHash_TextChanged);
            // 
            // TF_hashLabel
            // 
            this.TF_hashLabel.Location = new System.Drawing.Point(6, 21);
            this.TF_hashLabel.Name = "TF_hashLabel";
            this.TF_hashLabel.Size = new System.Drawing.Size(68, 17);
            this.TF_hashLabel.TabIndex = 0;
            this.TF_hashLabel.Text = "Checksum:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.MF_textUserHash);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multiple Files";
            // 
            // MF_progressBar
            // 
            this.MF_progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MF_progressBar.Location = new System.Drawing.Point(3, 156);
            this.MF_progressBar.Name = "MF_progressBar";
            this.MF_progressBar.Size = new System.Drawing.Size(75, 10);
            this.MF_progressBar.TabIndex = 7;
            // 
            // MF_resultList
            // 
            this.MF_resultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MF_resultList.BackColor = System.Drawing.SystemColors.Control;
            this.MF_resultList.ContextMenuStrip = this.MF_contextMenu_results;
            this.MF_resultList.FormattingEnabled = true;
            this.MF_resultList.HorizontalScrollbar = true;
            this.MF_resultList.Location = new System.Drawing.Point(84, 5);
            this.MF_resultList.Name = "MF_resultList";
            this.MF_resultList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.MF_resultList.Size = new System.Drawing.Size(286, 160);
            this.MF_resultList.TabIndex = 6;
            // 
            // MF_contextMenu_results
            // 
            this.MF_contextMenu_results.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyAllToolStripMenuItem});
            this.MF_contextMenu_results.Name = "MF_contextMenu_results";
            this.MF_contextMenu_results.ShowImageMargin = false;
            this.MF_contextMenu_results.Size = new System.Drawing.Size(125, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.copyToolStripMenuItem.Text = "Copy Selected";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.copyAllToolStripMenuItem.Text = "Copy All";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.CopyAllToolStripMenuItemClick);
            // 
            // MF_textUserHash
            // 
            this.MF_textUserHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MF_textUserHash.Location = new System.Drawing.Point(78, 6);
            this.MF_textUserHash.Name = "MF_textUserHash";
            this.MF_textUserHash.Size = new System.Drawing.Size(493, 20);
            this.MF_textUserHash.TabIndex = 5;
            this.MF_textUserHash.TextChanged += new System.EventHandler(this.MF_textUserHash_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Checksum:";
            // 
            // MF_buttonBrowse
            // 
            this.MF_buttonBrowse.Location = new System.Drawing.Point(3, 5);
            this.MF_buttonBrowse.Name = "MF_buttonBrowse";
            this.MF_buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.MF_buttonBrowse.TabIndex = 3;
            this.MF_buttonBrowse.Text = "Browse...";
            this.MF_buttonBrowse.UseVisualStyleBackColor = true;
            this.MF_buttonBrowse.Click += new System.EventHandler(this.MF_buttonBrowseClick);
            // 
            // MF_buttonCompare
            // 
            this.MF_buttonCompare.Location = new System.Drawing.Point(3, 34);
            this.MF_buttonCompare.Name = "MF_buttonCompare";
            this.MF_buttonCompare.Size = new System.Drawing.Size(75, 23);
            this.MF_buttonCompare.TabIndex = 2;
            this.MF_buttonCompare.Text = "Compare";
            this.MF_buttonCompare.UseVisualStyleBackColor = true;
            this.MF_buttonCompare.Click += new System.EventHandler(this.MF_buttonCompareClick);
            // 
            // MF_fileList
            // 
            this.MF_fileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MF_fileList.FormattingEnabled = true;
            this.MF_fileList.HorizontalScrollbar = true;
            this.MF_fileList.Location = new System.Drawing.Point(3, 5);
            this.MF_fileList.Name = "MF_fileList";
            this.MF_fileList.Size = new System.Drawing.Size(182, 160);
            this.MF_fileList.TabIndex = 0;
            // 
            // MF_openFile
            // 
            this.MF_openFile.Multiselect = true;
            // 
            // listChecksums
            // 
            this.listChecksums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listChecksums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listChecksums.FormattingEnabled = true;
            this.listChecksums.Items.AddRange(new object[] {
            "MD5",
            "SHA-1",
            "SHA-256",
            "SHA-384",
            "SHA-512",
            "CRC16",
            "CRC32"});
            this.listChecksums.Location = new System.Drawing.Point(514, 7);
            this.listChecksums.Name = "listChecksums";
            this.listChecksums.Size = new System.Drawing.Size(77, 21);
            this.listChecksums.TabIndex = 1;
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAlgorithm.Location = new System.Drawing.Point(449, 7);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(59, 21);
            this.labelAlgorithm.TabIndex = 10;
            this.labelAlgorithm.Text = "Algorithm: ";
            this.labelAlgorithm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MF_fileList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MF_buttonExport);
            this.splitContainer1.Panel2.Controls.Add(this.MF_progressBar);
            this.splitContainer1.Panel2.Controls.Add(this.MF_resultList);
            this.splitContainer1.Panel2.Controls.Add(this.MF_buttonBrowse);
            this.splitContainer1.Panel2.Controls.Add(this.MF_buttonCompare);
            this.splitContainer1.Size = new System.Drawing.Size(565, 169);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 8;
            // 
            // MF_buttonExport
            // 
            this.MF_buttonExport.Location = new System.Drawing.Point(3, 63);
            this.MF_buttonExport.Name = "MF_buttonExport";
            this.MF_buttonExport.Size = new System.Drawing.Size(75, 23);
            this.MF_buttonExport.TabIndex = 8;
            this.MF_buttonExport.Text = "Export...";
            this.MF_buttonExport.UseVisualStyleBackColor = true;
            this.MF_buttonExport.Visible = false;
            this.MF_buttonExport.Click += new System.EventHandler(this.MF_buttonExport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 257);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.listChecksums);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(623, 296);
            this.Name = "MainForm";
            this.Text = "Checksum Verifier Utility";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TF_contextMenu_checksum.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.MF_contextMenu_results.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label TF_labelFileSize;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip TF_contextMenu_checksum;
		private System.Windows.Forms.Label labelAlgorithm;
		private System.Windows.Forms.ComboBox listChecksums;
		private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip MF_contextMenu_results;
		private System.Windows.Forms.ProgressBar TF_progressBar;
		private System.Windows.Forms.ProgressBar MF_progressBar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox MF_textUserHash;
		private System.Windows.Forms.OpenFileDialog MF_openFile;
		private System.Windows.Forms.ListBox MF_fileList;
		private System.Windows.Forms.ListBox MF_resultList;
		private System.Windows.Forms.Button MF_buttonCompare;
		private System.Windows.Forms.Button MF_buttonBrowse;
		private System.Windows.Forms.OpenFileDialog TF_openFile;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label TF_hashLabel;
		private System.Windows.Forms.TextBox TF_textUserHash;
		private System.Windows.Forms.Label TF_fileLabel;
		private System.Windows.Forms.Button TF_buttonBrowse;
		private System.Windows.Forms.TextBox TF_textFilePath;
		private System.Windows.Forms.Label TF_labelFileHash;
		private System.Windows.Forms.TextBox TF_textFileHash;
		private System.Windows.Forms.Button TF_buttonCompare;
		private System.Windows.Forms.Label TF_labelResult;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button MF_buttonExport;
        private System.Windows.Forms.SaveFileDialog MF_exportFile;
	}
}
