using Application.Class;
using Application.Config;
using System.Runtime.InteropServices;

namespace Application.Struct
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SCharacterListName
    {
        // Atributos
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] NameBytes;  // 0 a 15	= 16

        // Ajudantes
        public string Name
        {
            get => Function.GetString(NameBytes);
            set
            {
                NameBytes = Cfg.Encoding.GetBytes(value);
                Array.Resize(ref NameBytes, 16);
            }
        }

        // Construtores
        public static SCharacterListName New(string Name)
        {
            SCharacterListName tmp = new()
            {
                Name = Name
            };

            return tmp;
        }
    }
}