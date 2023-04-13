using Memory;

namespace SCCTStats
{
    public delegate void ChangeHandler<T>(T value);

    internal class PointerControlConnection<TControl, TValue> : IPointerControlConnection where TControl : Control
    {
        private readonly TControl _control;
        private readonly IPointer<TValue> _pointer;
        private readonly ChangeHandler<TValue> _changeHandler;

        public PointerControlConnection(TControl control, IPointer<TValue> pointer, ChangeHandler<TValue> handler)
        {
            _control = control;
            _pointer = pointer;
            _changeHandler = handler;
        }

        public void Connect()
        {
            _pointer.OnChange += onChange;
        }

        public void Disconnect()
        {
            _pointer.OnChange -= onChange;
        }

        public void Initialize()
        {
            onChange(_pointer.Value);
        }

        private void onChange(TValue value)
        {
            _control.Invoke(() => _changeHandler(value));
        }
    }
}
