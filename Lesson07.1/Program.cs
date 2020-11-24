using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07._1
{
    class Employee
    {

    }
    [AccessLevel(AccessLevelControl.LowControl)]
    class Manager : Employee
    {

    }

    [AccessLevel(AccessLevelControl.MediumControl)]
    class Proger : Employee
    {

    }

    [AccessLevel(AccessLevelControl.FullControl)]
    class Director : Employee
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = { new Manager(), new Proger(), new Director() };
            foreach (Employee item in employees)
            {
                ProtectedSection(item);
            }
            Console.ReadKey();
        }

        private static void ProtectedSection(Employee item)
        {
            Type type = item.GetType();
            object[] attrbts = type.GetCustomAttributes(typeof(AccessLevelAttribute), false);
            if (attrbts.Length == 0)
            {
                return;
            }
            foreach (AccessLevelAttribute attribute in attrbts)
            {
                Console.WriteLine($"{type.Name} {attribute.AccessLevel}");
            }
        }
    }
}
