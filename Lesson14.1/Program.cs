using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[1000000];
            Parallel.For(0, numbers.Length, i => numbers[i] = random.Next());
            var unevenNumbers = numbers.AsParallel().Where(i => i % 2 != 0);
            unevenNumbers.ForAll(i => Console.WriteLine(i));
        }
    }
}
