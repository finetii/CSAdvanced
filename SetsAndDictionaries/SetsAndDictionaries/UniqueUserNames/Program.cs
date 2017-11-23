using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueUserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
