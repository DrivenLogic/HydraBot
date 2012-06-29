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
    /// HashSet is fast but not tread safe
    /// </summary>
    public class CompletedTracker
    {
        private HashSet<IAssetPointer> _completedTracker;
        public CompletedTracker()
        {
            _completedTracker = new HashSet<IAssetPointer>();
        }

        // read 

        // write

        // update
    }
}
