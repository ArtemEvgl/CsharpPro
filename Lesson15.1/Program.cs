using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson15._1
{
    class Program
    {
        
        
        public static int Operation(object state)
        {
            int result = (int)state;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(++result);
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            return result; 
        }
        
        public static async Task OperationAsync(int number)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            number = await Task<int>.Factory.StartNew(Operation, number);
            number = await Task.Factory.StartNew(Operation, number);
            await Task.Factory.StartNew(Operation, number);
            Console.WriteLine($"The end {Thread.CurrentThread.ManagedThreadId}");
        }
        
        static void Main(string[] args)
        {
            Task task = OperationAsync(0);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }


    }
}
