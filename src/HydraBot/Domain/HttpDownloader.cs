﻿using System;
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
        private HttpParser parser;

        public IAssetPointer AssetPointer { get; set; }

        public HttpDownloader()
        {
            parser = new HttpParser();
        }

        /// <summary>
        /// manually add the first task to the queue
        /// </summary>
        /// <param name="startLocation"></param>
        public void SeedWorkQueue(IAssetPointer startLocation)
        {
            Task hypertextTask = GetText(startLocation.Uri);
            WorkQueues.DownloadTaskQueue.Enqueue(hypertextTask);
        }

        /// <summary>
        /// An async task that returns a hypertext string from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task GetText(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            _log.Info("Completed hypertext download");

            //we have the response, put a parse task on the work queue
            Task parseTask = parser.Parse(result);

            WorkQueues.ParseTaskQueue.Enqueue(parseTask);

            //place marker in completed tracker.
        }

        /// <summary>
        /// An async task that retrurns a bytem array from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task GetBinary(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            byte[] binary = await response.Content.ReadAsByteArrayAsync();
        }

        ///// <summary>
        ///// from the TAP docs
        ///// </summary>
        ///// <param name="url"></param>
        ///// <param name="cancellationToken"></param>
        ///// <param name="progress"></param>
        ///// <returns></returns>
        //public static async Task<byte[]> DownloadDataAsync(
        //    string url,
        //    CancellationToken cancellationToken,
        //    IProgress<long> progress)
        //{
        //    using (var request = WebRequest.Create(url))
        //    using (var response = await request.GetResponseAsync())
        //    using (var responseStream = response.GetResponseStream())
        //    using (var result = new MemoryStream())
        //    {
        //        await responseStream.CopyToAsync(
        //            result, cancellationToken, progress);
        //        return result.ToArray();
        //    }
        //}

    }
}
