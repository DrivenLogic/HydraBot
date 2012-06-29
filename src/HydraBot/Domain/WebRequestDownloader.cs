using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// uses the older WebRequest objects. 
    /// </summary>
    public class WebRequestDownloader : IDownload
    {
        public Task<string> GetText(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetBinary(string uri)
        {
            throw new NotImplementedException();
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
