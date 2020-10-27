using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Pensioner : Citizen
    {
        public Pensioner(string name, int pensia) : base(name)
        {
            Pensia = pensia;
        }
        private int pensia;

        public int Pensia
        {
            get { return pensia; }
            set {
                if (value > 0)
                {
                    pensia = value;
                }
                else
                {
                    throw new ArgumentException("Пенсия не может быть отрицательной");
                }
            }
        }

    }
}
