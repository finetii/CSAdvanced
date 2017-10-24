using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedSet<string> parking = new SortedSet<string>();

            while(input != "END")
            {
                string[] tokens = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "IN")
                {
                    parking.Add(tokens[1]);
                }
                else
                    parking.Remove(tokens[1]);

                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
