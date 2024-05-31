using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SearchApp
{
    internal static class Extentions
    {
        public static DirectoryInfo[] GetAllSubDirectories(this DirectoryInfo dir, IProgress<DirectoryInfo> foundProgress)
        {
            if (!dir.Exists)
                return new DirectoryInfo[0];

            var results = new List<DirectoryInfo>();
            var subDirs = new DirectoryInfo[0];

            try
            {
                 subDirs = dir.GetDirectories();
            }
            catch 
            {
                return new DirectoryInfo[0];
            }

            foreach (DirectoryInfo subDir in subDirs) 
            { 
                results.Add(subDir); 
                foundProgress.Report(subDir);
            }

                foreach (DirectoryInfo subDir in subDirs)
                    results.AddRange(GetAllSubDirectories(subDir, foundProgress));

            return results.ToArray();
        }

        public static FileInfo[] GetAllFiles(this DirectoryInfo dir, IProgress<FileInfo> foundProgress)
        {
            var results = new List<FileInfo>();
            DirectoryInfo[] subDirs = dir.GetDirectories();
            try 
            {
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    results.Add(file);
                    foundProgress.Report(file);
                }
            }
            catch { }

            foreach (DirectoryInfo subDir in subDirs)
                try
                {
                    results.AddRange(GetAllFiles(subDir, foundProgress));
                }
                catch (UnauthorizedAccessException) { continue; }

            return results.ToArray();
        }


        public static TreeNode GetDirectoryNode(this DirectoryInfo directoryInfo)
        {
            TreeNode aNode;

            aNode = new TreeNode(directoryInfo.Name); //TODO: Add images ID after name
            aNode.Tag = directoryInfo;
            aNode.ImageKey = "folder";

            DirectoryInfo[] subDirs = directoryInfo.GetDirectories();
            FileInfo[] files = directoryInfo.GetFiles();


            foreach (DirectoryInfo subDir in subDirs)
                try
                {
                    aNode.Nodes.Add(GetDirectoryNode(subDir));
                }
                catch { continue; }

            foreach (var fileInfo in files)
                aNode.Nodes.Add(GetFileNode(fileInfo));
            
            return aNode;
        }

        public static TreeNode GetFileNode(this FileInfo fileInfo)
        {
            TreeNode aNode;

            aNode = new TreeNode(fileInfo.Name); //TODO: Add images ID after name
            aNode.Tag = fileInfo;
            aNode.ImageKey = "file"; //TODO: somehow find correct image and key for file

            return aNode;
        }
    }
}
