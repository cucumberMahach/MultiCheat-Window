using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiCheat_Window.Utils
{
    public class Memory
    {
        private IntPtr handle;
        private VAMemory vam;

        private int size;
        private IntPtr buf;
        public Memory(IntPtr handle, string processName)
        {
            this.handle = handle;
            vam = new VAMemory(processName);

            size = 64;
            buf = Marshal.AllocHGlobal(size);
        }

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr handle, IntPtr Address, IntPtr buffer, int Size, out IntPtr lpNumberOfBytesReaded);

        public T Read<T>(IntPtr ptr, T defVal = default(T)) where T : struct
        {
            T val = defVal;
            IntPtr bytes/*, buf*/;

            //var size = Marshal.SizeOf(typeof(T)) 64;
            //buf = Marshal.AllocHGlobal(size);
            if (ReadProcessMemory(handle, ptr, buf, size, out bytes))
                val = (T)Marshal.PtrToStructure(buf, typeof(T));

            //Marshal.FreeHGlobal(buf);

            return val;
        }

        private Type b = typeof(bool), f = typeof(float), i = typeof(int);

        public bool RdBool(IntPtr ptr)
        {
            IntPtr bytes;
            if (ReadProcessMemory(handle, ptr, buf, size, out bytes))
                return (bool) Marshal.PtrToStructure(buf, b);
            return false;
        }

        public float RdFloat(IntPtr ptr)
        {
            IntPtr bytes;
            if (ReadProcessMemory(handle, ptr, buf, size, out bytes))
                return (float)Marshal.PtrToStructure(buf, f);
            return -1;
        }

        public int RdInt32(IntPtr ptr)
        {
            IntPtr bytes;
            if (ReadProcessMemory(handle, ptr, buf, size, out bytes))
                return (int)Marshal.PtrToStructure(buf, i);
            return -1;
        }

        public bool ReadBoolean(IntPtr address)
        {
            return RdBool(address);
            //return Read<bool>(address);
            //return vam.ReadBoolean(address);
        }

        public float ReadFloat(IntPtr address)
        {
            return RdFloat(address);
            //return Read<float>(address);
            //return vam.ReadFloat(address);
        }

        public int ReadInt32(IntPtr address)
        {
            return RdInt32(address);
            //return Read<int>(address);
            //return vam.ReadInt32(address);
        }

        public bool WriteBoolean(IntPtr address, bool value)
        {
            return vam.WriteBoolean(address, value);
            //return vam.WriteBoolean(address, value);
        }

        public bool WriteFloat(IntPtr address, float value)
        {
            return vam.WriteFloat(address, value);
            //return vam.WriteFloat(address, value);
        }
        public bool WriteInt32(IntPtr address, int value)
        {
            return vam.WriteInt32(address, value);
             //return vam.WriteInt32(address, value);
        }
    }
}
