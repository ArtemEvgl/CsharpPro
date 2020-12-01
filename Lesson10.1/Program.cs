using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10._1
{
    class TestFramework
    {
        public void Method()
        {
            BeforeWork();
            DoWork();
        }

        protected virtual void DoWork()
        {
            Console.WriteLine("1");
        }

        protected virtual void BeforeWork()
        {
            Console.WriteLine("2");
        }
    }

    class SecondDeveloperLib : TestFramework
    {
        protected override void DoWork()
        {
            Console.WriteLine("3");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
