using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lesson05._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlReader = new XmlTextReader("TelephoneBook.xml");

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if(xmlReader.HasAttributes)
                    {
                        xmlReader.MoveToNextAttribute();
                        Console.Write($"{xmlReader.Value} - ");
                    }
                }
                if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine($"{xmlReader.Value}");
                }
            }

            Console.ReadKey();
        }
    }
}
