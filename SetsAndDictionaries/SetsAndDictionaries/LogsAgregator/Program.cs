using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAgregator
{
    class Program
    {
        static void Main(string[] args)
        {
             
            SortedDictionary<string, SortedDictionary<string, int>> log = CreateDictionary();

            foreach (var person in log)
            {
                int sum = (person.Value).Values.Sum();
                Console.Write($"{person.Key}: {sum} [");
                int ipCount = person.Value.Keys.Count;
                foreach (var ip in person.Value.Keys)
                {
                    ipCount--;
                    if (ipCount != 0)
                        Console.Write($"{ip}, ");
                    else
                        Console.WriteLine($"{ip}]");
                }
            }
            Console.ReadLine();
        }

        private static SortedDictionary<string,SortedDictionary<string,int>> CreateDictionary()
        {
            int number = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, int>> log = new SortedDictionary<string, SortedDictionary<string, int>>();
            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ip = input[0];
                string user = input[1];
                int duration = int.Parse(input[2]);
                if (!log.ContainsKey(user))
                {
                    log.Add(user, new SortedDictionary<string, int>());
                    log[user].Add(ip, duration);
                }
                else if (log[user].ContainsKey(ip))
                {
                    log[user][ip] += duration;
                }
                else
                    log[user].Add(ip, duration);
            }
            return log;
        }
    }
}
