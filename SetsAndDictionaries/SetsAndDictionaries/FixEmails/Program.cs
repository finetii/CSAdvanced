using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> people = new Dictionary<string, string>();
            while(command.ToLower() != "stop")
            {
                string email = Console.ReadLine();
                if (!(email.Contains(".us") || (email.Contains("uk"))))
                {
                    people.Add(command, email);
                }
                command = Console.ReadLine();
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
