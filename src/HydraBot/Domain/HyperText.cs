using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// A pointer to a web based resource a url/uri
    /// </summary>
    public class HyperTextPointer : IAssetPointer 
    {
        public string Uri { get; set; }

        public HyperTextPointer(string uri)
        {
            Uri = uri;
        }
    }
}
