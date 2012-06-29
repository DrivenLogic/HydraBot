using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.Domain;

namespace HydraBot.DataStructures
{
    /// <summary>
    /// Oh the staticness!!
    /// </summary>
    public static class WorkQueues
    {
        public static ConcurrentQueue<Task> DownloadTaskQueue { get; set; }
        public static ConcurrentQueue<Task> ParseTaskQueue { get; set; }

        /// <summary>
        /// setup our thread safe collections. 
        /// </summary>
        static WorkQueues()
        {
            DownloadTaskQueue = new ConcurrentQueue<Task>();
            ParseTaskQueue = new ConcurrentQueue<Task>();
        }
    }
}
