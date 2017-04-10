using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading
{
    public class WebCrawler
    {
        private Queue<string> queue = null;
        private HashSet<string> visited = null;

        public WebCrawler()
        {
            queue = new Queue<string>();
            visited = new HashSet<string>();
        }

        public static void Main(string[] args)
        {
            WebCrawler crawler = new WebCrawler();
            crawler.Crawl(new string[] { "http://www.geeksforgeeks.org/" });
            Console.ReadKey();
        }

        // Start with a list of seed URLs
        // For each URL, get content, save the snapshot.
        // Extract links from the content, check policy, add links to the queue.
        public void Crawl(string[] seedUrls)
        {
            foreach(string seedUrl in seedUrls)
            {
                queue.Enqueue(seedUrl);
            }

            while(true)
            {
                if (queue.Count > 0)
                {
                    ThreadPool.QueueUserWorkItem(this.Crawl, queue.Dequeue());
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void Crawl(object oURL)
        {
            string url = (string)oURL;
            if (ShouldCrawl(url))
            {
                string content = GetContent(url);
                if (!string.IsNullOrEmpty(content))
                {
                    SaveContent(url, content);
                    string[] links = GetLinks(content);

                    foreach (string link in links)
                    {
                        queue.Enqueue(link);
                    }
                }
            }
        }

        private bool ShouldCrawl(string url)
        {
            // TODO: Check policies
            return !visited.Contains(url);
        }

        private string GetContent(string url)
        {
            // Remember the API
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    string content = client.DownloadString(url);
                    visited.Add(url);
                    Console.WriteLine(url);
                    return content;
                }
            }
            catch (Exception)
            {
                // In case download failure
                return string.Empty;
            }
        }

        private void SaveContent(string url, string content)
        {
            // TODO: Save the content as snapshot
        }

        private string[] GetLinks(string content)
        {
            List<string> links = new List<string>();
            var matches = System.Text.RegularExpressions.Regex.Matches(content, "href=\"http(.*?)\"");
            foreach(var match in matches)
            {
                string href = match.ToString();
                links.Add(href.Substring(6, href.Length - 7));
            }

            return links.ToArray();
        }
    }
}
