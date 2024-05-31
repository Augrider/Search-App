using System.IO;
using System.Windows.Forms;

namespace SearchApp
{
    class SearchPresenter
    {
        private SearchWindow Window { get; set; }


        public SearchPresenter(SearchWindow window)
        {
            Window = window;
        }


        public void ResetUI() 
        {
            Window.FoundText.Text = "";
            SetItemCount(0);

            SetTime("");
            SetState("");

            ClearFound();
        }


        //Methods for displaying different search related data and results
        public void SetFoundCount(int value) 
        {
            Window.FoundText.Text = "Найдено " + value.ToString();
        }

        public void SetItemCount(int value) 
        {
            Window.CountText.Text = value.ToString() + " элементов";
        }

        public void SetTime(string timeText)
        {
            Window.TimeText.Text = timeText;
        }


        public void SetState(string text) 
        {
            Window.StateText.Text = text;
        }

        public void SetSearchedPath(string path) 
        {
            Window.StateText.Text = path;
        }


        public void AddToFound(DirectoryInfo directory) 
        {
            var directoryNode = GetDirectoryNode(directory);
            Window.ResultsView.Nodes.Add(directoryNode);
        }

        public void AddToFound(FileInfo file) 
        {
            var fileNode = GetFileNode(file);
            Window.ResultsView.Nodes.Add(fileNode);
        }

        public void ClearFound() 
        {
            Window.ResultsView.Nodes.Clear();
        }



        private TreeNode GetDirectoryNode(DirectoryInfo directoryInfo)
        {
            TreeNode aNode;

            aNode = new TreeNode(directoryInfo.Name, 0, 0); //TODO: Add images ID after name
            aNode.Tag = directoryInfo;
            aNode.ImageKey = "folder";

            var subDirs = new DirectoryInfo[0];
            var files = new FileInfo[0];

            try 
            {
             subDirs = directoryInfo.GetDirectories();
            }
            catch { }
            try
            {
                files = directoryInfo.GetFiles();
            }
            catch { }

            foreach (DirectoryInfo subDir in subDirs)
                    aNode.Nodes.Add(GetDirectoryNode(subDir));

                foreach (var fileInfo in files)
                    aNode.Nodes.Add(GetFileNode(fileInfo));

            return aNode;
        }


        private TreeNode GetFileNode(FileInfo fileInfo)
        {
            TreeNode aNode;

                aNode = new TreeNode(fileInfo.Name, 1, 1); //TODO: Add images ID after name
                aNode.Tag = fileInfo;
                aNode.ImageKey = "file"; //TODO: somehow find correct image and key for file

                return aNode;
        }
    }
}
