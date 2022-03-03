namespace Db.Entities
{
    public class CharacterAffect
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int EfIndex { get; set; }
        public int EfMaster { get; set; }
        public ushort EfValue { get; set; }
        public uint EfTime { get; set; }
        public Character? Character { get; set; }

        public static CharacterAffect New()
        {
            CharacterAffect tmp = new()
            {
               
                EfIndex = 0,
                EfMaster = 0,
                EfValue = 0,
                EfTime = 0

            };

            return tmp;
        }

    }
}
