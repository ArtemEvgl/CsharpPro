using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPro
{
    class Program
    {
        
        static IEnumerable GetSquareNumbers(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 == 1)
                {
                    yield return Math.Pow(number, 2);
                }
            }
            yield break;
        }
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
            foreach(var number in GetSquareNumbers(numbers))
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
    }
}
