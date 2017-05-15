namespace i429
{
    public class Square
    {
        public Point Location;
        public Bacterium[] Bacteria;

        public Square(Point location, Bacterium[] bacteria)
        {
            Location = location;
            Bacteria = bacteria;
        }
    }

    public class IslandSquare : Square
    {
        public Island Island;
        public IslandSquare(Point location, Bacterium[] bacteria, Island island) : base(location, bacteria)
        {
            Island = island;
        }
    }
}