using System;
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
    public class WorkStatusTracker
    {
        private HashSet<IAssetPointer> _statusTracker;

        public WorkStatusTracker()
        {
            _statusTracker = new HashSet<IAssetPointer>();
        }

        // read 

        // write

        // update
    }
}
