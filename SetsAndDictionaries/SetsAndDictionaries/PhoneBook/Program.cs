using System;
using System.Collections.Generic;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (command != "search")
            {
                string[] people = command.Split('-');
                if (!phonebook.ContainsKey(people[0]))
                {
                    phonebook.Add(people[0], people[1]);
                }
                else
                    phonebook[people[0]] = people[1];
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "stop")
            {
                if (phonebook.ContainsKey(command))
                {
                    Console.WriteLine($"{command} -> {phonebook[command]}");
                }
                else
                    Console.WriteLine($"Contact {command} does not exist.");
                command = Console.ReadLine();
            }
        }
    }
}
