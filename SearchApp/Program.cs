using System;
using System.Windows.Forms;

namespace SearchApp
{
    static class Program
    {
        private const string CONFIGURATION_FILE = "Config";

        private static SearchWindow searchWindow;

        public static SearchConfiguration Configuration { get; private set; }
        public static SearchPresenter Presenter { get; private set; }
        public static Search Search { get; private set; }
        public static Stopwatch Stopwatch { get; private set; }


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            searchWindow = new SearchWindow();

            Configuration=new SearchConfiguration(CONFIGURATION_FILE);
            Presenter = new SearchPresenter(searchWindow);
            Search = new Search(Presenter);
            Stopwatch = new Stopwatch(searchWindow.StopwatchUpdateTimer);

            Presenter.ResetUI();
            Configuration.TryLoad(out var searchPath, out var query);

            searchWindow.SearchQueryInput.Text = query;
            searchWindow.SearchFolderInput.Text = searchPath;

            Application.Run(searchWindow);
        }
    }
}
