using Application.Class;
using Application.Config;
using Application.OpCode;
using Application.Struct;
using Db.Entities;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgClientCharacterInfo
    {
		public MsgHeader Header;
		public short PosX;
		public short PosY;
		public SMob MOB;
		public ushort Slot;
		public ushort ClientID;
		public ushort Weather;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] ShortSkill;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public int[] Hash;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public SAffect[] Affect;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] Quest;
		public uint LastConnectTime;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public SSubClass[] SubClass;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string ItemPassWord;
		public uint ItemPos;
		public int SendLevItem;
		public short AdminGuildItem;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 126)]
		public byte[] Dummy;

		public static MsgClientCharacterInfo New(Character character)
        {
			MsgClientCharacterInfo data = new()
			{
				Header = MsgHeader.New(OpCodeType.pCharacterInfoClient, Marshal.SizeOf<MsgClientCharacterInfo>(), 30001),

				MOB = new SMob(),
				ShortSkill = new byte[16],
				Hash = new int[8],
				Affect = new SAffect[32],
				LastConnectTime = 0,
				Quest = new byte[12],
				SubClass = new SSubClass[2],
				ItemPassWord = "",
				ItemPos = 0,
				SendLevItem = 0,
				AdminGuildItem = 0,
				Dummy = new byte[126],

			};

			data.PosX = character.LastPosition.X;
			data.PosY = character.LastPosition.Y;
			data.MOB = SMob.LoadMob(character);

			data.Slot = (ushort)character.Slot;
			data.ClientID = (ushort)character.Id;
			data.Weather = 1;
			


			return data;
		}

	}
}
