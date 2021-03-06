using FileUtility;
using System;
using System.IO;

namespace FileUtilityCon
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"C:\Users\Edsel\Documents\Projects\Temp\MoneyBook-00";
                DateTime newDt = DateTime.Now;

                var folder = Folder.Get(path);
                folder.DirectoryChanged += Folder_DirectoryChanged;
                folder.FileChanged += Folder_FileChanged;
                folder.ChangeTimeStamp(newDt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION:");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void Folder_FileChanged(FileInfo fiBefore, FileInfo fiAfter)
        {
            Console.WriteLine($"FILE: {fiBefore.Name}");
        }

        private static void Folder_DirectoryChanged(DirectoryInfo diBefore, DirectoryInfo diAfter)
        {
            Console.WriteLine($"DIRECTORY: {diBefore.Name}");
        }
    }
}
