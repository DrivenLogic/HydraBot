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

            Console.WriteLine("main done ;)");
            Console.ReadLine();
        }

        private async static void DoWork()
        {
            await Task.Run(() =>
                               {
                                   Thread.Sleep(5000);
                                   Console.WriteLine("hello im a task!");                                
                               });
        }
    }
}
