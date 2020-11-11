using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03._2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"d:\test.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Hello");
            sw.Close();
            fs.Close();
            StreamReader sr = File.OpenText(@"d:\test.txt");
            string result = sr.ReadToEnd();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
