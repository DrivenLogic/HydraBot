﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                //downloading of hypertext
                IEnumerable<Task> downloadTasks = WorkQueues.DownloadHyperTextQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.DownloadHyperTextQueue, _conncurrencyLimit)).ToList();

                //start each task and supply a continuation
                foreach (Task<string> task in downloadTasks)
                {
                    // save text
                    task.ContinueWith(t => UpdateParseTaskQueue(t));
                }

                // parsing
                IEnumerable<IEnumerable<Match>> parseTasks;

                parseTasks = WorkQueues.ParseTaskQueue.EnumerableDequeue().Take(ChunkingSize(
                        WorkQueues.ParseTaskQueue, _conncurrencyLimit)).ToList();

                foreach (Task<IEnumerable<Match>> task in parseTasks)
                {
                    // save download tasks 
                    task.ContinueWith(t => UpdateDownloadQueue(t));
                }

                //binary downloading



                //mark progress tracker

                // wait for all the async parsing tasks to complete
                //Task.WhenAll(parseTasks);
            }
        }



        private void UpdateDownloadHyperTextQueue(Task<string> task)
        {

        }

        private void SaveBinariesToDisk(Task<byte[]> task)
        {
        
        
        }

        private void UpdateParseTaskQueue(Task<IEnumerable<Match>> task)
        {
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
