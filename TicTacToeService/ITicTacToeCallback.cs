using System.ServiceModel;
using TicTacToeEngine.Utility;

namespace TicTacToeService
{
    public interface ITicTacToeCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnTurnEnd(TurnResult turnResult, Sign sign, Field field);
    }
}