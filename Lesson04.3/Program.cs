using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson04._3
{
    class Program
    {
        static void Main(string[] args)
        {

            string sentence = File.ReadAllText("text.txt", Encoding.Default);

            string pattern = @"\s[а-я]{1,3}\s";
            string newSentence = Regex.Replace(sentence, pattern, " ГАВ! ");

            Console.WriteLine(newSentence);

            File.WriteAllText("text_New.txt", newSentence, Encoding.Default);
            Console.ReadKey();
        }
    }
}
