
namespace TicTacToeEngine.Game
{
    public static class GameFactory
    {
        public static IGame Get()
        {
            return new TicTacToeGame();
        }
    }
}