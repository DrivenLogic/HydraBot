using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace HydraBot.Domain.impl
{
    /// <summary>
    /// must return tasks back to the bot controller
    /// </summary>
    public class HttpDownloader : IDownload
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public IAssetPointer AssetPointer { get; set; }

        public HttpDownloader()
        {
            
        }

        /// <summary>
        /// An async task that returns a hypertext string from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> GetText(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            _log.Info("Completed hypertext download");

            return result;
        }

        /// <summary>
        /// An async task that retrurns a bytem array from a uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<byte[]> GetBinary(string uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
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
