namespace Db.Entities
{
    public class CharacterStatus
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
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
        public short SStr { get; set; }
        public short SInt { get; set; }
        public short SDex { get; set; }
        public short SCon { get; set; }
        public ushort WMaster { get; set; }
        public ushort FMaster { get; set; }
        public ushort SMaster { get; set; }
        public ushort TMaster { get; set; }

        public CharacterStatus()
        {
            Level = 0;
            Defense = 0;
            Attack = 0;
            Merchant = 0;
            MobSpeed = 0;
            Direction = 0;
            ChaosRate = 0;
            MaxHP = 0;
            MaxMP = 0;
            CurHP = 0;
            CurMP = 0;
            SStr = 0;
            SInt = 0;
            SDex = 0;
            SCon = 0;
            WMaster = 0;
            FMaster = 0;
            SMaster = 0;
            TMaster = 0;
        }
    }
}
