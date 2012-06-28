using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.Domain;

namespace HydraBot.Core.DataStructures
{
    public class WorkQueues
    {
        public ConcurrentQueue<Task<IDownload>> DownloadTaskQueue { get; set; }
        public ConcurrentQueue<Task<IParse>> ParseTaskQueue { get; set; }
    }
}
