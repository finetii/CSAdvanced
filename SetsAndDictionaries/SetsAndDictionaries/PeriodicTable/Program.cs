using System;
using System.Collections.Generic;


namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] el = Console.ReadLine().Split(' ');
                for (int j = 0; j < el.Length; j++)
                {
                    elements.Add(el[j]);
                }
            }
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
