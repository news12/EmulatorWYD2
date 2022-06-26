namespace Db.Entities
{
    public class CharacterBag
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Slot { get; set; }
        public int ItemId { get; set; }
        public int Ef1 { get; set; }
        public int Efv1 { get; set; }
        public int Ef2 { get; set; }
        public int Efv2 { get; set; }
        public int Ef3 { get; set; }
        public int Efv3 { get; set; }
        public Character? Character { get; set; }

        public CharacterBag()
        {


            Slot = 0;
            ItemId = 0;
            Ef1 = 0;
            Efv1 = 0;
            Ef2 = 0;
            Efv2 = 0;
            Ef3 = 0;
            Efv3 = 0;


        }

        public static CharacterBag New(int slot)
        {
            CharacterBag data = new()
            {

                Slot = slot,
                ItemId = 0,
                Ef1 = 0,
                Efv1 = 0,
                Ef2 = 0,
                Efv2 = 0,
                Ef3 = 0,
                Efv3 = 0

            };

            return data;
        }
    }
}
