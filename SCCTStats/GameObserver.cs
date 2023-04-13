using Memory;
using System.ComponentModel;

namespace SCCTStats
{
    public delegate void ReadErrorHandler();

    public class GameObserver
    {
        public readonly IPointer<MovementSpeed> MovementSpeed;
        public readonly IPointer<double> IGT;
        public readonly IPointer<int> Alarms;

        public event ReadErrorHandler? OnReadError;

        private IMemoryReader _memory;
        private List<IUpdatable> _pointers;
        private bool _continue = true;
        private int _pollInterval;

        public GameObserver(IMemoryReader memory, int pollInterval = 50)
        {
            _memory = memory;
            _pollInterval = pollInterval;
            _pointers = new List<IUpdatable>();
            MovementSpeed = register(new MovementSpeedPointer(_memory, new int[] { 0x00A11E08, 0x6C, 0x3F0 }));
            IGT = register(new DoublePointer(_memory, new int[] { 0x0090B734, 0x10, 0x14, 0x80 }));
            Alarms = register(new IntPointer(_memory, new int[] { 0x00A17608, 0x6C, 0x40, 0xC48 }));
        }

        public void Start()
        {
            try
            {
                _continue = true;

                while (_continue)
                {
                    foreach (var pointer in _pointers)
                    {
                        pointer.CheckForChanges();
                    }
                    Thread.Sleep(_pollInterval);
                }
            } catch (Win32Exception e)
            {
                OnReadError?.Invoke();
            }
        }

        public void Stop()
        {
            _continue = false;
        }

        private IPointer<T> register<T>(IPointer<T> pointer)
        {
            _pointers.Add(pointer);
            return pointer;
        }
    }
}
