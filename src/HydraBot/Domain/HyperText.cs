using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// Represents a text download location
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
