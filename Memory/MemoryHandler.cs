using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mw2_fps_unlocker.Memory
{
    internal class MemoryHandler
    {
        [DllImport("kernel32.dll")]
        private static extern int ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In][Out] byte[] buffer,
            uint size,
            ref IntPtr lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll")]
        private static extern int WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In][Out] byte[] buffer,
            uint size,
            ref IntPtr lpNumberOfBytesWritten
        );

        private IntPtr pHandle;

        /// <summary>
        /// Handle memory read and write to the process (handle)
        /// </summary>
        /// <param name="pHandle"></param>
        public MemoryHandler(IntPtr pHandle) => this.pHandle = pHandle;

        private byte[] Read(int Address, int Length)
        {
            byte[] array = new byte[checked(Length - 1 + 1)];
            IntPtr zero = IntPtr.Zero;
            _ = ReadProcessMemory(pHandle, new IntPtr(Address), array, uint.Parse(Conversions.ToString(array.Length)), ref zero);
            return array;
        }

        internal int ReadInteger(int Address, int Length = 4)
        {
            return BitConverter.ToInt32(Read(Address, Length), 0);
        }

        private void Write(int Address, int Value)
        {
            byte[] bytes = BitConverter.GetBytes(Value);
            IntPtr zero = IntPtr.Zero;
            _ = WriteProcessMemory(pHandle, new IntPtr(Address), bytes, uint.Parse(Conversions.ToString(bytes.Length)), ref zero);
        }

        internal void WriteInteger(int Address, int Value)
        {
            Write(Address, Value);
        }

        internal void WriteFloat(int Address, float Float)
        {
            byte[] bytes = BitConverter.GetBytes(Float);
            IntPtr zero = IntPtr.Zero;
            _ = WriteProcessMemory(pHandle, new IntPtr(Address), bytes, 4U, ref zero);
        }
    }
}
