using System;
using System.IO;

namespace SearchApp
{
    internal class SearchConfiguration
    {
        private string FilePath { get; set; }


        public SearchConfiguration(string fileName)
        {
            FilePath= GetFilePath(fileName);
        }


        public void Save(string searchPath, string query)
        {
            ClearSave();
            File.AppendAllLines(FilePath, new string[]{ searchPath, query });
        }

        public bool TryLoad(out string searchPath, out string query)
        {
            searchPath = string.Empty;
            query = string.Empty;

            if (!IsSaved())
                return false;

            var dataStrings = File.ReadAllLines(FilePath);

            if(dataStrings.Length != 2)
                return false;

            searchPath = dataStrings[0];
            query = dataStrings[1];

            return true;
        }

        public bool IsSaved()
        {
            if (!File.Exists(FilePath))
                return false;

            var dataStrings = File.ReadAllLines(FilePath);
            return dataStrings.Length == 2;
        }

        public void ClearSave()
        {
            if (!IsSaved())
                return;

            File.Delete(FilePath);
        }



        private static string GetFilePath(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, fileName);
        }
    }
}
