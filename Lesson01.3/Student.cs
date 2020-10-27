using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Student : Citizen
    {

        private int scholarship;
        public Student(string name, int scholarship) : base(name)
        {
            Scholarship = scholarship;
        }
        
        public int Scholarship
        {
            get { return scholarship; }
            set
            {
                if (value > 0)
                {
                    scholarship = value;
                }
                else
                {
                    throw new ArgumentException("Стипендия не может быть отрицательной");
                }
            }
        }

    }
}
