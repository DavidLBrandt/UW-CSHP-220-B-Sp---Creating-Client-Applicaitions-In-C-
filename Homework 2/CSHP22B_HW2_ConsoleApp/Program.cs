using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSHP22B_HW2_ConsoleApp.Models;

namespace CSHP22B_HW2_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });

            Console.WriteLine("Users list.");
            users.ForEach(u => Console.WriteLine("   User: {0}, Password: {1}", u.Name, u.Password));

            Console.WriteLine("\n\n1. Display to the console, all the passwords that are \"hello\".");
            users.Where(x => x.Password == "hello")
                .ToList()
                .ForEach(u => Console.WriteLine("   User: {0}, Password: {1}", u.Name, u.Password));

            Console.WriteLine("\n\n2. Delete any passwords that are the lower-cased version of their Name.");
            Console.WriteLine("3. Delete the first User that has the password \"hello\".");
            Console.WriteLine("4. Display to the console the remaining users with their Name and Password.");
            users.RemoveAll(u => u.Name.ToLower() == u.Password);
            users.Remove(users.First(u => u.Password == "hello"));
            users.ForEach(u => Console.WriteLine("   User: {0}, Password: {1}", u.Name, u.Password));
        }

        private static void DisplayUsers(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine("   User: {0}, Password: {1}", user.Name, user.Password);
            }
        }
    }
}
