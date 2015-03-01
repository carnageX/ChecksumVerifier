using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Cryptography;
using CheckComboBoxTest;

namespace MD5HashCheckGUI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		#region Form Methods
		/// <summary>Default Constructor</summary>
		public MainForm()
		{
			InitializeComponent();
			this.TF_labelResult.Hide();
			this.listChecksums.SelectedIndex = 0;
			this.TF_labelFileSize.Text = "";

            this.TF_buttonCompare.Text = "Generate";
            this.MF_buttonCompare.Text = "Generate";

            List<string> algorithms = new List<string>() { "MD5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "CRC16", "CRC32" };

            this.ccblistChecksums.DisplayMember = "name";
            this.ccblistChecksums.ValueMember = "val";
            this.ccblistChecksums.ValueSeparator = "+";
            PopulateAlgorithmList(algorithms);
		}//MainForm

		#region Text/File Compare
		/// <summary>TF File browse button click</summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Argument</param>
		void TF_buttonBrowseClick(object sender, EventArgs e)
		{
			this.TF_openFile.ShowDialog();
			this.TF_textFilePath.Text = this.TF_openFile.FileName;
			if(this.TF_openFile.FileName != "")
			{
				FileInfo fileInfo = new FileInfo(this.TF_openFile.FileName);
				this.TF_labelFileSize.Text = "(" + ((fileInfo.Length / 1024) + 1) + " KB)"; //for some reason file size is off by 1; adding 1 fixes this
			}//if
			this.TF_progressBar.Value = 0;
		}//Browse
		
		/// <summary>TF Compare button click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TF_buttonCompareClick(object sender, EventArgs e)
		{
			this.TF_labelResult.Hide();
			this.TF_labelResult.ForeColor = Color.Black;

			if(this.TF_textFilePath.Text.Trim() != String.Empty)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					this.TF_progressBar.Increment(99);
					
					string hash = GetHash(this.TF_textFilePath.Text, this.listChecksums.SelectedItem.ToString());
					this.TF_textFileHash.Text = hash;
					
					this.TF_progressBar.Increment(1);
					this.Cursor = Cursors.Default;
					
					if(this.TF_textUserHash.Text.Trim() != String.Empty)
					{
						if(CompareHashes(this.TF_textUserHash.Text, hash))
						{
							this.TF_textFileHash.ForeColor = Color.Green;
							this.TF_labelResult.Text = "Valid! Checksums match!";
							this.TF_labelResult.Show();
						}//if
						else
						{
							this.TF_textFileHash.ForeColor = Color.Red;
							this.TF_labelResult.Text = "Invalid! Checksum mismatch!";
							this.TF_labelResult.Show();
						}//else
					}//if
					else
					{
						this.TF_textFileHash.ForeColor = Color.Black;
					}//else
				}//try
				catch(Exception ex)
				{
					this.TF_labelResult.Text = ex.Message;
					this.TF_textFileHash.Text = "";
					this.TF_labelFileSize.Text = "";
					this.TF_labelResult.Show();
					this.Cursor = Cursors.Default;
					this.TF_progressBar.Value = 0;
				}//catch
			}//if
			else
			{
				this.TF_labelResult.Text = "Error!  No file to calculate checksum!";
				this.TF_labelResult.ForeColor = Color.Red;
				this.TF_labelResult.Show();
			}//else
		}//Compare
		
		/// <summary>Toolstrip menu item Copy click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void CopyToolStripMenuItem1Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.TF_textFileHash.Text);
		}//copy

        /// <summary>TF User provided hash textbox text changed event</summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Argument</param>
        private void TF_textUserHash_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TF_textUserHash.Text))
            {
                this.TF_buttonCompare.Text = "Generate";
            }
            else
            {
                this.TF_buttonCompare.Text = "Compare";
            }
        }
		#endregion

		#region Multiple File Compare
		/// <summary>MF File browse button click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MF_buttonBrowseClick(object sender, EventArgs e)
		{
			this.MF_openFile.ShowDialog();
			this.MF_fileList.Items.Clear();
			foreach(string s in this.MF_openFile.FileNames)
			{
				this.MF_fileList.Items.Add(s);
			}//foreach
			this.MF_progressBar.Minimum = 1;
			this.MF_progressBar.Maximum = this.MF_fileList.Items.Count;
		}//Browse

        /// <summary>MF File Export button click</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MF_buttonExport_Click(object sender, EventArgs e)
        {
            if (this.MF_fileList.Items.Count > 0)
            {
                this.MF_exportFile.Filter = "Text File | *.txt";
                this.MF_exportFile.Title = "Save generated checksums...";
                this.MF_exportFile.FileName = listChecksums.SelectedItem.ToString() + "ChecksumList.txt";
                this.MF_exportFile.ShowDialog();

                using (StreamWriter swExport = new StreamWriter(this.MF_exportFile.OpenFile()))
                {
                    for (int i = 0; i < this.MF_resultList.Items.Count; i++)
                    {
                        swExport.WriteLine(this.MF_resultList.Items[i].ToString());
                    }//for
                }//using
            }
            else
            {
                MessageBox.Show("Error!  No checksums to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//Export
		
		/// <summary>MF Compare button click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MF_buttonCompareClick(object sender, EventArgs e)
		{
			this.MF_progressBar.Minimum = 0;
			this.MF_progressBar.Maximum = this.MF_fileList.Items.Count;
			this.MF_resultList.Items.Clear();
			
			if(this.MF_fileList.Items.Count > 0)
			{
				this.Cursor = Cursors.WaitCursor;
				for(int i = 0; i < this.MF_fileList.Items.Count; i++)
				{
					string hash = GetHash(this.MF_fileList.Items[i].ToString(), this.listChecksums.SelectedItem.ToString());
					this.MF_progressBar.Increment(1);
					if(this.MF_textUserHash.Text.Trim() != String.Empty)
					{
						if(CompareHashes(this.MF_textUserHash.Text, hash))
						{
							this.MF_resultList.Items.Add(String.Format("{0}: Checkum match! - {1} - {2}", this.MF_fileList.Items[i].ToString(), this.listChecksums.SelectedItem.ToString(), hash));
						}//if
						else
						{
                            this.MF_resultList.Items.Add(String.Format("{0}: Checkum mismatch! - {1} - {2}", this.MF_fileList.Items[i].ToString(), this.listChecksums.SelectedItem.ToString(), hash));
						}//else
					}//if
					else
					{
                        this.MF_resultList.Items.Add(String.Format("{0} - {1} - {2}", this.MF_fileList.Items[i].ToString(), this.listChecksums.SelectedItem.ToString(), hash));
					}//else
				}//for
				this.Cursor = Cursors.Default;
			}//if
			else
			{
				this.MF_resultList.Items.Add("Error!  No file(s) to calculate checksum!");
			}//else
		}//Compare
		
		/// <summary>MF Copy menu item click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void CopyToolStripMenuItemClick(object sender, EventArgs e)
		{
			string tempStr = String.Empty;
			
			for(int i = 0; i < this.MF_resultList.SelectedItems.Count; i++)
			{
				tempStr += this.MF_resultList.SelectedItems[i].ToString() + "\n";
			}//for
			
			Clipboard.SetText(tempStr);
		}//Copy Selected
		
		/// <summary>Copy all menu item click</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void CopyAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			string tempStr = String.Empty;
			
			for(int i = 0; i < this.MF_resultList.Items.Count; i++)
			{
				tempStr += this.MF_resultList.Items[i].ToString() + "\n";
			}//for
			
			Clipboard.SetText(tempStr);
		}//Copy All

        /// <summary>MF User provided hash textbox text changed event</summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Argument</param>
        private void MF_textUserHash_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(MF_textUserHash.Text))
            {
                this.MF_buttonCompare.Text = "Generate";
            }
            else
            {
                this.MF_buttonCompare.Text = "Compare";
            }
        }
		#endregion
		#endregion
		
		#region Helper Methods
        /// <summary>Populate the list of ComboCheckBox with given algorithms</summary>
        /// <param name="algorithms">String list of algorithms</param>
        private void PopulateAlgorithmList(List<string> algorithms)
        {
            foreach(var s in algorithms)
            {
                CCBoxItem item = new CCBoxItem(s, algorithms.IndexOf(s));
                this.ccblistChecksums.Items.Add(item);
                this.ccblistChecksums.SetItemChecked(0, true);
            }//foreach
        }//PopulateAlgorithmList
        
		/// <summary>Generates checksum hash of a given file using a given algorithm.</summary>
		/// <param name="filename">File path and name to generate checksum.</param>
		/// <param name="hashOption">Checksum Algorithm.  Options are: MD5, SHA-1, SHA-256, SHA-384, and SHA-512</param>
		/// <returns>Hash string to be returned.</returns>
		private static string GetHash(string filename, string hashOption)
		{
			try
			{
				return ComputeHashAlgorithm(filename, hashOption);
			}//try
			catch
			{
				throw;
			}//catch
		}//GetHash

		/// <summary>Gets the computed checksum for the provided file using the provided algorithm</summary>
		/// <param name="filename">File to read</param>
		/// <param name="hashOption">Hash algorithm to use when generating checksum</param>
		/// <returns></returns>
		private static string ComputeHashAlgorithm(string filename, string hashOption)
		{
			string computedHash = String.Empty;

			if (hashOption.ToLower() == "md5")
			{
				MD5 md5Checksum = MD5.Create();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					computedHash = FormatHashChecksum(md5Checksum.ComputeHash(fs));
				}//using  
			}//if
			else if (hashOption.ToLower() == "sha-1")
			{
				SHA1 sha1Checksum = SHA1.Create();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					computedHash = FormatHashChecksum(sha1Checksum.ComputeHash(fs));
				}//using 
			}//else if
			else if (hashOption.ToLower() == "sha-256")
			{
				SHA256 sha256Checksum = SHA256.Create();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					computedHash = FormatHashChecksum(sha256Checksum.ComputeHash(fs));
				}//using 
			}//else if
			else if (hashOption.ToLower() == "sha-384")
			{
				SHA384 sha384Checksum = SHA384.Create();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					computedHash = FormatHashChecksum(sha384Checksum.ComputeHash(fs));
				}//using 
			}//else if
			else if (hashOption.ToLower() == "sha-512")
			{
				SHA512 sha512Checksum = SHA512.Create();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					computedHash = FormatHashChecksum(sha512Checksum.ComputeHash(fs));
				}//using 
			}//else if
			else if (hashOption.ToLower() == "crc16")
			{
                CRC16 crc16Checksum = new CRC16();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    foreach (byte b in crc16Checksum.ComputeHash(fs))
                    {
                        computedHash =  computedHash.Insert(0, b.ToString("x2").ToLower());
                    }//foreach
                }//using
				//throws arithmetic overflow when choosing crc16
			}//else if
			else if (hashOption.ToLower() == "crc32")
			{
				CRC32 crc32Checksum = new CRC32();
				using (FileStream fs = File.Open(filename, FileMode.Open))
				{
					foreach (byte b in crc32Checksum.ComputeHash(fs))
					{
						computedHash = computedHash.Insert(0, b.ToString("x2").ToLower());
					}//foreach
				}//using
			}//else if
			else
			{
				computedHash = "Not a valid algorithm option!";
			}//else
			return computedHash;
		}//ComputeHashAlgorithm

		/// <summary>Formats the inputted byte array by removing hyphens</summary>
		/// <param name="hashArray">Byte array computed from checksum</param>
		/// <returns>Formatted checksum string</returns>
		private static string FormatHashChecksum(byte[] hashArray)
		{
			return BitConverter.ToString(hashArray).Replace("-", "").ToLower();
		}//FormatHashChecksum
		
		/// <summary>Compares two checksums and returns true if they are the same, otherwise false.</summary>
		/// <param name="hash1">First checksum hash to compare</param>
		/// <param name="hash2">Second checksum hash to compare</param>
		/// <returns>True/False if hash strings are the same</returns>
		private bool CompareHashes(string hash1, string hash2)
		{
			if(String.Equals(hash1.ToLower().Trim(), hash2.ToLower().Trim()))
				return true;
			else
				return false;
		}//CompareHashes
		
		/// <summary>Compares a list of checksum strings to a single inputted checksum.</summary>
		/// <param name="hash">Single checksum to compare against.</param>
		/// <param name="hashFileList">List of checksum strings to compare against the single checksum.</param>
		/// <returns></returns>
		private bool CompareHashes(string hash, List<string> hashFileList)
		{
			return hashFileList.Contains(hash.Trim());
        }//CompareHashes
		#endregion
	}//Class
}//Namespace
