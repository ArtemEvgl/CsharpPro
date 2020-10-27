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
            collection.Add(new Student("Sa", 200));
            collection.Add(new Pensioner("Petr", 200));
            collection.Add(new Pensioner("Aleheev", 200));
            collection.Add(new Student("Sah", 200));
            Console.ReadKey();
        }
    }
}
