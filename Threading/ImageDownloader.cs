using System;
using System.Net;
using System.Threading;

namespace Threading
{
    public class ImageDownloader
    {
        private string downloadFolderPath = null;

        public ImageDownloader(string downloadFolderPath)
        {
            this.downloadFolderPath = downloadFolderPath;
        }

        public static void Main(string[] args)
        {
            string[] urls = new string[]
            {
                "http://www.thecatsbreeds.net/gallery/burmilla-cat/burmilla_cat_1.jpg",
                "http://www.petsgroomingprices.com/wp-content/uploads/2015/02/cat-playing.jpg",
                "https://foguth.files.wordpress.com/2014/11/19068-chocolate-somali-cat-white-background.jpg",
                "http://www.jeremynoeljohnson.com/wp-content/uploads/2014/06/crazy_cat_10.jpg",
                "http://upload.wikimedia.org/wikipedia/commons/4/49/Cat_face_day.jpg",
                "http://wallpaperspoints.com/wp-content/uploads/2013/09/siamese-cat-high-quality-wallpapers.jpg"
            };

            ImageDownloader downloader = new ImageDownloader("C:\\Downloads");
            foreach(string url in urls)
            {
                downloader.QueueDownload(url);
            }

            Console.WriteLine("Create C:\\Downloads folder before running the program.");
            Console.WriteLine("Images are being download in background... Maybe already done.");
            Console.ReadKey();
        }

        public void QueueDownload(string url)
        {
            ThreadPool.QueueUserWorkItem(this.DownloadImage, url);
        }

        private void DownloadImage(object url)
        {
            // Remember the API
            using (WebClient webClient = new WebClient())
            {
                string urlString = (string)url;
                webClient.DownloadFile(urlString, GetFileNameFromUrl(urlString));
            }
        }

        private string GetFileNameFromUrl(string url)
        {
            return this.downloadFolderPath + "\\" + url.Substring(url.LastIndexOf('/') + 1);
        }
    }


}
