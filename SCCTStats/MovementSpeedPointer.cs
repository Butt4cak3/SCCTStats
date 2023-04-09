using Memory;

namespace SCCTStats
{
    internal class MovementSpeedPointer : Pointer<MovementSpeed>
    {
        public MovementSpeedPointer(IMemoryReader reader, int[] offsets, IEqualityComparer<MovementSpeed>? comparer = null) : base(reader, offsets, comparer)
        {
        }

        protected override MovementSpeed Read()
        {
            var value = Reader.ReadSingle(Address);

            if (value > 0.9)
            {
                return MovementSpeed.Fastest;
            }
            else if (value > 0.7)
            {
                return MovementSpeed.Fast;
            }
            else if (value > 0.5)
            {
                return MovementSpeed.Medium;
            }
            else if (value > 0.3)
            {
                return MovementSpeed.Slow;
            }
            else
            {
                return MovementSpeed.Slowest;
            }
        }
    }
}
