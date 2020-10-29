using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02._1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Employee, List<Category>> dictionary = new Dictionary<Employee, List<Category>>();
            Employee employee1 = new Employee() { Name = "Artem"};
            List<Category> categories1 = new List<Category>();
            categories1.Add(Category.Auto);
            categories1.Add(Category.IT);
            dictionary.Add(employee1, categories1);
            foreach (var item in dictionary[new Employee() { Name = "Artem"}])
            {
                Console.WriteLine(item);
            }
            foreach (var item in GetEmployessByCategory(dictionary, Category.Auto))
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }

        
        static List<Employee> GetEmployessByCategory(Dictionary<Employee, List<Category>> dic, Category category)
        {
            List<Employee> result = new List<Employee>();
            foreach (var item in dic)
            {
                if (item.Value.Contains(category))
                {
                    result.Add(item.Key);
                }
            }
            return result;
        }

            

        enum Category
        {
            IT, Auto, Office, Orher
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name; 
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Employee emp = obj as Employee;
            if (emp != null)
            {
                return this.Name.Equals(emp.Name);
            }
            return false;
        }
    }
}
