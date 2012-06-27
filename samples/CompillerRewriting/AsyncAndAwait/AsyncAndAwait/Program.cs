using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();

            Console.WriteLine("main waiting...");
            Console.ReadLine();
            Console.WriteLine("main done.");
        }

        private async static void DoWork()
        {
            await Task.Run(() =>
                               {
                                   Thread.Sleep(5000);
                                   Console.WriteLine("hello im a task!");
                               }).ContinueWith(MrContinuation);       

            Console.WriteLine("implicit continuation");
        }

        /// <summary>
        /// a continuation for our task. 
        /// </summary>
        /// <param name="task"></param>
        private static void MrContinuation(Task task)
        {
            Console.WriteLine("Did the task complete sucessfully? the task status? : {0}", task.Status);
            Console.WriteLine("Im a Continuation, i will be on a worker thread my id is: {0} ", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("I have been to the pool: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Its better in the background: {0}", Thread.CurrentThread.IsBackground);
        }
    }
}
