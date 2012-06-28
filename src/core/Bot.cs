using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.DataStructures;
using HydraBot.Domain;
using HydraBot.Domain.impl;

namespace HydraBot
{
    /// <summary>
    /// Processes Tasks
    /// </summary>
    public class Bot
    {
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
            Task<String> hypertextTask  = _downloader.GetText(startLocation.Uri);

            WorkQueues.DownloadTaskQueue.Enqueue(hypertextTask);
            

        }

        // read some config maybe?

        // traverse the work queue 
        // pull out and action async tasks. 
        // do this based on throttling

        // tasks that return tasks should add to the work queue. 

        // report status

        // report progress

        // handle errors 
    }
}
