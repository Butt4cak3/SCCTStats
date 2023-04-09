namespace Memory
{
    public class FloatPointer : Pointer<float>
    {
        public FloatPointer(IMemoryReader reader, int[] offsets) : base(reader, offsets)
        {
        }

        protected override float Read()
        {
            return Reader.ReadSingle(Address);
        }
    }
}
