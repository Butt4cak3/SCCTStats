namespace SCCTStats
{
    public partial class StatsForm : Form
    {
        private GameObserver _game;

        public StatsForm(GameObserver game)
        {
            InitializeComponent();
            _game = game;
            _game.MovementSpeed.OnChange += onMovementSpeedChange;
            _game.IGT.OnChange += onIGTChange;
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            _game.MovementSpeed.OnChange -= onMovementSpeedChange;
            _game.IGT.OnChange -= onIGTChange;
        }

        private void onMovementSpeedChange(MovementSpeed value)
        {
            movementSpeedTextBox.Invoke(() =>
            {
                movementSpeedTextBox.Text = string.Format("{0} ({1})", value.ToString(), (int)value);
            });
        }

        private void onIGTChange(double value)
        {
            try
            {
                igtTextBox.Invoke(() =>
                {
                    igtTextBox.Text = string.Format("{0:0.0}", value);
                });
            }
            catch (ObjectDisposedException) { }
        }

        private void onFormShown(object sender, EventArgs e)
        {
            onMovementSpeedChange(_game.MovementSpeed.Value);
            onIGTChange(_game.IGT.Value);
        }
    }
}
