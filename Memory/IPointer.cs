namespace Memory
{
    public delegate void OnChangeHandler<T>(T value);

    public interface IPointer<T>
    {
        public int Address { get; }
        public T Value { get; }

        public event OnChangeHandler<T>? OnChange;
        public void CheckForChanges();
    }
}
