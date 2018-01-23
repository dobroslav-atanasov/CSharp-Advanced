namespace _06._TruckTour
{
    public class Pump
    {
        public Pump(int id, long petrol, long distance)
        {
            this.Id = id;
            this.Petrol = petrol;
            this.Distance = distance;
        }

        public int Id { get; set; }

        public long Petrol { get; set; }

        public long Distance { get; set; }
    }
}