using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> dic1 = new Dictionary<int, double>();
            SortedDictionary<int, double> dic2 = new SortedDictionary<int, double>();
            dic1.Add(11122233, 1000.5);
            dic1.Add(11120033, 10800.5);
            dic1.Add(19119931, 10800.41);
            dic2.Add(11122233, 1000.5);
            dic2.Add(11120033, 10800.5);
            dic2.Add(19119931, 10800.41);
            
        }
    }
}
