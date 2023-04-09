using Memory;

namespace SCCTStats
{
    public class GameObserver
    {
        public readonly IPointer<MovementSpeed> MovementSpeed;
        public readonly IPointer<double> IGT;

        private IMemoryReader _memory;
        private bool _continue = true;
        private int _pollInterval;

        public GameObserver(IMemoryReader memory, int pollInterval = 50)
        {
            _memory = memory;
            _pollInterval = pollInterval;
            MovementSpeed = new MovementSpeedPointer(_memory, new int[] { 0x00A11E08, 0x6C, 0x3F0 });
            IGT = new DoublePointer(_memory, new int[] { 0x0090B734, 0x10, 0x14, 0x80 });
        }

        public void Start()
        {
            _continue = true;

            while (_continue)
            {
                MovementSpeed.CheckForChanges();
                IGT.CheckForChanges();
                Thread.Sleep(_pollInterval);
            }
        }

        public void Stop()
        {
            _continue = false;
        }
    }
}
