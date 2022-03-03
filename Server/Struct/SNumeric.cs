using Application.Packet;
using System.Runtime.InteropServices;

namespace Application.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class SNumeric
    {
        public MsgHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public char[] Numeric;
        public int Change;
    }
}
