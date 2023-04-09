namespace Memory
{
    public class DoublePointer : Pointer<double>
    {
        public DoublePointer(IMemoryReader reader, int[] offsets) : base(reader, offsets)
        {
        }

        protected override double Read()
        {
            return Reader.ReadDouble(Address);
        }
    }
}
