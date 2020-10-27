using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._2
{
    class Month
    {
        int days, number;
        public Month(string title, int number, int days)
        {
            Title = title;
            Number = number;
            Days = days;
        }

        public string Title { get; set; }
        public int Days { 
            get {
                return days;
            } 
            set {
                if (value >= 28 && value <= 31)
                {
                    days = value;
                } else
                {
                    throw new ArgumentException("Ошибка ввода количества дней в месяце");
                }
            } 
        }
        public int Number {
            get
            {
                return number;
            }
            set
            {
                if (value > 0 && value <= 12)
                {
                    number = value;
                }
                else
                {
                    throw new ArgumentException("Ошибка ввода номера месяца");
                }
            }
        }

        public override string ToString()
        {
            return $"{Number} {Title} days: {days}";
        }
    }
}
