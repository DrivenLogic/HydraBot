using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HydraBot.DataStructures;
using NLog;

namespace HydraBot.Domain
{
    /// <summary>
    /// must return tasks back to the bot controller
    /// </summary>
    public class HttpDownloader : IDownload
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        public HttpDownloader()
        {

        }

        /// <summary>
        /// manually add the first task to the queue
        /// </summary>
        /// <param name="startLocation"></param>
        public void SeedWorkQueue(IAssetPointer startLocation)
        {
            Task<string> hypertextTask = GetText(startLocation.Uri);
            WorkQueues.DownloadHyperTextQueue.Enqueue(hypertextTask);
        }

        /// <summary>
        /// An async task that returns a hypertext string from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>text from a link</returns>
        public async Task<string> GetText(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            _log.Info("Completed hypertext download: {0}", uri);

            return result;
        }

        /// <summary>
        /// An async task that retrurns a bytem array from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>a binary from a link</returns>
        public async Task<byte[]> GetBinary(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            byte[] binary = await response.Content.ReadAsByteArrayAsync();

            _log.Info("Completed downloading binary: {0}", uri);

            return binary;
        }
    }
}
