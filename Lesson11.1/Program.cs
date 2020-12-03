using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson11._1
{
    class Program
    {
        static int counter = 0;
        static object block = new object();
        
        static void Method()
        {
            lock (block)
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine(counter);
                }
            }
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Method);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }


            Console.ReadKey();
        }
    }
}
