using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgServerCharacterCreate
    {
        MsgHeader Header;

        public int Slot;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string MobName;

        public int Class;

    }
}
