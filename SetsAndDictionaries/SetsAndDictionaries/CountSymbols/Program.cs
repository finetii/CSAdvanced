using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] inputArray = input.ToCharArray();
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();
            foreach (var letter in inputArray)
            {
                if (!letters.ContainsKey(letter))
                    letters.Add(letter, 1);
                else
                    letters[letter]++;
            }
            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
            
        }
    }
}
