using System.Runtime.InteropServices;

namespace Application.Struct
{
    /// <summary>
    /// Item - size 8
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SItem
    {
        // Atributos
        public short Id;        // 0 a 1	= 2

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public SItemEffect[] Ef;  // 2 a 7	= 6

        // Construtores
        public SItem()
        {
            Id = 0;
            Ef = new SItemEffect[3];
        }
        public static SItem New() => New(0, 0, 0, 0, 0, 0, 0);
        public static SItem New(short Id) => New(Id, 0, 0, 0, 0, 0, 0);
        public static SItem New(short Id, byte T0, byte V0) => New(Id, T0, V0, 0, 0, 0, 0);
        public static SItem New(short Id, byte T0, byte V0, byte T1, byte V1) => New(Id, T0, V0, T1, V1, 0, 0);
        public static SItem New(short Id, byte T0, byte V0, byte T1, byte V1, byte T2, byte V2)
        {
            SItem tmp = new SItem
            {
                Id = Id,

                Ef = new SItemEffect[3]
            };

            return tmp;
        }

        public static SItem New(SItem i) => New(i.Id, i.Ef[0].Type, i.Ef[0].Value, i.Ef[1].Type, i.Ef[1].Value, i.Ef[2].Type, i.Ef[2].Value);
    }
}