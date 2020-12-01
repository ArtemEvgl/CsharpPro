using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09._1
{

    class LargeObject : IDisposable
    {
        private bool disposable = false;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposable)
            {
                if (disposing)
                {
                    Console.WriteLine("CleanObject");
                    disposable = true;
                }
                Console.WriteLine("Finalize");
            }
        }

        ~LargeObject()
        {
            Dispose(false);
            Console.WriteLine("Finals");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (LargeObject largeObject = new LargeObject())
            {
                Console.WriteLine("Work");
            }


        }
    }
}
