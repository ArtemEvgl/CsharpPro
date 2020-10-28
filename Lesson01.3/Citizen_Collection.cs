using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01._3
{
    class Citizen_Collection : IEnumerable
    {
        Citizen[] citizens;
        int count;

        public Citizen_Collection(int size)
        {
            citizens = new Citizen[size];
            count = 0;
        }

        public Citizen_Collection() : this(4)
        {
        }

        private bool IsFull()
        {
            return count == citizens.Length;
        }

        private void Resize()
        {
            int capacity = count == 0 ? 4 : citizens.Length * 2;
            Citizen[] newCitizens = new Citizen[capacity];
            citizens.CopyTo(newCitizens, 0);
            citizens = newCitizens;
        }

        public int Add(Citizen citizen)
        {
            if (CheckDoublePassport(citizen))            
                return 0;
            
            if (IsFull())            
                Resize();

            if (citizen is Pensioner)
            {
                int index = 0;
                for (int i = citizens.Length - 1; i >= 0; i--)
                {
                    if (citizens[i] is Pensioner)
                    {
                        index = i + 1;
                        break;
                    }
                }
                Insert(citizen, index);
            }
            else
            {
                citizens[count++] = citizen;
            }    
            return count;
            
        }

        private void Insert(Citizen citizen, int index)
        {
            int shiftStart = index + 1;
            if (IsFull())
                Resize();
            Array.Copy(citizens, index, citizens, shiftStart, count - index);
            citizens[index] = citizen;
            count++;
        }

        private bool CheckDoublePassport(Citizen citizen)
        {
            bool result = false;
            foreach (var item in citizens)
            {
                if (item != null && item.Equals(citizen))
                {
                    Console.WriteLine("Гражданин с данным паспортом уже существует");
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void Remove()
        {
            RemoveAt(1);
        }
        public void RemoveAt(int index)
        {
            if (index > 0 && index <= count)
            {
                if (index < count)
                {
                    Array.Copy(citizens, index, citizens, index - 1, count - index);
                }
                citizens[count - 1] = default(Citizen);
                count--;
            } else
            {
                throw new ArgumentException("Ошибка ввода индекса");
            }
        }

        public bool Remove(Citizen citizen)
        {
            for (int i = 0; i < count; i++)
            {
                if (citizen == citizens[i])
                {
                    RemoveAt(i + 1);
                    return true;
                }
            }
            return false;
        }

        public bool Contains(Citizen citizen)
        {
            for (int i = 0; i < count; i++)
            {
                if (citizen == citizens[i])
                {                   
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            citizens = new Citizen[4];
            count = 0;
        }

        public Citizen ReturnLast()
        {
            return citizens[count - 1];
        }
        
        public IEnumerator GetEnumerator()
        {
            return citizens.GetEnumerator();
        }
    }
}
