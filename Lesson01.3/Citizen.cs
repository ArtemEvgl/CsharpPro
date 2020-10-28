using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Citizen
    {
        public Citizen(string name)
        {
            Name = name;
            Random random = new Random(DateTime.Now.Millisecond + name.Length);
            Passport = random.Next(100000, 999999);
        }
        public string Name { get; set; }
        public int Passport { get;}

        public override bool Equals(object obj)
        {
            Citizen citizen = obj as Citizen;
            if (citizen != null)
            {
                return citizen.Passport == this.Passport;
            } else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Passport}"; 
        }
    }
}
