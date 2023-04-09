namespace Memory
{
    public class IntPointer : Pointer<int>
    {
        public IntPointer(IMemoryReader reader, int[] offsets) : base(reader, offsets)
        {
        }

        protected override int Read()
        {
            return Reader.ReadInt32(Address);
        }
    }
}
