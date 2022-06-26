namespace Db.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int AccountId { get; set; }
        public ushort CapeInfo { get; set; }
        public ushort Merchant { get; set; }
        public ushort GuildIndex { get; set; }
        public ushort MemberType { get; set; }
        public ushort ClassInfo { get; set; }
        public int AffectInfo { get; set; }
        public short QuestInfo { get; set; }
        public uint Gold { get; set; }
        public ulong Exp { get; set; }
        public CharacterLastPosition? LastPosition { get; set; }
        public CharacterStatus? CurrentStatus { get; set; }
        public List<CharacterEquip>? Equip { get; set; }
        public List<CharacterBag>? Bag { get; set; }
        public ushort InvExtra { get; set; }
        public string? Unk2 { get; set; }
        public short Item547 { get; set; }
        public byte ChaosPoints { get; set; }
        public byte CurrentKill { get; set; }
        public short TotalKill { get; set; }
        public string? Unk3 { get; set; }
        public ulong Learn { get; set; }
        public short StatusPoint { get; set; }
        public short MasterPoint { get; set; }
        public short SkillPoint { get; set; }
        public int Critical { get; set; }
        public int SaveMana { get; set; }
        public int SkillBar1 { get; set; }
        public int Unk4 { get; set; }
        public int ResistFire { get; set; }
        public int ResistIce { get; set; }
        public int ResistHoly { get; set; }
        public int ResistThunder { get; set; }
        public int Unk5 { get; set; }
        public short MagicIncrement { get; set; }
        public int Unk6 { get; set; }
        public short CityId { get; set; }
        public int SkillBar2 { get; set; }
        public int Unk7 { get; set; }
        public uint Hold { get; set; }
        public int Unk8 { get; set; }
        public int Slot { get; set; }
        public List<CharacterAffect>? Affect { get; set; }

        public Character()
        {
            Name = "";
            CapeInfo = 0;
            Merchant = 0;
            GuildIndex = 0;
            Slot = 0;
            ClassInfo = 0;
            AffectInfo = 0;
            QuestInfo = 0;
            Gold  = 0;
            Exp = 0;
            Affect = new List<CharacterAffect> { };
            CurrentStatus = new CharacterStatus { };
            Equip = new List<CharacterEquip> { };
            Bag = new List<CharacterBag> { };
        }
    }
}
