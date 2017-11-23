using System;
using System.Collections.Generic;
using System.Linq;


namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> gameResult = PlayTheGame();
            foreach (var player in gameResult)
            {
                Console.WriteLine($"{player.Key}: {player.Value}");
            }
        }

        private static Dictionary<string,int> PlayTheGame()
        {
            Dictionary<string,HashSet<string>> players = ReadInput();            

            Dictionary<string, int> gameResult = new Dictionary<string, int>();

            foreach(var player in players)
            {
                gameResult[player.Key] = getTotalValue(player.Value);
            }
            return gameResult;
        }

        private static Dictionary<string,HashSet<string>> ReadInput()
        {
            string command = Console.ReadLine();
            Dictionary<string, HashSet<string>> players = new Dictionary<string, HashSet<string>>();
            while (command.ToLower() != "joker")
            {
                string[] cards = command.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string player = cards[0].Trim();
                if (!players.ContainsKey(player))
                {
                    players.Add(player, new HashSet<string>());
                }

                for (int i = 1; i < cards.Length; i++)
                {
                    players[player].Add(cards[i]);
                }
                command = Console.ReadLine();                
            }
            return players;
        }

        private static int getTotalValue(HashSet<string> hand)
        {
            int result = 0;
            foreach (var card in hand)
            {
                int power = 0;
                
                switch(card.Substring(0, card.Length - 1).Trim())
                {
                    case "2":
                        power = 2; break;
                    case "3":
                        power = 3; break;
                    case "4":
                        power = 4; break;
                    case "5":
                        power = 5; break;
                    case "6":
                        power = 6; break;
                    case "7":
                        power = 7; break;
                    case "8":
                        power = 8; break;
                    case "9":
                        power = 9; break;
                    case "10":
                        power = 10;break;
                    case "J":
                        power = 11; break;
                    case "Q":
                        power = 12; break;
                    case "K":
                        power = 13; break;
                    case "A":
                        power = 14; break;
                    default: break;
                }
                int suit = 0;
                switch(card.Last())
                {
                    case 'S':
                        suit = 4; break;
                    case 'H':
                        suit = 3; break;
                    case 'D':
                        suit = 2; break;
                    case 'C':
                        suit = 1; break;
                    default: break;
                }
                result += power * suit;
            }
            return result;
        }
    }
}
