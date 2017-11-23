using System;
using System.Collections.Generic;
using System.Linq;


namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> junkMaterials = new Dictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            CollectMaterials(keyMaterials, junkMaterials);

            Console.WriteLine($"{GetLegendary(keyMaterials)} obtained!");

            PrintMaterials(keyMaterials.OrderByDescending(m=>m.Value).ThenBy(m=>m.Key));

            PrintMaterials(junkMaterials.OrderBy(m=>m.Key));
        }

        private static void PrintMaterials (IOrderedEnumerable<KeyValuePair<string,int>> materials)
        {
            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }

        private static string GetLegendary(Dictionary<string,int> keyMaterials)
        {
            string materialName = keyMaterials.Where(kvp => kvp.Value >= 250).First().Key;

            keyMaterials[materialName] -= 250;

            switch(materialName)
            {
                case "shards": return "Shadowmourne";
                case "fragments": return "Valanyr";
                case "motes": return "Dragonwrath";
                default: return "Error";
            }
        }

        private static void CollectMaterials(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials)
        {
            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input.Length; i++)
                {
                    int quantity = int.Parse(input[i]);
                    i++;
                    string material = input[i];

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }
                        junkMaterials[material] += quantity;
                    }
                }
            }
        }
    }
}
