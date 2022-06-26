using System.Xml.Serialization;

namespace Application.Config
{

    [XmlRoot("Config")]
    public class ConfigXml
    {
        //Server Map
        public string Ip { get; set; }
        public string Port { get; set; }
        public string LoginStatus { get; set; }
        public string Title { get; set; }
        public string Heigth { get; set; }
        public string Width { get; set; }

        [XmlElement("Publisher")]
        public string Publisher { get; set; }

        [XmlElement("StringConnection")]
        public string StringConnection { get; set; }

        [XmlElement("ImportUser")]
        public string ImportUser { get; set; }

        [XmlElement("ImportDonate")]
        public string ImportDonate { get; set; }

        [XmlElement("ImportPass")]
        public string ImportPass { get; set; }

        [XmlElement("ImportCharacter")]
        public string ImportCharacter { get; set; }

        [XmlElement("ImportNotice")]
        public string ImportNotice { get; set; }
    }

    [XmlRoot("LangServer")]
    public class LangXml
    {
        //Lang Login
        public string CharacterLogin { get; set; }
        public string CharacterPass { get; set; }
        public string AccountNotFound { get; set; }
        public string IncorrectPass { get; set; }
        public string WellcomeToLogin { get; set; }
        public string LoginVerify { get; set; }
        public string CharacterCreateFail { get; set; }
        public string CharacterCreateSuccess { get; set; }
        public string IsConnected { get; set; }

        //Lang Server
        public string NotLogin { get; set; }
        public string CharacterSelectFail { get; set; }
        public string CharacterNotFound { get; set; }
        public string WellcometoWord { get; set; }
        public string ImportedFromGame { get; set; }
        public string ImportFail { get; set; }

        //Lang Db
        public string DbNotConnected { get; set; }
    }

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

    [XmlRoot("player")]
    public class Player
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public int Fame { get; set; }
        public int CapeInfo { get; set; }
        public int GuildIndex { get; set; }
        public int ClassInfo { get; set; }
        public Int64 Exp { get; set; }
        public int Level { get; set; }
        public int GuildMemberType { get; set; }
        public int Evo { get; set; }

    }
}
