using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskAsyncDemo
{
    public class Parse
    {

        public Task<MatchCollection> MatchBinaries(string hypertext)
        {
            MatchCollection matchCollection = Regexs.BinaryRegex().Matches(hypertext);

            return matchCollection;

        }

    }
}
