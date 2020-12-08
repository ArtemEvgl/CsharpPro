using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson12._2
{
    class Work
    {
        readonly AutoResetEvent auto;
        readonly Thread thread;

        public Work(string name, AutoResetEvent auto)
        {
            this.thread = new Thread(this.Run) { Name = name };
            this.auto = auto;
            this.thread.Start();
        }

        void Run()
        {
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.WriteLine("\nThread " + thread.Name + " завершен");
            auto.Set();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var auto = new AutoResetEvent(false);

            var thread = new Work("1", auto);
            Console.WriteLine("Main thread waiting autoResetEvent...");

            auto.WaitOne();
            Console.WriteLine("Main thread has get autoResetEvent...");
            var thread2 = new Work("2", auto);
            Console.WriteLine("Main thread waiting autoResetEvent...");

            auto.WaitOne();
            Console.WriteLine("Main thread has get autoResetEvent...");

            Console.ReadLine();



        }
    }
}
