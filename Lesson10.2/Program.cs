using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10._2
{
    class BaseClass
    {
        public virtual void SomeMethods()
        {
            SomeMethod1();
            SomeMethod2();
        }

        public virtual void SomeMethod1()
        {
            Console.WriteLine("1");
        }

        public virtual void SomeMethod2()
        {
            Console.WriteLine("2");
        }
    }

    class DerivedClass : BaseClass
    {
        public new void SomeMethods()
        {
            SomeMethod1();
            SomeMethod2();
        }

        public new void SomeMethod1()
        {
            Console.WriteLine("3");
        }

        public override void SomeMethod2()
        {
            Console.WriteLine("4");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter number version: ");
            int.TryParse(Console.ReadLine(), out int result);
            switch(result)
            {
                case 1:
                    new BaseClass().SomeMethods();
                    break;
                case 2:
                    (new DerivedClass() as BaseClass).SomeMethods();
                    break;
                case 3:
                    new DerivedClass().SomeMethods();
                    break;
                default:
                    break;

            }
        }
    }
}
