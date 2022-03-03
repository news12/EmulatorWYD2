using System.Runtime.InteropServices;

namespace Application.Struct
{
    /// <summary>
    /// Item effect - size 2
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SItemEffect
    {
        // Atributos
        public byte Type;   // 0
        public byte Value;  // 1

        // Construtores
        public SItemEffect()
        {
            Type = 0;
            Value = 0;
        }
        public static SItemEffect New() => New(0, 0);
        public static SItemEffect New(byte Type, byte Value)
        {
            SItemEffect tmp = new SItemEffect
            {
                Type = Type,
                Value = Value
            };

            return tmp;
        }
    }
}