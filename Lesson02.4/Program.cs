using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02._4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            OrderedDictionary coll = new OrderedDictionary(new AccountCompare());
            Account a1 = new Account() { Number = 1, Balance = 10000 };
            Account a2 = new Account() { Number = 3, Balance = 20000 };
            Account a3 = new Account() { Number = 2, Balance = 30000 };
            Account a4 = new Account() { Number = 3, Balance = 40000 };

            coll.Add(a1, "Company 1");
            coll.Add(a2, "Company 2");
            coll.Add(a3, "Company 3");

            try
            {
                coll.Add(a4, "Company 4"); //  Приводит к исключению, т.к. уже есть такой ключ.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Такой ключ уже существует");
                Console.WriteLine(ex.Message);
            }

            foreach (DictionaryEntry item in coll)
            {
                Console.WriteLine(item.Value);
            }

            Console.ReadKey();
        }
    }

    class Account
    {
        public int Balance { get; set; }

        public int Number { get; set; }
    }

    class AccountCompare : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            Account ac1 = x as Account;
            Account ac2 = y as Account;
            return ac1.Number == ac2.Number;
        }

        public int GetHashCode(object obj)
        {
            return (obj as Account).Number.GetHashCode();
        }
    }
}
