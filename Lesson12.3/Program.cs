using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson12._3
{
    class Program
    {
        private static readonly Mutex mutex = new Mutex(false, "Mutex: myMutex");
        static void Main(string[] args)
        {
            mutex.WaitOne();
            Console.WriteLine("Поток {0} зашел в защищенную область.", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0}  покинул защищенную область.\n", Thread.CurrentThread.Name);
            Console.ReadLine();
            mutex.ReleaseMutex();
        }
    }
}
