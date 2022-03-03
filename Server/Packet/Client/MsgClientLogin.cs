using Application.Config;
using Application.OpCode;
using Application.Struct;
using System.Runtime.InteropServices;
namespace Application.Packet
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct MsgClientLogin
    {
        // Atributos
        public MsgHeader Header;          // 0 a 11				= 12

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Keys;           // 12 a 27			= 16

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public SCharacterList[] CharList;      // 28 a 871			= 844

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public SItem[] Cargo;

        public int Gold;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserName;  // 1900 a 1911	= 12


        public int SSN1;
        public int SSN2;


        // Construtores
        public static MsgClientLogin New(ClientSession client)
        {
            List<SCharacterList> list = SCharacterList.New(client);
            MsgClientLogin tmp = new()
            {
                Header = MsgHeader.New(OpCodeType.pLoginClient, Marshal.SizeOf<MsgClientLogin>(), 30002),
                Keys = new byte[16],
                CharList = new SCharacterList[4],
                Cargo = new SItem[128],

                Gold = 0,
                UserName = "",//client.GetAccount().Name ?? "",

                SSN1 = 0,
                SSN2 = 0
            };
            var rand = new Random();

            for (int i = 0; i < 16; i++)
            {
                byte _rand = EncDec.keyTable[rand.Next(0, 512)];

                // Seta a key no pacote e na estrutura do usuário
                tmp.Keys[i] = _rand;
                tmp.Keys[i] = _rand;
            }
            for (int i = 0; i < 4; i++)
                tmp.CharList[i] = list[i];


            return tmp;
        }
    }

}