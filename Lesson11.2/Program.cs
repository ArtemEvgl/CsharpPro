using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson11._2
{
    class Program
    {
        static object block = new object();
        static StreamWriter sw = new StreamWriter(new FileStream("result.txt", FileMode.OpenOrCreate, FileAccess.Write));
        
        static void Read(object fileName)
        {

            string text;
            using (StreamReader sr = new StreamReader(new FileStream((string)fileName, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                text = sr.ReadToEnd();
            }
            lock (block)
            {
                Write(text);
            }
        }

        static void Write(string text)
        {
            Console.Write("Началась запись в файл потока {0}", Thread.CurrentThread.ManagedThreadId);
            sw.Write(text);
            Console.WriteLine("Закончилась запись в файл потока {0}", Thread.CurrentThread.ManagedThreadId);
        }
        
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Read);
            Thread thread2 = new Thread(Read);
            thread1.Start("text1.txt");
            thread2.Start("text2.txt");
            thread1.Join();
            thread2.Join();
            sw.Close();
            Console.WriteLine("The end");
        }
    }
}
