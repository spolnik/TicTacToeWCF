using System.Windows.Controls;
using System.Windows.Media;
using CircleCrossGame.TicTacToeServiceReference;

namespace CircleCrossGame
{
    public static class GameHelper
    {
        internal static void MakeTurn(Button button, Sign sign)
        {
            button.Foreground = sign == Sign.O ? Brushes.Green : Brushes.Red;
            button.Content = sign.ToString();
            button.IsEnabled = false;
        }
    }
}