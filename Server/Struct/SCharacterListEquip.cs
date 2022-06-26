using Db.Entities;
using System.Runtime.InteropServices;

namespace Application.Struct
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    public struct SCharacterListEquip
    {
        // Atributos
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public SItem[] Slot;  // 0 a 127	= 128

        // Atributos
        public static SCharacterListEquip New()
        {
            SCharacterListEquip tmp = new()
            {
                Slot = new SItem[16]
            };

            for (int i = 0; i < tmp.Slot.Length; i++)
            {
                tmp.Slot[i] = SItem.New();
            }

            return tmp;
        }
        public static SCharacterListEquip New(SItem[] Item)
        {
            SCharacterListEquip tmp = new()
            {
                Slot = Item
            };

            return tmp;
        }

        internal static SCharacterListEquip New(List<CharacterEquip>? equip)
        {
            throw new NotImplementedException();
        }
    }
}