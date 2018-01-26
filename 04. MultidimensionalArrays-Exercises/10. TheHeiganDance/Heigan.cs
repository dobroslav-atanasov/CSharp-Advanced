namespace _10._TheHeiganDance
{
    public class Heigan
    {
        public Heigan()
        {
            this.Points = 3000000;
        }

        public double Points { get; set; }

        public void Damage(double damage)
        {
            this.Points -= damage;
        }
    }
}