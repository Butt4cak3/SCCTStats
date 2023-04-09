namespace Memory
{
    public interface IMemoryReader
    {
        public int BaseAddress { get; }
        public byte[] Read(int address, uint length);
        public int ReadInt32(int address);
        public long ReadInt64(int address);
        public float ReadSingle(int address);
        public double ReadDouble(int address);
        public IPointer<int> CreateIntPointer(int[] offsets);
        public IPointer<float> CreateFloatPointer(int[] offsets);
        public IPointer<double> CreateDoublePointer(int[] offsets);
    }
}
