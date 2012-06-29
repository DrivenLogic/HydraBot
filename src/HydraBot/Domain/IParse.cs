using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// Returns Parsing tasks
    /// </summary>
    public interface IParse
    {
        IAssetPointer AssetPointer { get; set; }
        Task Parse(string input);
    }
}
