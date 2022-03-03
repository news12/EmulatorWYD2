using Db.Entities;
using Application.OpCode;
using System.Runtime.InteropServices;
using Application.Struct;
using Application.Class;

namespace Application.Packet
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
	public struct MsgClientSpawan
	{
		public MsgHeader Header;

		public short PositionX;
		public short PositionY;
		public ushort Index;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string MobName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public ushort[] Refine;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public ushort[] Affect;

		public ushort Guild;
		public byte MemberType;
		public SStatus Score;
		public ushort SpawanType;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] AnctCode;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 26)]
		public string Tab;

		public byte Server;

		public static MsgClientSpawan New(ClientSession client)
		{
			Character character = client.GetAccount().Character;
			MsgClientSpawan data = new()
			{
				Header = MsgHeader.New(OpCodeType.pSpawanClient, Marshal.SizeOf<MsgClientSpawan>(), 30000),
				//Position = new SPoint<short, short>(),
				Score = SStatus.New(),
				Refine = new ushort[16],
				Affect = new ushort[32],
				AnctCode = new byte[16]

			};
			data.PositionX = character.LastPosition.X;
			data.PositionY = character.LastPosition.Y;
			data.Index = (ushort)client.GetAccount().Id;
			data.MobName = character.Name;
            for (int i = 0; i < 16; i++)
            {
				data.Refine[i] = (ushort)character.Equip[i].ItemId;
				data.AnctCode[i] = 0;
            }
            for (int i = 0; i < 32; i++)
            {
				data.Affect[i] = (ushort)character.Affect[i].EfIndex;
            }

			data.Guild = character.GuildIndex;
			data.MemberType = (byte)character.MemberType;
			data.Score = Function.GetCurrentStatus(character.CurrentStatus);
			data.SpawanType = 2;
			data.Tab = "";
			data.Server = 1;

			return data;
		}
	}
}
