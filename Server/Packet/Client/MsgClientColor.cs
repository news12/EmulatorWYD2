using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MsgSayColor
    {
        MsgHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
        public string Message;
        public uint Color;
        public uint unk;
        public static MsgSayColor New(string Message, uint Color)
        {
            MsgSayColor pak = new()
            {
                Header = MsgHeader.New(OpCodeType.pMsgColorClient, Marshal.SizeOf<MsgSayColor>(), 0),
                Message = Message,
                Color = Color
            };

            return pak;
        }
    };
}
