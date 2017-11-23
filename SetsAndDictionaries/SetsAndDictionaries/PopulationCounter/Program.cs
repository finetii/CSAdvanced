using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> population = Readinput();
            foreach (var country in population.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                List<long> sum = country.Value.Select(x => x.Value).ToList();

                Console.WriteLine($"{country.Key} (total population: {sum.Sum()})");
                foreach (var town in country.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }
        }

        private static Dictionary<string,Dictionary<string,long>> Readinput()
        {
            string command = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> population = new Dictionary<string, Dictionary<string, long>>();

            while(command.ToLower() != "report")
            {
                string[] input = command.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string country = input[1];
                string town = input[0];
                long people = long.Parse(input[2]);
                if (!population.ContainsKey(country))
                {
                    population.Add(country, new Dictionary<string, long>());
                    population[country].Add(town, people);
                }
                else if (population[country].ContainsKey(town))
                {
                    population[country][town] += people;
                }
                else
                    population[country].Add(town, people);
                
                command = Console.ReadLine();
            }
            return population;
        }


    }
}
