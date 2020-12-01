using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson09._2
{

    class MyClass
    {
        private readonly int limitMemory;

        public MyClass(int limit)
        {
            limitMemory = limit;
        }
        
        public void MemoryExceeded(object state)
        {
            if (GC.GetTotalMemory(false) > limitMemory)
            {
                Console.WriteLine(state);
            }
        }


    }


    class LargeObject
    {
        private int[] array = new int[100000000];

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(new MyClass(100000000).MemoryExceeded, "Error memory", 0, 200);
            LargeObject[] largeObject = new LargeObject[1000];
            for (int i = 0; i < 1000; i++)
            {
                new LargeObject().Method(i);
            }
        }
    }
}
