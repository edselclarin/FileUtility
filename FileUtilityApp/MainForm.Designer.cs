
namespace FileUtilityApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressDirectory = new System.Windows.Forms.ProgressBar();
            this.progressFile = new System.Windows.Forms.ProgressBar();
            this.linkChangeTimestamp = new System.Windows.Forms.LinkLabel();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressDirectory
            // 
            this.progressDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressDirectory.Location = new System.Drawing.Point(12, 12);
            this.progressDirectory.Name = "progressDirectory";
            this.progressDirectory.Size = new System.Drawing.Size(566, 20);
            this.progressDirectory.TabIndex = 0;
            // 
            // progressFile
            // 
            this.progressFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressFile.Location = new System.Drawing.Point(12, 38);
            this.progressFile.Name = "progressFile";
            this.progressFile.Size = new System.Drawing.Size(566, 20);
            this.progressFile.TabIndex = 1;
            // 
            // linkChangeTimestamp
            // 
            this.linkChangeTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkChangeTimestamp.AutoSize = true;
            this.linkChangeTimestamp.Location = new System.Drawing.Point(197, 311);
            this.linkChangeTimestamp.Name = "linkChangeTimestamp";
            this.linkChangeTimestamp.Size = new System.Drawing.Size(190, 15);
            this.linkChangeTimestamp.TabIndex = 4;
            this.linkChangeTimestamp.TabStop = true;
            this.linkChangeTimestamp.Text = "Change Folder and File Timestamp";
            // 
            // textOutput
            // 
            this.textOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOutput.Location = new System.Drawing.Point(12, 64);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textOutput.Size = new System.Drawing.Size(565, 229);
            this.textOutput.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 340);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.linkChangeTimestamp);
            this.Controls.Add(this.progressFile);
            this.Controls.Add(this.progressDirectory);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Utility";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressDirectory;
        private System.Windows.Forms.ProgressBar progressFile;
        private System.Windows.Forms.LinkLabel linkChangeTimestamp;
        private System.Windows.Forms.TextBox textOutput;
    }
}

