using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MsgServerLogin
    {
        MsgHeader Header;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string nCode;  // 12 a 21	= 10
        public char channel;               //[065]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string Password;               //[012]
        public char flag;                  //[064]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserName;              //[048]
        public char space;                 //[066]
        public char slot;                  //[067]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string Key;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string MacAddres;
        public uint time;              //[104]
        public uint clock;             //[108]
        public uint change_index;      //[112]
        public uint Version;            //[116]
        public uint ip;                //[120]


    }
}
