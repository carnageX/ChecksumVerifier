using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
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
			this.listChecksums.Visible = false;
			this.listChecksums.Enabled = false;

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
                    this.TF_textFileHash.ForeColor = Color.Black;
                    this.TF_textFileHash.Clear();
					this.Cursor = Cursors.WaitCursor;
					this.TF_progressBar.Increment(99);
					
					//string hash = GetHash(this.TF_textFilePath.Text, this.listChecksums.SelectedItem.ToString());
					//this.TF_textFileHash.Text = hash;
                    List<string> selectedAlgorithms = GetSelectedAlgorithms(this.ccblistChecksums);
					List<string> hashList = ChecksumVerifier.GetHash(this.TF_textFilePath.Text, selectedAlgorithms);

					this.TF_progressBar.Increment(1);
					this.Cursor = Cursors.Default;

					if (String.IsNullOrWhiteSpace(this.TF_textUserHash.Text)) 
					{
                        for(int i = 0; i < hashList.Count; i++)
                        {
                            this.TF_textFileHash.AppendText(String.Format("{0} == {1}{2}", selectedAlgorithms[i], hashList[i], System.Environment.NewLine));
                        }//for
					}//if
					else
					{
						foreach (string hash in hashList)
						{
							if (ChecksumVerifier.CompareHashes(this.TF_textUserHash.Text, hash))
							{
                                //this.TF_textFileHash.ForeColor = Color.Green;
                                //this.TF_labelResult.Text += String.Format("Valid! Checksum {0} matches! {1}", hash, System.Environment.NewLine);
                                //this.TF_labelResult.Show();

								this.TF_textFileHash.ForeColor = Color.Green;
								this.TF_textFileHash.AppendText(String.Format("Valid! Checksum {0} matches!{1}", hash, System.Environment.NewLine));
							}//if
							else
							{
                                //this.TF_textFileHash.ForeColor = Color.Red;
                                //this.TF_labelResult.Text += String.Format("Invalid! Checksum {0} mismatches!{1}", hash, System.Environment.NewLine);
                                //this.TF_labelResult.Show();

                                this.TF_textFileHash.ForeColor = Color.Red;
                                this.TF_textFileHash.AppendText(String.Format("Invalid! Checksum {0} mismatches!{1}", hash, System.Environment.NewLine));
							}//else
						}//foreach
					}//else
                    this.TF_labelResult.ForeColor = Color.Green;
                    this.TF_labelResult.Text = "Finished!";
                    this.TF_labelResult.Show();
				}//try
				catch(Exception ex)
				{
					this.TF_labelResult.Text = "Error! " + ex.Message;
					//this.TF_textFileHash.Clear();
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
				this.MF_exportFile.FileName = "ChecksumList.txt";
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
					string hash = ChecksumVerifier.GetHash(this.MF_fileList.Items[i].ToString(), this.listChecksums.SelectedItem.ToString());
					this.MF_progressBar.Increment(1);
					if(this.MF_textUserHash.Text.Trim() != String.Empty)
					{
						if(ChecksumVerifier.CompareHashes(this.MF_textUserHash.Text, hash))
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

		private List<string> GetSelectedAlgorithms(CheckedComboBox algorithmList)
		{
			string[] selectedItems = new string[algorithmList.Items.Count];
			CheckedListBox.CheckedItemCollection list = algorithmList.CheckedItems;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    selectedItems[i] = list[i].ToString();
            }//for

            for (int i = 0; i < selectedItems.Length; i++)
            {
                if (selectedItems[i] == null)
                    selectedItems[i] = String.Empty;
            }//for
            List<string> strAlgList = new List<string>(selectedItems);
            strAlgList.RemoveAll(IsEmptyString);
            return strAlgList;
		}//GetSelectedAlgorithms

        /// <summary>String Predicate that matches if the given string mathes an empty string</summary>
        /// <param name="s">Input string</param>
        /// <returns>True or False</returns>
        private static bool IsEmptyString(string s)
        {
            return s.Equals(String.Empty);
        }//IsEmptyString
		#endregion
	}//Class
}//Namespace
