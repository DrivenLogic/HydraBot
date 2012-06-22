using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputePi
{
    class Program
    {
        const int num_steps = 1000000000;

        static void Main(string[] args)
        {
            Console.WriteLine(SerialPi());

            BadSpinWait();

            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// Compute Pi
        /// </summary>
        /// <returns></returns>
        static double SerialPi()
        {
            double sum = 0.0;
            double step = 1.0 / (double)num_steps;
            for (int i = 0; i < num_steps; i++)
            {
                double x = (i + 0.5) * step;
                sum = sum + 4.0 / (1.0 + x * x);
            }
            return step * sum;
        }

        static void BadSpinWait()
        {
            while (true)
            { 
                //bad code
            }
        }
    }
}
