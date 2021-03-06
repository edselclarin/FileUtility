using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileUtility
{
    public class Folder
    {
        #region Properties
        public DirectoryInfo FolderInfo { get; internal set; }
        public List<Folder> SubFolders { get; internal set; }
        public List<FileInfo> Files { get; internal set; }
        public int TotalFolderCount { get; internal set; }
        public int TotalFileCount { get; internal set; }
        #endregion

        private Folder()
        {
            // Private so user is forced to use Get().
        }

        /// <summary>
        /// Creates an instance of Folder.
        /// </summary>
        public static Folder Get(string path)
        {
            var folder = new Folder()
            {
                FolderInfo = new DirectoryInfo(path),
                SubFolders = new List<Folder>()
            };

            // Get files in this directory.
            folder.Files = Directory
                .EnumerateFiles(path)
                .Select(x => new FileInfo(x))
                .ToList();

            folder.TotalFileCount += folder.Files.Count;

            // Get files is subdirectories.
            foreach (var subPath in Directory.EnumerateDirectories(path))
            {
                var subFolder = Get(subPath);
                folder.SubFolders.Add(subFolder);

                folder.TotalFolderCount += subFolder.TotalFolderCount;
                folder.TotalFileCount += subFolder.TotalFileCount;
            }

            folder.TotalFolderCount += folder.SubFolders.Count;

            return folder;
        }

        public void ChangeTimeStamp(DateTime newDt)
        {
            RecursivelyChangeTimeStamp(this, newDt);
        }

        private void RecursivelyChangeTimeStamp(Folder folder, DateTime newDt)
        {
            // Change this folder.
            var diBefore = new DirectoryInfo(folder.FolderInfo.FullName);

            folder.FolderInfo.CreationTime = newDt;
            folder.FolderInfo.LastAccessTime = newDt;
            folder.FolderInfo.LastWriteTime = newDt;

            DirectoryChanged?.Invoke(diBefore, folder.FolderInfo);

            // Change files in this folder.
            foreach (var file in folder.Files)
            {
                var fiBefore = new FileInfo(file.FullName);

                file.CreationTime = newDt;
                file.LastAccessTime = newDt;
                file.LastWriteTime = newDt;

                FileChanged.Invoke(fiBefore, file);
            }

            // Change files in subfolders.
            foreach (var subfolder in folder.SubFolders)
            {
                RecursivelyChangeTimeStamp(subfolder, newDt);
            }
        }

        #region Events
        public delegate void DirectoryChangedHandler(DirectoryInfo diBefore, DirectoryInfo diAfter);
        public event DirectoryChangedHandler DirectoryChanged;

        public delegate void FileChangedHandler(FileInfo fiBefore, FileInfo fiAfter);
        public event FileChangedHandler FileChanged;
        #endregion
    }
}
