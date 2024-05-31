using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;


namespace SearchApp
{
    class Search
    {
        public event Action Finished;

        private bool paused;

        private CancellationTokenSource Cancellation { get; set; }
        private SearchPresenter Presenter { get; set; }

        private int ItemCount { get; set; }
        private int FoundCount { get; set; }

        private bool Stopped => Cancellation != null ? Cancellation.IsCancellationRequested : true;


        public Search(SearchPresenter presenter) 
        {
            Presenter = presenter;

            Cancellation = new CancellationTokenSource();
        }

        

        /// <summary>
        /// Pause ongoing search if able
        /// </summary>
        public void Pause() 
        {
            if (Stopped)
                return;

            paused = true;
            Program.Stopwatch.Pause();
            Program.Presenter.SetState("Приостановлено");
        }

        /// <summary>
        /// Resume ongoing search if able
        /// </summary>
        public void Resume() 
        {
            if (Stopped)
                return;

            paused = false;
            Program.Stopwatch.Start();
            Program.Presenter.SetState("Возобновлено");
        }

        /// <summary>
        /// Stop ongoing search process if able
        /// </summary>
        public void Stop() 
        {
            if(Stopped) 
                return;

            Cancellation.Cancel();
            Program.Presenter.SetState("Поиск прерван");
        }


        /// <summary>
        /// Perform search in provided folder
        /// </summary>
        /// <param name="query">Provided search query</param>
        /// <param name="path">Provided Directory Info for search path</param>
        /// <returns></returns>
        public async Task SearchTask(string query, DirectoryInfo path)
        {
            ItemCount = 0;
            FoundCount = 0;
            paused = false;

            Cancellation?.Dispose();
            Cancellation = new CancellationTokenSource();
            Presenter.ResetUI();

            var directoryQueue = new Queue<DirectoryInfo>();
            var fileQueue = new Queue<FileInfo>();

            //Add to queue, add and update count
            var collectedDirectoryProgress = new Progress<DirectoryInfo>(OnDirectoryCollected);
            var collectedFileProgress = new Progress<FileInfo>(OnFileCollected);

            Presenter.SetState("Сбор сведений об элементах в папке поиска...");

            //Await those
            var tasks = new Task[]
            {
                Task.Run(()=> CollectAllDirectories(path, directoryQueue, collectedDirectoryProgress), Cancellation.Token),
                Task.Run(()=>CollectAllFiles(path, fileQueue, collectedFileProgress), Cancellation.Token)
            };

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (TaskCanceledException) { return; }

            Presenter.SetItemCount(directoryQueue.Count + fileQueue.Count);
            Presenter.SetState("Сбор сведений завершен, запущен поиск");

            var foundDirectoryProgress = new Progress<DirectoryInfo>(OnDirectoryFound);
            var foundFileProgress = new Progress<FileInfo>(OnFileFound);
            var pathSearchedProgress = new Progress<string>(OnPathSearched);

            try
            {
                await Task.Run(() => SearchAllFolders(query, directoryQueue, pathSearchedProgress, foundDirectoryProgress), Cancellation.Token);
            }
            catch (TaskCanceledException) { return; }
            try
            {
                await Task.Run(() => SearchAllFiles(query, fileQueue, pathSearchedProgress, foundFileProgress), Cancellation.Token);
            }
            catch (TaskCanceledException) { return; }

            //if(Stopped)
            //    return;

            Presenter.SetState("Поиск завершен");
            Finished?.Invoke();

            //Each new folder/file path currently in search gets its path on display
        }



        /// <summary>
        /// Enqueue all directories from provided
        /// </summary>
        /// <param name="path">Provided root directory</param>
        /// <param name="directoryQueue">Provided directory Queue</param>
        /// <param name="collectedProgress">Provided on collected progress</param>
        private async void CollectAllDirectories(DirectoryInfo path, Queue<DirectoryInfo> directoryQueue, IProgress<DirectoryInfo> collectedProgress)
        {
            foreach (var subDir in path.GetAllSubDirectories(collectedProgress))
            {
                while (paused && !Stopped)
                    await Task.Yield();

                if (Stopped)
                    return;

                directoryQueue.Enqueue(subDir);
                collectedProgress?.Report(subDir);
            }
        }

        /// <summary>
        /// Enqueue all files from provided firectory
        /// </summary>
        /// <param name="path">Provided root directory</param>
        /// <param name="fileQueue">Provided file Queue</param>
        /// <param name="collectedProgress">Provided on collected progress</param>
        private void CollectAllFiles(DirectoryInfo path, Queue<FileInfo> fileQueue, IProgress<FileInfo> collectedProgress)
        {
            foreach (var file in path.GetFiles())
            {
                while (paused && !Stopped)
                    Thread.Sleep(10);

                if (Stopped)
                    return;

                fileQueue.Enqueue(file);
                collectedProgress?.Report(file);
            }
        }


        /// <summary>
        /// Search all folders, each valid element gets added into tree and all it's sub elements
        /// </summary>
        /// <param name="query">Regex string for name search</param>
        /// <param name="directoryQueue">Queue of all found directories</param>
        /// <param name="foundProgress">Provided directory found Progress</param>
        private void SearchAllFolders(string query, Queue<DirectoryInfo> directoryQueue, IProgress<string> pathSearchedProgress, IProgress<DirectoryInfo> foundProgress)
        {
            Regex regex;
            DirectoryInfo directory;

            while (directoryQueue.Count > 0)
            {
                //TODO: Remove for faster work
                Thread.Sleep(10);

                //How to wait for unpause?
                while (paused && !Stopped)
                    Thread.Sleep(10);

                if (Stopped)
                    return;

                regex = new Regex(query);
                directory = directoryQueue.Dequeue();

                //Show path
                pathSearchedProgress.Report(directory.FullName);

                if (!regex.IsMatch(directory.Name))
                    continue;

                foundProgress.Report(directory);
            }
        }

        /// <summary>
        /// Search all files, each valid element gets added into tree
        /// </summary>
        /// <param name="query">Regex string for name search</param>
        /// <param name="fileQueue">Queue of all found files</param>
        /// <param name="progress">Provided file found Progress</param>
        private void SearchAllFiles(string query, Queue<FileInfo> fileQueue, IProgress<string> pathSearchedProgress, IProgress<FileInfo> progress)
        {
            Regex regex;
            FileInfo file;

            while (fileQueue.Count > 0)
            {
                //TODO: Remove for faster work
                Thread.Sleep(10);

                while (paused && !Stopped)
                    Thread.Sleep(10);

                if (Stopped)
                    return;

                regex = new Regex(query);
                file = fileQueue.Dequeue();

                //Show path
                pathSearchedProgress.Report(file.FullName);

                if (!regex.IsMatch(file.Name))
                    continue;

                progress.Report(file);
            }
        }


        #region Progress report methods
        private void OnDirectoryCollected(DirectoryInfo directory)
        {
            ItemCount++;
            Presenter.SetItemCount(ItemCount);
        }

        private void OnFileCollected(FileInfo file)
        {
            ItemCount++;
            Presenter.SetItemCount(ItemCount);
        }

        private void OnDirectoryFound(DirectoryInfo directory)
        {
            Presenter.AddToFound(directory);

            FoundCount++;
            Presenter.SetFoundCount(FoundCount);
        }

        private void OnFileFound(FileInfo file)
        {
            Presenter.AddToFound(file);

            FoundCount++;
            Presenter.SetFoundCount(FoundCount);
        }

        private void OnPathSearched(string path)
        {
            Presenter.SetSearchedPath(path);
        }
        #endregion
    }
}
