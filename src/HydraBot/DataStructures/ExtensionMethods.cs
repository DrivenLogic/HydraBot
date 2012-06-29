using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydraBot.DataStructures
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> EnumerableDequeue<T>(this ConcurrentQueue<T> concurrentQueue)
        {
            T item;
            while (concurrentQueue.TryDequeue(out item))
            {
                yield return item;
            }
        }
    }
}
