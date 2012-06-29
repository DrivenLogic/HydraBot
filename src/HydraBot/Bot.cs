using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.DataStructures;
using HydraBot.Domain;
using NLog;

namespace HydraBot
{
    /// <summary>
    /// Processes Tasks
    /// </summary>
    public class Bot
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        private readonly int _conncurrencyLimit = 3;
        private readonly HttpDownloader _downloader;
        private readonly HttpParser _parser;

        /// <summary>
        /// ctor        
        /// </summary>
        public Bot()
        {
            // DI would be nice...
            _parser = new HttpParser();
            _downloader = new HttpDownloader();
        }

        /// <summary>
        /// manually add the first task to the queue
        /// </summary>
        /// <param name="startLocation"></param>
        public void StartLocation(string startLocation)
        {
            _downloader.SeedWorkQueue(new HyperTextPointer(startLocation));
        }

        /// <summary>
        /// Run our async tasks
        /// </summary>
        public void ProcessTasks()
        {
            while (ThereIsWorkToBeDone())
            {
                //downloading
                IEnumerable<Task> downloadTasks;

                downloadTasks = WorkQueues.DownloadTaskQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.DownloadTaskQueue, _conncurrencyLimit));
                
                //mark progress tracker 

                // wait for all the async downloads to complete
                Task downloadResult = Task.WhenAll(downloadTasks);

                // parsing
                IEnumerable<Task> parseTasks;

                parseTasks = WorkQueues.ParseTaskQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.ParseTaskQueue, _conncurrencyLimit));
                
                //mark progress tracker

                // wait for all the async parsing tasks to complete
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

        /// <summary>
        /// this check should be cut up be queue type
        /// </summary>
        /// <returns></returns>
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
