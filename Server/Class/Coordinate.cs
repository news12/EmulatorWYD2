using Application.Struct;

namespace Application.Class
{
    public class Coordinate
    {
        // Atributos
        public int X { get; private set; }
        public int Y { get; private set; }

        public Client? Client { get; set; }

        public bool CanWalk => Client == null;

        public static SPosition Position => SPosition.New();

        // Construtor
        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
