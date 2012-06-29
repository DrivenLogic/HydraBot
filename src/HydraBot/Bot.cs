using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.DataStructures;
using HydraBot.Domain;

namespace HydraBot
{
    /// <summary>
    /// Processes Tasks
    /// </summary>
    public class Bot
    {
        private readonly int _conncurrencyLimit = 3;
        private readonly HttpDownloader _downloader;
        private readonly IParse _parser;

        /// <summary>
        /// ctor        
        /// </summary>
        public Bot()
        {
            _downloader = new HttpDownloader();
            _parser = new HttpParser();
        }

        /// <summary>
        /// manually add the first task to the queue
        /// </summary>
        /// <param name="startLocation"></param>
        public void SeedWorkQueue(IAssetPointer startLocation)
        {
            Task hypertextTask  = _downloader.GetHyperText(startLocation.Uri);
            WorkQueues.DownloadTaskQueue.Enqueue(hypertextTask);
        }

        /// <summary>
        /// Run our async tasks
        /// </summary>
        public void ProcessTasks()
        {
            while (ThereIsWorkToBeDone())
            {
                //downloading
                IEnumerable<Task<string>> downloadTasks;

                downloadTasks = WorkQueues.DownloadTaskQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.DownloadTaskQueue, _conncurrencyLimit));

                // wait for all the async downloads to complete
                Task.WhenAll(downloadTasks);


                // parsing
                IEnumerable<Task<IParse>> parseTasks;

                parseTasks = WorkQueues.ParseTaskQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.ParseTaskQueue, _conncurrencyLimit));

                // wait for all the saunc parsing tasks to complete
                Task.WhenAll(parseTasks);
            }
        }




        // read some config maybe?

        // traverse the work queue 
        // pull out and action async tasks. 
        // do this based on throttling

        // tasks that return tasks should add to the work queue. 

        // report status

        // report progress

        // handle errors 

        private bool ThereIsWorkToBeDone()
        {
            return ((WorkQueues.ParseTaskQueue.Count > 0) || (WorkQueues.DownloadTaskQueue.Count > 0));
        }

        /// <summary>
        /// When the work queue is smaller than the cocurrency limit take what you can get.
        /// </summary>
        private int ChunkingSize<T>(ConcurrentQueue<T> queue, int concurrencyLimit)
        {
            if (queue.Count < concurrencyLimit)
            {
                if (queue.Count == 0)
                    return 0;

                if (queue.Count > 0)
                    return queue.Count;
            }
                // otherwise stick to our throttle
                return concurrencyLimit;
        }
    }
}
