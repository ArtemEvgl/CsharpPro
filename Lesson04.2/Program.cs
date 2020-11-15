using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson04._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сайт для проверки");
            string url = Console.ReadLine();

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            StreamWriter writer = new StreamWriter("log.txt");
            Regex regex = new Regex(@"href=""(?<link>\S+)"">");

            foreach (Match item in regex.Matches(responseFromServer))
            {
                writer.WriteLine("ССЫЛКА: {0,-25}", item.Groups["link"]);
            }

            regex = new Regex(@"(?<phone>\+[7-9][(0-9)\s-]{3,}[0-9]{3}[\s\-][0-9]{2}[\s\-][0-9]{2})");

            foreach (Match item in regex.Matches(responseFromServer))
            {
                writer.WriteLine("Номер телефона: {0,-25}", item.Groups["phone"]);
            }

            regex = new Regex(@"(?<email>[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4})");

            foreach (Match item in regex.Matches(responseFromServer))
            {
                Console.WriteLine("E-mail: {0, -25}", item.Groups["email"]);
            }

            writer.Close();
            Console.ReadKey();
        }
    }
}
