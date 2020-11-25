using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson08._3
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
    }

    public class XMLCar
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Speed { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Car));
            FileStream fileStream = new FileStream("car.xml", FileMode.Open);
            Car auto1 = xmlSerializer.Deserialize(fileStream) as Car;
            Console.WriteLine(auto1.Name + auto1.Speed);
            fileStream.Close();

            xmlSerializer = new XmlSerializer(typeof(XMLCar));
            fileStream = new FileStream("carXml.xml", FileMode.Open);
            XMLCar auto2 = xmlSerializer.Deserialize(fileStream) as XMLCar;
            Console.WriteLine(auto2.Name + auto2.Speed);
            fileStream.Close();

            Console.ReadKey();
        }
    }
}
