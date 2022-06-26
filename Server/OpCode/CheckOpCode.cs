using Application.Packet;
using System.Runtime.InteropServices;

namespace Application.OpCode
{
    public static class CheckOpCode
    {

        private static OpCodeType nCode = 0;
        public static OpCodeType Check(short Code, Int32 size)
        {
            nCode = (OpCodeType)Code;

            if (!ValidPacket(size))
                nCode = 0;

            return nCode;
        }

        private static bool ValidPacket(Int32 size)
        {
          
            int nSize = 0;
            switch (nCode)
            {
                case OpCodeType.pLogin:
                    nSize = Marshal.SizeOf<MsgServerLogin>();
                  
                    break;
                case OpCodeType.pLoginCheck:
                    nSize = Marshal.SizeOf<MsgServerCheckLogin>();
                 
                    break;
                case OpCodeType.pNumeric:
                    nSize = Marshal.SizeOf<MsgServerNumeric>();
                 
                    break;
                case OpCodeType.pCharacterCreate:
                    nSize = Marshal.SizeOf<MsgServerCharacterCreate>();

                    break;

                case OpCodeType.pCharacterLogin:
                    nSize = Marshal.SizeOf<MsgServerCharacterLogin>();
                    break;
                case OpCodeType.pUpdateCity:
                    nSize = Marshal.SizeOf<MsgParam>();
                    break;
                case OpCodeType.pMove:
                    nSize = Marshal.SizeOf<MsgServerMove>();
                    break;
                default:
                    break;
            }
            return nSize == size;


        }


    }
}
