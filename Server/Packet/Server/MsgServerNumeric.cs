using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class MsgServerNumeric
    {
        public MsgHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string Numeric;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string AccountName;
        public ushort Change;

        public static MsgServerNumeric New(string rcv, OpCodeType opCode = OpCodeType.pNumeric)
        {
            MsgServerNumeric pak = new()
            {
                Header = MsgHeader.New(opCode, Marshal.SizeOf<MsgServerNumeric>(), 0),
                Numeric = rcv
            };

            return pak;
        }
    }
}
