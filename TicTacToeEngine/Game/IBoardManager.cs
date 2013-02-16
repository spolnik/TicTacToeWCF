using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Game
{
    internal interface IBoardManager
    {
        TurnResult MakeTurn(Sign sign, Field field);
    }
}