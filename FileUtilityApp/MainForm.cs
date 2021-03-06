using FileUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUtilityApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                linkChangeTimestamp.Click += LinkChangeTimestamp_Click;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private async void LinkChangeTimestamp_Click(object sender, EventArgs e)
        {
            try
            {
                textOutput.Text = null;
                progressDirectory.Value = 0;
                progressFile.Value = 0;

                var fbd = new FolderBrowserDialog()
                {
                    Description = "Select Folder",
                    RootFolder = Environment.SpecialFolder.MyDocuments,

                };

                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                var folder = Folder.Get(fbd.SelectedPath);

                if (MessageBox.Show(this,
                    $"Set the timestamp of {folder.TotalFolderCount} folder(s) and {folder.TotalFileCount} file(s) to today's date and time?",
                    this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    return;

                folder.DirectoryChanged += DirectoryChanged;
                folder.FileChanged += FileChanged;

                progressDirectory.Minimum = 0;
                progressDirectory.Maximum = folder.TotalFolderCount;
                progressDirectory.Step = 1;
                progressDirectory.Value = 0;

                progressFile.Minimum = 0;
                progressFile.Maximum = folder.TotalFileCount;
                progressFile.Step = 1;
                progressFile.Value = 0;

                DateTime newDt = DateTime.Now;

                textOutput.Text = $"NEW TIMESTAMP: {newDt}" + Environment.NewLine;

                await Task.Run(() =>
                {
                    folder.ChangeTimeStamp(newDt);
                });

                textOutput.Text += "Done";
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private delegate void SafeFileChanged(FileInfo fiBefore, FileInfo fiAfter);

        private void FileChanged(FileInfo fiBefore, FileInfo fiAfter)
        {
            if (InvokeRequired)
            {
                Invoke(new SafeFileChanged(FileChanged), fiBefore, fiAfter);
            }
            else
            {
                textOutput.Text += $"{fiAfter.Name}" + Environment.NewLine;
                progressFile.PerformStep();
            }
        }

        private delegate void SafeDirectoryChanged(DirectoryInfo diBefore, DirectoryInfo diAfter);

        private void DirectoryChanged(DirectoryInfo diBefore, DirectoryInfo diAfter)
        {
            if (InvokeRequired)
            {
                Invoke(new SafeDirectoryChanged(DirectoryChanged), diBefore, diAfter);
            }
            else
            {
                textOutput.Text += $"{diAfter.FullName}" + Environment.NewLine;
                progressDirectory.PerformStep();
            }
        }

        public void ShowExceptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
        }
    }
}
