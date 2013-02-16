using System.ServiceModel;
using TicTacToeEngine.Game;
using TicTacToeEngine.Utility;

namespace TicTacToeService
{
    [ServiceContract(CallbackContract = typeof(ITicTacToeCallback))]
    public interface ITicTacToeService
    {
        [OperationContract]
        Player Join();

        [OperationContract(IsOneWay = true)]
        void MakeTurn(Sign sign, Field field);

        [OperationContract]
        bool Subscribe();

        [OperationContract]
        bool Unsubscribe();
    }
}
