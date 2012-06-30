using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            try
            {
                Console.WriteLine(FullOfFail().Result);
            }
            catch (Exception ex)
            {

            }

            Console.WriteLine("main thread done...");
            Console.WriteLine("");
            Console.ReadLine();
        }

        private async static void DoWork()
        {
            string foo = "bar";

            await Task.Run(() =>
                               {
                                   Thread.Sleep(4000);
                                   Console.WriteLine("hello im a task!");
                                   Console.WriteLine("");
                               }).ContinueWith(MrContinuation);

            Console.WriteLine("implicit continuation");
            Console.WriteLine("Its better in the background: {0}", Thread.CurrentThread.IsBackground);
            Console.WriteLine("");
        }

        /// <summary>
        /// a continuation for our task. 
        /// </summary>
        /// <param name="task"></param>
        private static void MrContinuation(Task task)
        {
            Console.WriteLine("hello im an explicit continuation");
            Console.WriteLine("Did the task complete sucessfully? the task status? : {0}", task.Status);
            Console.WriteLine("Im a Continuation, i will be on a worker thread my id is: {0} ", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("I have been to the pool: {0}", Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Its better in the background: {0}", Thread.CurrentThread.IsBackground);
            Console.WriteLine("");
        }

        private static async Task<int> FullOfFail()
        {
            return await Task.Run(()=> BadStuff());
        }

        private static int BadStuff()
        {
            int one = 1;
            int zero = 0;
            return one/zero;
        }
    }
}
