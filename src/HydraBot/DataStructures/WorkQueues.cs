using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HydraBot.Domain;

namespace HydraBot.DataStructures
{
    /// <summary>
    /// Oh the staticness!!
    /// </summary>
    public static class WorkQueues
    {
        /// <summary>
        /// Contains download tasks tasks containing pointers to resources for download.
        /// Text downloads are offloaded as further work to the Parse Task queue
        /// Binaries are downloaded to the filesystem.
        /// </summary>
        public static ConcurrentQueue<Task<string>> DownloadHyperTextQueue { get; set; }

        /// <summary>
        /// Contains download tasks tasks containing pointers to resources for download.
        /// Text downloads are offloaded as further work to the Parse Task queue
        /// Binaries are downloaded to the filesystem.
        /// </summary>
        public static ConcurrentQueue<Task<Byte[]>> DownloadBinariesQueue { get; set; }

        /// <summary>
        /// Contains parsing tasks (tasks containing text for processing
        /// into download tasks. 
        /// </summary>
        public static ConcurrentQueue<Task<IEnumerable<Match>>> ParseTaskQueue { get; set; }

        /// <summary>
        /// setup our thread safe collections. 
        /// </summary>
        static WorkQueues()
        {
            // embrace that thread safety! 
            DownloadHyperTextQueue = new ConcurrentQueue<Task<string>>();
            DownloadBinariesQueue = new ConcurrentQueue<Task<byte[]>>();
            ParseTaskQueue = new ConcurrentQueue<Task<IEnumerable<Match>>>();
        }
    }
}
