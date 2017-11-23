using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesInArray1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<double,int> dict = new SortedDictionary<double, int>();

            foreach (var token in input)
            {
                double reminder;
                if(token.Contains(","))
                {
                    reminder = double.Parse(token.Replace(",", "."));
                }
                else
                {
                    reminder = double.Parse(token);
                }
                if(!dict.ContainsKey(reminder))
                {
                    dict.Add(reminder, 1);
                }
                else
                {
                    dict[reminder]++;
                }
            }

            foreach (var pair in dict)
            {
                if(pair.Key.ToString().Contains("."))
                {
                    string reminder = pair.Key.ToString().Replace(".", ",");
                    Console.WriteLine($"{reminder} - {pair.Value} times");
                }
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
