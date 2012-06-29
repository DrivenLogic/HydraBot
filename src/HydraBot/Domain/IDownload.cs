using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.Domain
{
    /// <summary>
    /// Retruns downloading tasks.
    /// </summary>
    public interface IDownload
    {
        Task GetText(string uri);
        Task GetBinary(string uri);
    }
}
