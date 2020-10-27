using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Month_Collection collection = new Month_Collection();
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('=', 20));
            Console.WriteLine(collection[1]);
            Console.WriteLine(new string('=', 20));
            foreach (var item in collection.GetMonthsByDays(30))
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
