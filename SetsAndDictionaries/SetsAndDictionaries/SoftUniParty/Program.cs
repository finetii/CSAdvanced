using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> invites = new SortedSet<string>();
            SortedSet<string> notCome = new SortedSet<string>();

            string input = Console.ReadLine();

            while(input != "PARTY")
            {
                invites.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                foreach (var person in invites)
                {
                    if(input != person)
                    {
                        notCome.Add(input);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(notCome.Count);
            foreach (var person in notCome)
            {
                Console.WriteLine(person);
            }
        }
    }
}
