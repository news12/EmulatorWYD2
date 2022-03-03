using System.Xml.Serialization;

namespace CharBaseEditor
{
    [XmlRoot("ClassBase")]
    public class ClassBase
    {
        public int Guild { get; set; }
        public int Class { get; set; }
        public uint Coin { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Level { get; set; }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public byte Merchant { get; set; }
        public byte MobSpeed { get; set; }
        public byte Direction { get; set; }
        public byte ChaosRate { get; set; }
        public uint MaxHP { get; set; }
        public uint MaxMP { get; set; }
        public uint CurHP { get; set; }
        public uint CurMP { get; set; }

        //str/int/dex/con
        public string BaseStatus { get; set; }

        public string Special { get; set; }
        public ulong LearnedSkill { get; set; }
        public short Magic { get; set; }
        public int ScoreBonus { get; set; }
        public short SpecialBonus { get; set; }
        public short SkillBonus { get; set; }
        public int Critikal { get; set; }
        public int SaveMana { get; set; }
        public int GuildLevel { get; set; }
        public int RegenHP { get; set; }
        public int RegenMP { get; set; }
        public string SkillBar { get; set; }
        public string Resist { get; set; }

        //Equip
        public string Face { get; set; }
        public string Helmet { get; set; }
        public string Armor { get; set; }
        public string Pant { get; set; }
        public string Glove { get; set; }
        public string Boot { get; set; }
        public string Weapon { get; set; }
        public string Shield { get; set; }
        public string Ring { get; set; }
        public string Amulet { get; set; }
        public string Orb { get; set; }
        public string Stone { get; set; }
        public string Traje { get; set; }
        public string Pixie { get; set; }
        public string Mount { get; set; }
        public string Mantle { get; set; }

    }
}
