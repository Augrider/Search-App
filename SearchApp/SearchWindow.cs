using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SearchApp
{
    public partial class SearchWindow : Form
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Subscribe to event
            Program.Search.Finished += (Action)ResetSearchButtons;
        }
        

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            //TODO: Open file/folder if possible
        }

        

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            SearchButton.Enabled = false;
            PauseButton.Enabled = true;
            ResumeButton.Enabled = false;
            StopButton.Enabled = true;

            var path = SearchFolderInput.Text;
            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists) 
            {
                Program.Presenter.SetState("Ошибка! Папка поиска не существует");
                return; //TODO: Warning for non-existant path
            }

            try
            {
                //Check if Regex is valid
                Regex.Match(path, SearchQueryInput.Text);
            }
            catch 
            {
                Program.Presenter.SetState("Ошибка! Проверьте запрос на соответствие Regex");
                return; 
            }

            Program.Configuration.Save(path, SearchQueryInput.Text);

            Program.Stopwatch.Start();
            await Program.Search.SearchTask(SearchQueryInput.Text, directoryInfo);
            Program.Stopwatch.Stop();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            ResumeButton.Enabled = true;
            PauseButton.Enabled = false;

            Program.Search.Pause();
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            ResumeButton.Enabled = false;
            PauseButton.Enabled = true;

            Program.Search.Resume();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ResetSearchButtons();

            //Stop
            Program.Search.Stop();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            var path = SearchFolderInput.Text;
            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                Program.Presenter.SetState("Ошибка! Папка поиска не существует");
                return; //TODO: Warning for non-existant path
            }

            //TODO: Check for access violations
            Program.Presenter.ClearFound();
            //Open - add all folders and files as tree nodes inside treeView
            Program.Presenter.AddToFound(directoryInfo);
        }

        private void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            TimeText.Text = Program.Stopwatch.GetElapsed();
        }



        private void ResetSearchButtons()
        {
            SearchButton.Enabled = true;
            PauseButton.Enabled = false;
            ResumeButton.Enabled = false;
            StopButton.Enabled = false;
        }
    }
}
