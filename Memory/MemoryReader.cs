using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Memory
{
    public class MemoryReader : IMemoryReader
    {
        private const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        private Process _process;
        private IntPtr _processHandle;
        public int BaseAddress
        {
            get
            {
                return (int)(_process.MainModule?.BaseAddress ?? throw new Exception("No base address"));
            }
        }

        public static MemoryReader FromProcessName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                throw new Exception("No matching process found");
            }

            if (processes.Length > 1)
            {
                throw new Exception("Multiple processes found with the same name");
            }

            return new MemoryReader(processes[0]);
        }

        public MemoryReader(Process process)
        {
            _process = process;
            _processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
        }

        public byte[] Read(int address, uint length)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[length];

            ReadProcessMemory((int)_processHandle, address, buffer, buffer.Length, ref bytesRead);
            return buffer;
        }

        public int ReadInt32(int address)
        {
            return BitConverter.ToInt32(Read(address, 4));
        }

        public long ReadInt64(int address)
        {
            return BitConverter.ToInt64(Read(address, 8));
        }

        public float ReadSingle(int address)
        {
            return BitConverter.ToSingle(Read(address, 4));
        }

        public double ReadDouble(int address)
        {
            return BitConverter.ToDouble(Read(address, 8));
        }

        public IPointer<int> CreateIntPointer(int[] offsets)
        {
            return new IntPointer(this, offsets);
        }

        public IPointer<float> CreateFloatPointer(int[] offsets)
        {
            return new FloatPointer(this, offsets);
        }

        public IPointer<double> CreateDoublePointer(int[] offsets)
        {
            return new DoublePointer(this, offsets);
        }
    }
}
