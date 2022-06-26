using Application.Packet;
using System.Runtime.InteropServices;

namespace Application.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct SParam
    {
        public MsgHeader Header;
        public int Parm;
    }
}
