using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MsgServerCheckLogin
    {
        MsgHeader Header;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Account;

        public static MsgServerCheckLogin New(string rcv)
        {
            MsgServerCheckLogin pak = new()
            {
                Header = MsgHeader.New(OpCodeType.pLoginCheck, Marshal.SizeOf<MsgServerCheckLogin>(), 0),
                Account = rcv
            };

            return pak;
        }
    }
}
