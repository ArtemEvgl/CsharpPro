using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._2
{
    class Month_Collection : IEnumerable, IEnumerator
    {
        Month[] months = { new Month("Январь", 1, 31), new Month("Февраль", 2, 28), new Month("Март", 3, 31),
                            new Month("Аперль", 4, 30), new Month("Май", 5, 31), new Month("Июнь", 6, 30),
                            new Month("Июль", 7, 31), new Month("Август", 8, 31), new Month("Сентябрь", 9, 30),
                            new Month("Октябрь", 10, 31), new Month("Ноябрь", 11, 30), new Month("Декабрь", 12, 31),};

        public Month this[int index]
        {
            get
            {
                if (index >= 1 && index <= 12)
                {
                    return months[index - 1];
                } else
                {
                    throw new ArgumentException("Ошибка ввода номера месяца");
                }
            }
        }

        int position = -1;
        public object Current => months[position];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public List<Month> GetMonthsByDays(int days)
        {
            List<Month> result = new List<Month>();
            foreach (var item in months)
            {
                if (item.Days == days)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public bool MoveNext()
        {
            if (position < months.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
