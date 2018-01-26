namespace _10._TheHeiganDance
{
    public class Player
    {
        public Player()
        {
            this.Row = 7;
            this.Col = 7;
            this.Points = 18500;
            this.IsHit = false;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Points { get; set; }

        public bool IsHit { get; set; }
    }
}