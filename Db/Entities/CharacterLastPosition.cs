namespace Db.Entities
{
    public class CharacterLastPosition
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public short X { get; set; }
        public short Y { get; set; }

        public  CharacterLastPosition()
        {
            X = 0;
            Y = 0;
        }

      
    }
}
