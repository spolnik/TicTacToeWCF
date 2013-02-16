using System.Windows;
using System.Windows.Input;
using CircleCrossGame.TicTacToeServiceReference;

namespace CircleCrossGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        internal Player Player { get; private set; }
        private readonly TicTacToeProxy _proxy;

        public MainWindow()
        {
            InitializeComponent();
            this._proxy = new TicTacToeProxy(this);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            this.Player = this._proxy.Join();

            this.buttonA1.IsEnabled = true;
            this.buttonA2.IsEnabled = true;
            this.buttonA3.IsEnabled = true;
            this.buttonB1.IsEnabled = true;
            this.buttonB2.IsEnabled = true;
            this.buttonB3.IsEnabled = true;
            this.buttonC1.IsEnabled = true;
            this.buttonC2.IsEnabled = true;
            this.buttonC3.IsEnabled = true;
        }

        private void buttonA1_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.A1);
        }

        private void buttonB1_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.B1);
        }

        private void buttonC1_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.C1);
        }

        private void buttonA2_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.A2);
        }

        private void buttonB2_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.B2);
        }

        private void buttonC2_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.C2);
        }

        private void buttonA3_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.A3);
        }

        private void buttonB3_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.B3);
        }

        private void buttonC3_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.MakeTurn(this.Player.PlayerSign, Field.C3);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this._proxy.Dispose();
            this.Close();
        }
    }
}
