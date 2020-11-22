using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lesson05._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load("TelephoneBook.xml");

            Console.WriteLine(xmlDocument.InnerText);

            Console.WriteLine(new string('-', 20));

            Console.WriteLine(xmlDocument.InnerXml);

            Console.ReadKey();
        }
    }
}
