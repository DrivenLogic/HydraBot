using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace TaskAsyncDemo
{
    public class Parse
    {
        List<Uri> _binaryUris = new List<Uri>();

        public async Task<List<Uri>> MatchBinaries(string hypertext)
        {
            MatchCollection matchCollection = null;

            await Task.Run(() =>
                               {
                                   matchCollection = Regexs.BinaryRegex().Matches(hypertext);
                                   foreach (Match match in matchCollection)
                                   {
                                       _binaryUris.Add(new Uri(match.ToString()));
                                   }
                               });

            return _binaryUris;
        }
    }
}
