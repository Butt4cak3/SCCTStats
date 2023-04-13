using Memory;

namespace SCCTStats
{
    public partial class StatsForm : Form
    {
        private GameObserver _game;
        private List<IPointerControlConnection> _connections;

        public StatsForm(GameObserver game)
        {
            InitializeComponent();
            _game = game;
            _connections = new List<IPointerControlConnection>();
            connect(timerText, _game.IGT, onIGTChange);
            connect(movementSpeedText, _game.MovementSpeed, onMovementSpeedChange);
            connect(alarmsText, _game.Alarms, onAlarmsChange);
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var connection in _connections)
            {
                connection.Disconnect();
            }
        }

        private void onFormShown(object sender, EventArgs e)
        {
            foreach (var connection in _connections)
            {
                connection.Connect();
                connection.Initialize();
            }
        }

        private void onIGTChange(double value)
        {
            var minutes = (int) Math.Truncate(value / 60);
            var seconds = value - (minutes * 60);
            timerText.Text = string.Format("{0:00}:{1:00.0}", minutes, seconds);
        }

        private void onMovementSpeedChange(MovementSpeed value)
        {
            movementSpeedText.Text = string.Format("{0} ({1})", value.ToString(), (int)value);
        }

        private void onAlarmsChange(int value)
        {
            alarmsText.Text = value.ToString();
        }

        private void connect<TControl, TValue>(TControl control, IPointer<TValue> pointer, ChangeHandler<TValue> changeHandler) where TControl : Control
        {
            _connections.Add(new PointerControlConnection<TControl, TValue>(control, pointer, changeHandler));
        }
    }
}
