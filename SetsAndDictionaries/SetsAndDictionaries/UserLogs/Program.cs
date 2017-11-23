using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,Dictionary<string,int>> users = ReadInput();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: ");
                foreach (var ip in user.Value)
                {
                    if(ip.Key.Equals(user.Value.Keys.Last()))
                    {
                        Console.WriteLine($"{ip.Key} => {ip.Value}.");
                        break;                        
                    }
                    Console.Write($"{ip.Key} => {(ip.Value)}, ");
                }
            }

        }

        private static SortedDictionary<string, Dictionary<string, int>> ReadInput()
        {
            string command = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            while(command.ToLower() != "end")
            {
                string[] input = command.Split(new char[] { ' ','=' }, StringSplitOptions.RemoveEmptyEntries);
                string ip = input[1];
                string user = input[5];

                if(!users.ContainsKey(user))
                {
                    users.Add(user, new Dictionary<string, int>());
                    users[user].Add(ip, 1);
                }
                else if(users[user].ContainsKey(ip))
                {
                    users[user][ip] += 1;
                }
                else
                {
                    users[user].Add(ip, 1);
                }
                
                command = Console.ReadLine();
            }

            return users;
        }

    }
}
