using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> collection = new Dictionary<string, int>();
            while(command.ToLower() != "stop")
            {
                int.TryParse(Console.ReadLine(), out int quantity);
                if (!collection.ContainsKey(command))
                {
                    collection.Add(command, quantity);
                }
                else
                    collection[command] += quantity;
                command = Console.ReadLine();
            }
            foreach (var resourse in collection)
            {
                Console.WriteLine($"{resourse.Key} -> {resourse.Value}");
            }
        }
    }
}
