using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgServerCharacterLogin
    {
        MsgHeader Header;

        public int Slot;
        public int Force;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] SecretCode;
    }
}
