using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson08._2
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
            FileStream fs1 = new FileStream("car.xml", FileMode.Create);
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(Car));
            xmlSerializer1.Serialize(fs1, new Car() { Name = "Vesta", Speed = 20 });
            fs1.Close();

            FileStream fs2 = new FileStream("carXml.xml", FileMode.Create);
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(XMLCar));
            xmlSerializer2.Serialize(fs2, new XMLCar() { Name = "Kia", Speed = 30 });
            fs1.Close();
        }
    }
}
