using System.Runtime.InteropServices;

namespace Application.Packet
{
    public static class PacketConvert
    {
        public static unsafe T ToStruct<T>(byte[] data) => ToStruct<T>(data, 0);
        public static unsafe T ToStructU<T>(UInt32[] data) => ToStructU<T>(data, 0);
        public static unsafe T ToStruct<T>(byte[] data, int start)
        {
            fixed (byte* pBuffer = data)
            {
                return (T)Marshal.PtrToStructure(new IntPtr(&pBuffer[start]), typeof(T));
            }
        }
        public static unsafe T ToStructU<T>(UInt32[] data, int start)
        {
            fixed (UInt32* pBuffer = data)
            {
                return (T)Marshal.PtrToStructure(new IntPtr(&pBuffer[start]), typeof(T));
            }
        }

        public static unsafe byte[] ToByteArray<T>(T str)
        {
            byte[] data = new byte[Marshal.SizeOf(str)];

            fixed (byte* buffer = data)
            {
                Marshal.StructureToPtr(str, new IntPtr(buffer), true);
            }

            return data;
        }
    }
}