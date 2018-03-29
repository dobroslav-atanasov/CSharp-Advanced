namespace _03._NumberWars
{
    public class Card
    {
        public Card(int number, char symbol)
        {
            this.Number = number;
            this.Symbol = symbol;
        }

        public int Number { get; set; }

        public char Symbol { get; set; }
    }
}