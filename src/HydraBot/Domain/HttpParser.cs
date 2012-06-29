using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HydraBot.DataStructures;
using HydraBot.Tools;
using NLog;

namespace HydraBot.Domain
{
    /// <summary>
    /// Must return tasks back to the bot controller
    /// </summary>
    public class HttpParser : IParse
    {
        private Logger _log = LogManager.GetCurrentClassLogger();

        private HttpDownloader _httpDownloader;

        public HttpParser()
        {
            _httpDownloader = new HttpDownloader();
        }

        public async Task Parse(string hyperText)
        {
            await Task.Run(() =>
                               {
                                   Regex linkMatcher = RegexLib.HyperLinkRegex();
                                   MatchCollection matchCollection = linkMatcher.Matches(hyperText);

                                   matchCollection.Cast<Match>()
                                       .ToList()
                                       .ForEach
                                       (m =>
                                            {
                                                WorkQueues.DownloadTaskQueue.Enqueue(_httpDownloader.GetText(m.Value));
                                                _log.Trace("Found link: {0}", m.Value);
                                            });
                               });
        }
    }
}
