using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Worker : Citizen
    {
        int salary;
        public Worker(string name, int salary) : base(name)
        {
            Salary = salary;
        }

        public int Salary
        {
            get { 
                return salary; 
            }
            set
            {
                if (value > 0)
                {
                    salary = value;
                } else
                {
                    throw new ArgumentException("Зарплата не может быть отрицательной");
                }
            }
        }

        

    }
}
