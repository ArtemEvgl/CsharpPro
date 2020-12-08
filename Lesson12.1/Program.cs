using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson12._1
{
    class Program
    {
        static Semaphore pool;
        const string filename = "log.txt";


        static void Method(object number)
        {
            
            pool.WaitOne();
            Console.WriteLine(number + " start");
            File.AppendAllText(filename, $"{DateTime.Now.ToString("HH-mm:ss")} Поток {number} запустился\n");
            Thread.Sleep(2000);
            File.AppendAllText(filename, $"{DateTime.Now.ToString("HH-mm:ss")} Поток {number} остановился\n");
            Console.WriteLine(number + " finish");
            pool.Release();

        }
        static void Main(string[] args)
        {
            pool = new Semaphore(1, 4, "MySemaphore");

            for (int i = 0; i < 10; i++)
            {
                new Thread(Method).Start(i);
            }
            
            Console.ReadKey();
        }
    }
}
