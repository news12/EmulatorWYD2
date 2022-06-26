using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgParam
    {
        public MsgHeader Header;
        public int Parm;

        public static MsgParam New(OpCodeType code, int param)
        {
            MsgParam pak = new()
            {
                Header = MsgHeader.New(code, Marshal.SizeOf<MsgParam>(), 0),
                Parm = param
            };

            return pak;
        }
    
    }
    
}
