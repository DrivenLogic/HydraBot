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
        private HttpDownloader _httpDownloader = new HttpDownloader();

        public HttpParser()
        {
         
        }

        public async Task<IEnumerable<string>> Parse(string hyperText)
        {
            await Task.Run(() =>
                               {
                                   Regex linkMatcher = RegexLib.HyperLinkRegex();
                                   MatchCollection matchCollection = linkMatcher.Matches(hyperText);

                                   return matchCollection.Cast<String>();
                               });
        }
    }
}
