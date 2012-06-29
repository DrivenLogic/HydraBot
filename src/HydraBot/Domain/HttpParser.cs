using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain.impl
{
    /// <summary>
    /// Must return tasks back to the bot controller
    /// </summary>
    public class HttpParser : IParse
    {
        public IAssetPointer AssetPointer { get; set; }

        public Task<> Parse(string input)
        {
            // tease out out all types of links 
           // pull out all the assets (links and binaries) 

        }
    }
}
