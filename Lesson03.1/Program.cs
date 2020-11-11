using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03._1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory($@"d:\folder_{i}");
            }
            Console.ReadKey();
            for (int i = 0; i < 100; i++)
            {
                Directory.Delete($@"d:\folder_{i}");
            }
        }
    }
}
