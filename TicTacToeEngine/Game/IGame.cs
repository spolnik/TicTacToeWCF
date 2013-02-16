using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Game
{
    public interface IGame
    {
        Player CurrentPlayer { get; }

        TurnResult MakeTurn(Sign sign, Field a2);

        Player CreatePlayer();
    }
}