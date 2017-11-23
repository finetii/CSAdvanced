using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<int> n = new SortedSet<int>();
            SortedSet<int> m = new SortedSet<int>();
            int[] lengths = Console.ReadLine().Split().Select(s => Int32.Parse(s)).ToArray();

            for (int i = 0; i < lengths[0]; i++)
            {
                int temp = Int32.Parse(Console.ReadLine());
                if (!n.Any(k => k == temp))
                {
                    n.Add(temp);
                }
            }
            for (int i = 0; i < lengths[1]; i++)
            {
                int temp = Int32.Parse(Console.ReadLine());
                if (!m.Any(k => k == temp))
                {
                    m.Add(temp);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach(var el in n)
            {
                if(m.Any(e => e == el))
                {
                    sb.Append(el + " ");
                }
            }
            Console.WriteLine(sb.ToString().Trim());
            Console.ReadLine();
        }
    }
}
