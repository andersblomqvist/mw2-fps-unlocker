using System.Diagnostics;
using System.Runtime.InteropServices;

namespace mw2_fps_unlocker.Memory
{
    /// <summary>
    /// Read/write memory of a 64-bit process. The calling app must be built
    /// as x64 (Platform target: x64)
    internal class MemoryHandler
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            nuint nSize,
            out nuint lpNumberOfBytesRead
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            nuint nSize,
            out nuint lpNumberOfBytesWritten
        );

        private readonly IntPtr pHandle;

        /// <summary>
        /// Base address of the main module (iw4mp.exe). The exe uses ASLR,
        /// so this changes between launches and all offsets are relative to it.
        /// </summary>
        internal IntPtr BaseAddress { get; }

        internal MemoryHandler(Process process)
        {
            pHandle = process.Handle;
            BaseAddress = process.MainModule!.BaseAddress;
        }

        private byte[]? Read(IntPtr address, int length)
        {
            byte[] buffer = new byte[length];
            if (!ReadProcessMemory(pHandle, address, buffer, (nuint)length, out nuint read) || read != (nuint)length)
                return null;
            return buffer;
        }

        /// <summary>Reads a 64-bit pointer. Returns IntPtr.Zero on failure.</summary>
        internal IntPtr ReadPointer(IntPtr address)
        {
            byte[]? b = Read(address, 8);
            return b == null ? IntPtr.Zero : (IntPtr)BitConverter.ToInt64(b, 0);
        }

        internal int ReadInteger(IntPtr address)
        {
            byte[]? b = Read(address, 4);
            return b == null ? 0 : BitConverter.ToInt32(b, 0);
        }

        internal float ReadFloat(IntPtr address)
        {
            byte[]? b = Read(address, 4);
            return b == null ? 0f : BitConverter.ToSingle(b, 0);
        }

        internal void WriteInteger(IntPtr address, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            _ = WriteProcessMemory(pHandle, address, bytes, (nuint)bytes.Length, out _);
        }

        internal void WriteFloat(IntPtr address, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            _ = WriteProcessMemory(pHandle, address, bytes, (nuint)bytes.Length, out _);
        }
    }
}