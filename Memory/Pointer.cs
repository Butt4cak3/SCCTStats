namespace Memory
{
    public abstract class Pointer<T> : IPointer<T>
    {
        public int Address => resolveAddress();
        public T Value => Read();
        protected IMemoryReader Reader;
        private int[] _offsets;
        private T? _prevValue;
        private IEqualityComparer<T> _comparer;

        public event OnChangeHandler<T>? OnChange;

        public Pointer(IMemoryReader reader, int[] offsets, IEqualityComparer<T>? comparer = null)
        {
            Reader = reader;
            _offsets = offsets;
            _comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public void CheckForChanges()
        {
            var newValue = Value;
            if (!_comparer.Equals(newValue, _prevValue))
            {
                _prevValue = newValue;
                OnChange?.Invoke(newValue);
            }
        }

        abstract protected T Read();

        private int resolveAddress()
        {
            var pointerAddress = Reader.BaseAddress + _offsets[0];

            foreach (var offset in _offsets.Skip(1))
            {
                pointerAddress = Reader.ReadInt32(pointerAddress) + offset;
            }

            return pointerAddress;
        }
    }
}
