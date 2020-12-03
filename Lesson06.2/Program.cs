using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using TempLib;

namespace Lesson06._2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Assembly assembly = Assembly.Load("TempLib");
            Type type = assembly.GetType("TempLib.Class1");
            MethodInfo methodInfo = type.GetMethod("ConvertToFareng");
            //Class1 c1 = Activator.CreateInstance(type) as Class1;
            //double result = Convert.ToDouble(methodInfo.Invoke(c1, new object[] { 20 }));
            Console.ReadKey();
        }
    }
}
