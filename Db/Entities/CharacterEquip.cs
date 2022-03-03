namespace Db.Entities
{
    /*	"FACE",	0
        "HELMT",	1
        "ARMOR",	2
        "PANT",		3
        "GLOVE",	4
        "BOOT",		5
        "WEAPON1",	6
        "WEAPON2",	7
        "RING",		8
        "AMULET",	9
        "ORB",		10
        "STONE",	11
        "GUILD",	12
        "PET",		13
        "MOUNT",	14
        "MANTLE"	15
    */
    public class CharacterEquip
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

        public CharacterEquip()
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

        public static CharacterEquip New(int slot, string effects)
        {
            string[] ef = effects.Split(',');
            CharacterEquip data = new()
            {

                Slot = slot,
                ItemId = int.Parse(ef[0]),
                Ef1 = int.Parse(ef[1]),
                Efv1 = int.Parse(ef[2]),
                Ef2 = int.Parse(ef[3]),
                Efv2 = int.Parse(ef[4]),
                Ef3 = int.Parse(ef[5]),
                Efv3 = int.Parse(ef[6])

            };

            return data;
        }


    }
}
