using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02._2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, int> products = new SortedList<string, int>(new MyCompare());
            products.Add("Potato", 20);
            products.Add("Zuz", 10);
            products.Add("Apples", 40);
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} : {item.Value}kg");
            }
            Console.ReadLine();
        }
    }

    class MyCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }
}
