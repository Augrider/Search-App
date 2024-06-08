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
        /// <summary>
        /// Get directories inside provided folder
        /// </summary>
        /// <param name="dir"> Provided directory </param>
        public static DirectoryInfo[] GetSubDirectories(this DirectoryInfo dir)
        {
            if (!dir.Exists)
                return new DirectoryInfo[0];

            var subDirs = new DirectoryInfo[0];

            try
            {
                 subDirs = dir.GetDirectories();
            }
            catch 
            {
                return new DirectoryInfo[0];
            }

            //foreach (DirectoryInfo subDir in subDirs)
            //    results.AddRange(GetSubDirectories(subDir, foundProgress));

            return subDirs;
        }

        /// <summary>
        /// Get files inside provided folder
        /// </summary>
        /// <param name="dir"> Provided Directory </param>
        public static FileInfo[] GetAllFiles(this DirectoryInfo dir)
        {
            if (!dir.Exists)
                return new FileInfo[0];

            var files = new FileInfo[0];

            try
            {
                files = dir.GetFiles();
            }
            catch
            {
                return new FileInfo[0];
            }

            //foreach (DirectoryInfo subDir in subDirs)
            //    results.AddRange(GetSubDirectories(subDir, foundProgress));

            return files;
        }
    }
}
