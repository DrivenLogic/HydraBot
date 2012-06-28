using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HydraBot.Domain;

namespace HydraBot.Core.DataStructures
{
    public class CompletedTracker
    {
        public HashSet<IAssetPointer> Type { get; set; }
    }
}
