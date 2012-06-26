using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in StateMachineExample())
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }

        static IEnumerable<int> StateMachineExample()
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    yield  return i;
            //}

            return new EnumerableQuery<int>(new int[] {0, 1, 2, 3});
        }
    }
}
