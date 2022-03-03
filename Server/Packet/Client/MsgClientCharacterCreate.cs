using Application.OpCode;
using Application.Struct;
using System.Runtime.InteropServices;

namespace Application.Packet
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MsgClientCharacterCreate
    {
        public MsgHeader Header;

        public List<SCharacterList> CharSelected;

        public static MsgClientCharacterCreate New(ClientSession client)
        {
            MsgClientCharacterCreate data = new()
            {
                Header = MsgHeader.New(OpCodeType.pCreateCharacterClient, Marshal.SizeOf<MsgClientCharacterCreate>(), 0),

                CharSelected = SCharacterList.New(client),

            };


            return data;
        }
    }

    
}
