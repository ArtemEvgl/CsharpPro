using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> func = CountSymbols;
            func.BeginInvoke("test", Callback, null);
            Console.ReadKey();
        }

        private static void Callback(IAsyncResult ar)
        {
            AsyncResult asyncResult = (AsyncResult)ar;
            Func<string, int> func = (Func<string, int>)asyncResult.AsyncDelegate;
            int result = func.EndInvoke(ar);
            Console.WriteLine(result);
        }

        public static int CountSymbols(string word)
        {
            return word.Length;
        }


    }
}
