using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson04._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            while (true)
            {
                Console.WriteLine("Enter the login");
                string login = Console.ReadLine();
                if (!CheckLogin(login))
                {
                    Console.WriteLine("Login is bad =( Try again");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.WriteLine("Enter the pass");
                string login = Console.ReadLine();
                if (!CheckPassword(login))
                {
                    Console.WriteLine("Pass is bad =( Try again");
                    continue;
                }
                break;
            }
            Console.WriteLine("Excellent!");
            Console.ReadKey();
        }

        public static bool CheckLogin(string login)
        {
            string pattern = @"^[a-zA-Z]+$";
            Regex regex = new Regex(pattern);
            bool result = false;
            if (regex.IsMatch(login))
            {
                result = true; 
            }
            return result;
        }

        public static bool CheckPassword(string pass)
        {
            string pattern = @"^[a-zA-Z0-9]+$";
            Regex regex = new Regex(pattern);
            bool result = false;
            if (regex.IsMatch(pass))
            {
                result = true;
            }
            return result;
        }
    }
}
