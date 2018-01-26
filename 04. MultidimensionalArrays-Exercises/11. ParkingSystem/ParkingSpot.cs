namespace _11._ParkingSystem
{
    public class ParkingSpot
    {
        public ParkingSpot(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}