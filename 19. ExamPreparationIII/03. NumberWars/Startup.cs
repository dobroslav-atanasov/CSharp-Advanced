namespace _03._NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] secondInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<Card> firstPlayer = GetPlayerHand(firstInput);
            Queue<Card> secondPlayer = GetPlayerHand(secondInput);

            int turns = 0;
            while (true)
            {
                turns++;
                Card firstPlayerCard = firstPlayer.Dequeue();
                Card secondPlayerCard = secondPlayer.Dequeue();

                int firstPlayerCardNumber = firstPlayerCard.Number;
                int secondPlayerCardNumber = secondPlayerCard.Number;

                if (firstPlayerCardNumber > secondPlayerCardNumber)
                {
                    firstPlayer.Enqueue(firstPlayerCard);
                    firstPlayer.Enqueue(secondPlayerCard);
                }
                if (secondPlayerCardNumber > firstPlayerCardNumber)
                {
                    secondPlayer.Enqueue(secondPlayerCard);
                    secondPlayer.Enqueue(firstPlayerCard);
                }
                if (firstPlayerCardNumber == secondPlayerCardNumber)
                {
                    List<Card> firstPlayerNextCards = new List<Card> { firstPlayerCard };
                    List<Card> secondPlayerNextCards = new List<Card> { secondPlayerCard };

                    while (true)
                    {
                        for (int i = 0; i < Math.Min(firstPlayer.Count, 3); i++)
                        {
                            firstPlayerNextCards.Add(firstPlayer.Dequeue());
                        }
                        for (int i = 0; i < Math.Min(secondPlayer.Count, 3); i++)
                        {
                            secondPlayerNextCards.Add(secondPlayer.Dequeue());
                        }

                        if (firstPlayerNextCards.Count > secondPlayerNextCards.Count)
                        {
                            List<Card> allCards = TakeAllCards(firstPlayerNextCards, secondPlayerNextCards);
                            foreach (Card card in allCards)
                            {
                                firstPlayer.Enqueue(card);
                            }
                            break;
                        }
                        if (secondPlayerNextCards.Count > firstPlayerNextCards.Count)
                        {
                            List<Card> allCards = TakeAllCards(firstPlayerNextCards, secondPlayerNextCards);
                            foreach (Card card in allCards)
                            {
                                secondPlayer.Enqueue(card);
                            }
                            break;
                        }
                        if (firstPlayerNextCards.Count == secondPlayerNextCards.Count)
                        {
                            long firstPlayerSum = CalculatePlayerSum(firstPlayerNextCards);
                            long secondPlayerSum = CalculatePlayerSum(secondPlayerNextCards);

                            if (firstPlayerSum > secondPlayerSum)
                            {
                                List<Card> allCards = TakeAllCards(firstPlayerNextCards, secondPlayerNextCards);
                                foreach (Card card in allCards)
                                {
                                    firstPlayer.Enqueue(card);
                                }
                                break;
                            }
                            if (secondPlayerSum > firstPlayerSum)
                            {
                                List<Card> allCards = TakeAllCards(firstPlayerNextCards, secondPlayerNextCards);
                                foreach (Card card in allCards)
                                {
                                    secondPlayer.Enqueue(card);
                                }
                                break;
                            }
                        }
                        if (firstPlayer.Count == 0 && secondPlayer.Count == 0)
                        {
                            Console.WriteLine($"Draw after {turns} turns");
                            return;
                        }
                    }
                }

                if (firstPlayer.Count == 0)
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                    break;
                }
                if (secondPlayer.Count == 0)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                    break;
                }
                if (turns == 1000000)
                {
                    if (firstPlayer.Count > secondPlayer.Count)
                    {
                        Console.WriteLine($"First player wins after {turns} turns");
                        break;
                    }
                    else if (secondPlayer.Count > firstPlayer.Count)
                    {
                        Console.WriteLine($"Second player wins after {turns} turns");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Draw after {turns} turns");
                        break;
                    }
                }
            }
        }

        private static long CalculatePlayerSum(List<Card> playerCards)
        {
            long sum = 0;
            for (int i = playerCards.Count - 3; i < playerCards.Count; i++)
            {
                sum += (int)playerCards[i].Symbol;
            }
            return sum;
        }

        private static List<Card> TakeAllCards(List<Card> firstPlayerNextCards, List<Card> secondPlayerNextCards)
        {
            List<Card> allCards = new List<Card>();
            firstPlayerNextCards.AddRange(secondPlayerNextCards);
            foreach (Card card in firstPlayerNextCards.OrderByDescending(n => n.Number).ThenByDescending(s => s.Symbol))
            {
                allCards.Add(card);
            }
            return allCards;
        }

        private static Queue<Card> GetPlayerHand(string[] input)
        {
            Queue<Card> playerHand = new Queue<Card>();
            foreach (string cardPart in input)
            {
                int number = int.Parse(cardPart.Substring(0, cardPart.Length - 1));
                char symbol = cardPart[cardPart.Length - 1];
                Card card = new Card(number, symbol);
                playerHand.Enqueue(card);
            }
            return playerHand;
        }
    }
}