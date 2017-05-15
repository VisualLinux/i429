namespace i429
{
    public class Bacterium
    {
        public int Age;
        public Point Location;
        public bool IsActive;

        public Bacterium(Point location, bool isActive)
        {
            Age = 0;
            Location = location;
            IsActive = isActive;
        }
    }
}