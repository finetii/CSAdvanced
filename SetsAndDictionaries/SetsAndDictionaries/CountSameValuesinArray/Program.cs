using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSameValuesinArray
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> counter = new SortedDictionary<double, int>();
            string[] strs = Console.ReadLine().Split().ToArray();
            foreach(var str in strs)
            {
                if(Double.TryParse(str, out double dblVal))
                {
                    if(counter.Any(k => k.Key == dblVal))
                    {
                        counter[dblVal]++;
                    }
                    else
                    {
                        counter[dblVal] = 1;
                    }
                }
            }
            foreach(KeyValuePair<double, int> k in counter)
            {
                Console.WriteLine(k.Key + " - " + k.Value + " times");
            }
            Console.ReadLine();
        }
    }
}
