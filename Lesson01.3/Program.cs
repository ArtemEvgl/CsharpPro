using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Citizen_Collection collection = new Citizen_Collection();
            Pensioner p = new Pensioner("Aleheev", 200);
            collection.Add(new Student("Sa", 200));
            collection.Add(new Pensioner("Petr", 200));
            collection.Add(p);
            collection.Add(new Student("Sahsgaasfaaffa", 200));
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            collection.RemoveAt(3);
            collection.Remove(p);
            Citizen citizen = collection.ReturnLast();
            collection.Clear();
            Console.ReadKey();
        }
    }
}
