using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// represents a resource or location, to be downloaded or parsed for further data.
    /// </summary>
    public interface IAssetPointer
    {
       string Uri { get; set; }
    }
}
