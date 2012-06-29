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

        /// <summary>
        /// A parse task 
        /// pulls links out of a segment of hypertext
        /// </summary>
        /// <param name="hyperText"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Match>> Parse(string hyperText)
        {
            IEnumerable<Match> result = await Task.Run(() =>
                                                            {
                                                                Regex linkMatcher = RegexLib.HyperLinkRegex();
                                                                MatchCollection matchCollection = linkMatcher.Matches(hyperText);
                                                                return matchCollection.Cast<Match>();
                                                            });
            return result;
        }
    }
}
