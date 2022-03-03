using Application.Class;
using Application.Config;
using Db.Entities;
using System.Runtime.InteropServices;

namespace Application.Struct
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct SMob
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string MobName;
        public byte Kingdom;
        public byte Merchant;
        public ushort Guild;
        public byte Class;
        public byte Rsv;
        public ushort Quest;
        public UInt32 Coin;
        public ulong Exp;
        public ushort LastX;
        public ushort LastY;
        public SStatus BaseScore;
        public SStatus CurrentScore;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public SItem[] Equip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public SItem[] Carry;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] LearnedSkill;
        public short ScoreBonus;
        public short SpecialBonus;
        public short SkillBonus;
        public byte Critical;
        public byte SaveMana;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ShortSkill;
        public byte GuildLevel;
        public byte Magic;
        public byte RegenHP;
        public byte RegenMP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Resist;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
        public byte[] dummy;
        public ushort CurrentKill;
        public ushort TotalKill;

        // Constructor
        public  SMob()
        {

            MobName = "";
            Kingdom = 0;
            Merchant = 0;
            Guild = 0;
            Class = 0;
            Rsv = 0;
            Quest = 0;
            Coin = 0;
            Exp = 0;
            LastX = 0;
            LastY = 0;
            BaseScore = new SStatus() { };
            CurrentScore = new SStatus() { };
            Equip = new SItem[16];
            Carry = new SItem[64];
            LearnedSkill = new int[2];
            ScoreBonus = 0;
            SpecialBonus = 0;
            SkillBonus = 0;
            Critical = 0;
            SaveMana = 0;
            ShortSkill = new byte[4];
            GuildLevel = 0;
            Magic = 0;
            RegenHP = 0;
            RegenMP = 0;
            Resist = new byte[4];
            dummy = new byte[212];
            CurrentKill = 0;
            TotalKill = 0;
          
        }

        public static SMob LoadMob(Character character)
        {
            SMob MOB = new();

           

            MOB.MobName = character.Name;
            MOB.Kingdom = (byte)character.CapeInfo;
            MOB.Merchant = (byte)character.Merchant;
            MOB.Guild = (byte)character.GuildIndex;
            MOB.Class = (byte)character.ClassInfo;
            MOB.Rsv = (byte)character.AffectInfo;
            MOB.Quest = (ushort)character.QuestInfo;
            MOB.Coin = character.Gold;
            MOB.Exp = 5;// character.Exp;
            MOB.LastX = (ushort)character.LastPosition.X;
            MOB.LastY = (ushort)character.LastPosition.Y;

            MOB.BaseScore = Function.GetBaseStatus(Cfg.ClassBase[MOB.Class]);
            MOB.CurrentScore = Function.GetCurrentStatus(character.CurrentStatus);
            MOB.Equip = Function.GetEquipDb(character.Equip);
            MOB.Carry = Function.GetBagDb(character.Bag);
            MOB.LearnedSkill[0] = (int)character.Learn;
            MOB.LearnedSkill[1] = (int)character.Learn;//implementar o learn2
            MOB.ScoreBonus = character.StatusPoint;
            MOB.SpecialBonus = character.MasterPoint;
            MOB.SkillBonus = character.SkillPoint;
            MOB.Critical = (byte)character.Critical;
            MOB.SaveMana = (byte)character.SaveMana;
            MOB.ShortSkill[0] = (byte)character.SkillBar1;
            MOB.ShortSkill[1] = (byte)character.SkillBar2;
            MOB.GuildLevel = (byte)character.MemberType;
            MOB.Magic = (byte)character.MagicIncrement;
            MOB.RegenHP = 2;
            MOB.RegenMP = 3;
            MOB.Resist[0] = (byte)character.ResistFire;
            MOB.Resist[1] = (byte)character.ResistIce;
            MOB.Resist[2] = (byte)character.ResistHoly;
            MOB.Resist[3] = (byte)character.ResistThunder;
            MOB.CurrentKill = character.CurrentKill;
            MOB.TotalKill = (ushort)character.TotalKill;

            return MOB;
        }
        
    }
}