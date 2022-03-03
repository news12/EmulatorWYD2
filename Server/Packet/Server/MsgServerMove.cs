using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgServerMove
    {
        public MsgHeader Header;
        public UInt16 xSrc;
        public UInt16 ySrc;//[12] [14]
        public UInt32 mType;//[16]
        public UInt32 mSpeed;//[20]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string mCommand;//[24]
        public UInt16 xDst;
        public UInt16 yDst;//[48] [50]

        public MsgServerMove()
        {
            Header = new MsgHeader();
            xSrc = 0;
            ySrc = 0;
            mType = 0;
            mSpeed = 0;
            mCommand = "";
            xDst = 0;
            yDst = 0;
        }

        public static MsgServerMove New(MsgServerMove pak)
        {
            MsgServerMove m = new();
            m.xSrc = pak.xSrc;
            m.ySrc = pak.ySrc;
            m.mType = pak.mType;
            m.mSpeed = pak.mSpeed;
            m.mCommand = pak.mCommand;
            m.xDst = pak.xDst;
            m.yDst = pak.yDst;

            return m;
        }
    }
}
