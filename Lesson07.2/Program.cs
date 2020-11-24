using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson07._2
{
    [Obsolete("Устаревший")]
    class MyClass
    {

        [Obsolete("Устаревший")]
        public void SomeMethod1()
        {

        }
        [Obsolete("Устаревший", true)]
        public void SomeMethod2()
        {

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.SomeMethod1();
            //myClass.SomeMethod2(); error
        }
    }
}
