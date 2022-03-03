using Application.Struct;

namespace Application.Class
{
    public class Map
    {
        // Atributos


        private Coordinate[,] Coords { get; set; }

        // Construtor
        public Map()
        {
            Coords = new Coordinate[4096, 4096];
        }

        // Retorna a Coord
        public Coordinate GetCoord(SPosition pos) => GetCoord(pos.X, pos.Y);
        public Coordinate GetCoord(int X, int Y)
        {
            if (X < 0 || X > 4095)
            {
                throw new Exception($"X: 0 > {X} > 4095");
            }
            else if (Y < 0 || Y > 4095)
            {
                throw new Exception($"Y: 0 > {Y} > 4095");
            }

            ref Coordinate coord = ref Coords[X, Y];

            if (coord == null)
            {
                coord = new Coordinate(X, Y);
            }

            return coord;
        }

        // Task
        public void OnTask()
        {
        }
    }
}