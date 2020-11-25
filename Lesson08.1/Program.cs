using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson08._1
{
    public class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream("Employee.xml", FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
            Employee employee = new Employee() { Name = "Alex", Surname = "sad", Age = 20 };
            xmlSerializer.Serialize(stream, employee);
            stream.Close();

            stream = new FileStream("Employee.xml", FileMode.Open, FileAccess.Read);
            Employee emp = xmlSerializer.Deserialize(stream) as Employee;
            stream.Close();
            Console.WriteLine(emp.Name + emp.Surname + emp.Age);
            Console.ReadKey();
        }
    }
}
