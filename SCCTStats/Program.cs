using System.Diagnostics;

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
            ApplicationConfiguration.Initialize();
            var waitForm = new WaitingForGameForm();
            StatsForm? statsForm = null;

            var connector = new GameConnector();

            connector.OnConnect += (game) =>
            {
                var observerThread = new Thread(new ThreadStart(game.Start));
                observerThread.Start();
                waitForm.Invoke(() =>
                {
                    statsForm = new StatsForm(game);
                    statsForm.Show();
                    waitForm.Hide();
                });
            };

            connector.OnDisconnect += () =>
            {
                waitForm.Invoke(() =>
                {
                    statsForm?.Close();
                    waitForm.Show();
                });
            };

            var connectorThread = new Thread(new ThreadStart(connector.Watch));
            connectorThread.Start();
            Application.Run(waitForm);
            connector.Stop();
        }
    }
}