using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson04._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var my = CultureInfo.CurrentCulture;
            var us = new CultureInfo("en-US");

            string sentence = File.ReadAllText("product.txt", Encoding.Default);

            Console.WriteLine(sentence);

            Console.WriteLine(new string('-', 25));

            string pattern = @"[0-9]+[\.\,][0-9]+";

            string sentenceMy = Regex.Replace(sentence, pattern, (m) => double.Parse(m.Value.Replace(".",",")).ToString("C", my));
            string sentenceUs = Regex.Replace(sentence, pattern, (m) => double.Parse(m.Value.Replace(".", ",")).ToString("C", us));

            Console.WriteLine(sentenceMy);
            Console.WriteLine(new string('-', 25));
            Console.WriteLine(sentenceUs);
            Console.ReadLine();
        }
    }
}
