using System;
using System.Collections.Generic;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;

namespace DownloadExample
{
    public class Downloader
    {
        //public IDownloadFile File;
        public List<IDownloadFile> Files = new List<IDownloadFile>();


        public Downloader()
        {  
            CrossDownloadManager.Current.CollectionChanged += (sender, e) => 
                System.Diagnostics.Debug.WriteLine(
                    "[DownloadManager] " + e.Action +
                    " -> New items: " + (e.NewItems?.Count ?? 0) +
                    " at " + e.NewStartingIndex +
                    " || Old items: " + (e.OldItems?.Count ?? 0) +
                    " at " + e.OldStartingIndex
                );
        }

        public void InitializeDownload()
        {

            for (int i = 0; i < 40; i++) {
                var file = CrossDownloadManager.Current.CreateDownloadFile("http://via.placeholder.com/350x" + (150 + i));
                this.Files.Add(file);
            }

        }

        public void StartDownloading (bool mobileNetworkAllowed)
        {
            foreach (var f in Files) {
                CrossDownloadManager.Current.Start(f, true);
            }
        }

        public void AbortDownloading ()
        {
            //CrossDownloadManager.Current.Abort (File);
        }

        /*
        public bool IsDownloading ()
        {
            if (File == null) return false;

            switch (File.Status) {
                case DownloadFileStatus.INITIALIZED:
                case DownloadFileStatus.PAUSED:
                case DownloadFileStatus.PENDING:
                case DownloadFileStatus.RUNNING:
                    return true;

                case DownloadFileStatus.COMPLETED:
                case DownloadFileStatus.CANCELED:
                case DownloadFileStatus.FAILED:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/
   }
}

