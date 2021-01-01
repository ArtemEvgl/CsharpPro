using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14._2
{
    class Program
    {
        static void Method1()
        {
            Console.WriteLine("Method 1 is started");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Counter method's 1 = {i}");
            }
            Console.WriteLine("Method 1 is finished");
        }

        static void Method2()
        {
            Console.WriteLine("Method 2 is started");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Counter method's 2 = {i}");
            }
            Console.WriteLine("Method 2 is finished");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread is started");
            Task.Factory.StartNew(() => Parallel.Invoke(Method1, Method2));
            Console.WriteLine("Main thread is finished");
            Console.ReadKey();
        }
    }
}
