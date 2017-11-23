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
            SortedSet<string> invited = new SortedSet<string>();

            string input = Console.ReadLine();

            while(input != "PARTY")
            {
                invited.Add(input);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "END")
            {
                if (invited.Any(i => i == input))
                {
                    invited.Remove(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(invited.Count);
            foreach (var person in invited)
            {
                Console.WriteLine(person);
            }
            Console.ReadLine();
        }
    }
}
