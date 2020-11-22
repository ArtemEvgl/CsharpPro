using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lesson05._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);
            
            xmlWriter.Formatting = Formatting.Indented;

            // Для выделения уровня элемента использовать табуляцию.
            xmlWriter.IndentChar = '\t';

            // использовать один символ табуляции.
            xmlWriter.Indentation = 1;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteAttributeString("TelephoneNumber", "351765");
            xmlWriter.WriteString("Artem");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.Close();

        }
    }
}
