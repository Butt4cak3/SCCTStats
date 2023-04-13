using Memory;
using System.Diagnostics;

namespace SCCTStats
{
    internal delegate void GameConnectHandler(GameObserver game);
    internal delegate void GameDisconnectHandler();

    internal class GameConnector
    {
        public event GameConnectHandler? OnConnect;
        public event GameDisconnectHandler? OnDisconnect;

        private int _connectInterval;
        private bool _continue = true;
        private bool _connected = false;

        public GameConnector(int connectInterval = 1000)
        {
            _connectInterval = connectInterval;
        }

        public void Watch()
        {
            _continue = true;

            while (_continue)
            {
                if (_connected)
                {
                    Thread.Sleep(_connectInterval);
                    continue;
                }

                try
                {
                    var memory = MemoryReader.FromProcessName("splintercell3");
                    var game = new GameObserver(memory, 50);
                    game.OnReadError += () =>
                    {
                        _connected = false;
                        OnDisconnect?.Invoke();
                    };
                    OnConnect?.Invoke(game);
                    _connected = true;
                }
                catch (Exception)
                {
                    if (_continue)
                    {
                        Thread.Sleep(_connectInterval);
                    }
                }
            }
        }

        public void Stop()
        {
            _continue = false;
        }
    }
}
