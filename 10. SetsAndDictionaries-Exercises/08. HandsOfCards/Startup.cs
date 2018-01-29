namespace _08._HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();

            while (input != "JOKER")
            {
                string[] inputParts = input.Split(':');
                string name = inputParts[0];
                List<string> cards = inputParts[1].Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (!players.ContainsKey(name))
                {
                    players[name] = new List<string>();
                }
                players[name].AddRange(cards);
                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<string>> player in players)
            {
                int playerHand = GetHandPower(player.Value.Distinct());
                Console.WriteLine($"{player.Key}: {playerHand}");
            }
        }

        private static int GetHandPower(IEnumerable<string> playerHand)
        {
            int result = 0;
            foreach (string card in playerHand)
            {
                string typeString = card[card.Length - 1].ToString();
                string powerString = card.Substring(0, card.Length - 1);

                int type = 0;

                switch (typeString)
                {
                    case "S": type = 4; break;
                    case "H": type = 3; break;
                    case "D": type = 2; break;
                    case "C": type = 1; break;
                }

                switch (powerString)
                {
                    case "2": result += type * 2; break;
                    case "3": result += type * 3; break;
                    case "4": result += type * 4; break;
                    case "5": result += type * 5; break;
                    case "6": result += type * 6; break;
                    case "7": result += type * 7; break;
                    case "8": result += type * 8; break;
                    case "9": result += type * 9; break;
                    case "10": result += type * 10; break;
                    case "J": result += type * 11; break;
                    case "Q": result += type * 12; break;
                    case "K": result += type * 13; break;
                    case "A": result += type * 14; break;
                }
            }

            return result;
        }
    }
}