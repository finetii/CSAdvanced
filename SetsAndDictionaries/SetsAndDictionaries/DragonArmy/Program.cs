using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        private static List<DragonType> dragonTypes = new List<DragonType>();
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                ReadDragon();
            }
            foreach(var type in dragonTypes)
            {
                Console.WriteLine(type);
                type.OrderDragons();
                foreach(var dragon in type.Dragons)
                {
                    Console.WriteLine(dragon);
                }
            }
            Console.ReadLine();
        }


        private static void ReadDragon()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != 5)
                return;
            if(dragonTypes.Any(t => t.Type == input[0]))
            {
                DragonType currentType = dragonTypes.Where(t => t.Type == input[0]).FirstOrDefault();
                if(currentType.Dragons.Any(d => d.Name == input[1]))
                {
                    Dragon currentDragon = currentType.Dragons.Where(d => d.Name == input[1]).FirstOrDefault();
                    currentDragon.Damage = int.Parse(input[2]);
                    currentDragon.Health = int.Parse(input[3]);
                    currentDragon.Armor = int.Parse(input[4]);
                }
                else
                {
                    currentType.Dragons.Add(new Dragon(input[1], input[2], input[3], input[4]));
                }
            }
            else
            {
                dragonTypes.Add(new DragonType() { Type = input[0], Dragons = new List<Dragon>() { new Dragon(input[1], input[2], input[3], input[4]) } });
            }
 
        }

        private class Dragon
        {
            private const int dragonDamage = 45;
            private const int dragonHealth = 250;
            private const int dragonArmor = 10;
            
            public string Name { get; set; }
            public int Damage { get; set; }
            public int Health { get; set; }
            public int Armor { get; set; }

            public Dragon(string name, string damage, string health, string armor)
            {
                Name = name;
                Damage = int.TryParse(damage, out int d) ? d : dragonDamage;
                Health = int.TryParse(health, out int h) ? h : dragonHealth;
                Armor = int.TryParse(armor, out int a) ? a : dragonArmor;
            }

            public override string ToString()
            {
                return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
            }
        }

        private class DragonNameComparer : IComparer<Dragon>
        {
            public int Compare(Dragon x, Dragon y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }

        private class DragonType
        {
            public string Type { get; set; }
            public List<Dragon> Dragons { get; set; }

            public double Damage
            {
                get
                {
                    double average = (double)(from dragon in Dragons
                                        select dragon.Damage).Sum() / Dragons.Count;
                    return average;
                }
            }
            public double Health
            {
                get
                {
                    double average = (double)(from dragon in Dragons
                                      select dragon.Health).Sum() / Dragons.Count;
                    return average;
                }
            }
            public double Armor
            {
                get
                {
                    double average = (double)(from dragon in Dragons
                                      select dragon.Armor).Sum() / Dragons.Count;
                    return average;
                }
            }

            public override string ToString()
            {
                return $"{Type}::({Damage:f2}/{Health:f2}/{Armor:f2})";
            }

            internal void OrderDragons()
            {
                var ordered = from dragon in Dragons
                                       orderby dragon.Name ascending
                                       select dragon;
                Dragons = ordered.ToList();
            }
        }
    }
}
