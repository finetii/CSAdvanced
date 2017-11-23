using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> singers = CreateDictionary();

            PrintResult(singers);
        }

        private static void PrintResult(Dictionary<string,Dictionary<string,long>> singers)
        {
            foreach (var place in singers)
            {
                Console.WriteLine(place.Key);

                foreach (var singer in place.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
        private static Dictionary<string,Dictionary<string,long>> CreateDictionary()
        {
            Dictionary<string, Dictionary<string, long>> singers = new Dictionary<string, Dictionary<string, long>>();

            string[] input = Console.ReadLine().Split(new char[] { '@' });

            while(input[0].ToLower() != "end")
            {
                string[] singerInput = input[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string singer = String.Join(" ", singerInput);
                int ticketPrice = 0;
                int ticketsCount = 0;
                string place = " ";

                if (input[0].Last() == ' ')
                {
                    string[] input2 = input[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (input2.Length >= 3)
                    {
                        if (int.TryParse(input2[1], out ticketPrice))
                        {
                            place = input2[0];
                            ticketsCount = int.Parse(input2[2]);
                        }
                        else if (int.TryParse(input2[2], out ticketPrice))
                        {
                            place = String.Join(" ", input2[0], input2[1]);
                            ticketsCount = int.Parse(input2[3]);
                        }
                        else
                        {
                            place = String.Join(" ", input2[0], input2[1], input2[2]);
                            ticketPrice = int.Parse(input2[3]);
                            ticketsCount = int.Parse(input2[4]);
                        }
                        long amount = ticketPrice * ticketsCount;
                        if (!singers.ContainsKey(place))
                        {
                            singers.Add(place, new Dictionary<string, long>());
                            singers[place].Add(singer, amount);
                        }
                        else if (singers[place].ContainsKey(singer))
                        {
                            singers[place][singer] += amount;
                        }
                        else
                            singers[place].Add(singer, amount);
                    }
                }
                input = Console.ReadLine().Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return singers;
        }
    }
}
