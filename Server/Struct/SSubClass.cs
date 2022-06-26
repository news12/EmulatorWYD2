using System.Runtime.InteropServices;

namespace Application.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct SSubClass
    {
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public uint[] LearnedSkill;
		public SItem Equip;
		public SStatus CurrentScore;
		public ulong Exp;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] ShortSkill;
		public short ScoreBonus;
		public short SkillBonus;

		public SSubClass()
		{
			LearnedSkill = new uint[2];
			Equip = new SItem();
			CurrentScore = new SStatus();
			Exp = 0;
			ShortSkill = new byte[20];
			ScoreBonus = 0;
			SkillBonus = 0;


	}
	}

	
}
