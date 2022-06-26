using Application.Class;
using Application.Config;
using Application.OpCode;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MsgClient
    {
        MsgHeader Header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] MessageByte;

        public string Message
        {
            get => Function.GetString(MessageByte);
            set
            {
                MessageByte = Cfg.Encoding.GetBytes(value);
                Array.Resize(ref MessageByte, 128);
            }
        }

        public static MsgClient New(string Message)
        {
            MsgClient pak = new()
            {
                Header = MsgHeader.New(OpCodeType.pMsgClient, Marshal.SizeOf<MsgClient>(), 0),
                Message = Message
            };

            return pak;
        }

    }
}
