using Memory;

namespace SCCTStats
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var memory = MemoryReader.FromProcessName("splintercell3");
            var game = new GameObserver(memory, 50);
            var observerThread = new Thread(new ThreadStart(game.Start));
            observerThread.Start();
            ApplicationConfiguration.Initialize();
            Application.Run(new StatsForm(game));
            game.Stop();
            observerThread.Join();
        }
    }
}