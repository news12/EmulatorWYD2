using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgHeader
    {
        public short Size;     // 0 a 1	= 2
        public byte Key;        // 2			= 1
        public byte CheckSum; // 3			= 1
        public short PacketId;  // 4 a 5	= 2
        public short ClientId;  // 6 a 7	= 2
        public int TimeStamp;   // 8 a 11	= 4

        // Construtores
        public static MsgHeader New(OpCodeType PacketID, int Size, int ClientID)
        {

            MsgHeader pMsg = new()
            {
                Size = (short)Size,
                Key = 0,
                CheckSum = 0,
                PacketId = (short)PacketID,
                ClientId = (short)ClientID,
                TimeStamp = Environment.TickCount
            };

            if (Size < 12)
                _ = 0;

            return pMsg;
        }
    }



}
