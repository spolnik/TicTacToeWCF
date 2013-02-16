
using System.Collections.Generic;
using System.ServiceModel;
using TicTacToeEngine.Errors;
using TicTacToeEngine.Game;
using TicTacToeEngine.Utility;

namespace TicTacToeService
{
    public class TicTacToeService : ITicTacToeService
    {
        private static readonly IGame _game;
        private static readonly List<ITicTacToeCallback> _subscribers;

        static TicTacToeService()
        {
            _game = GameFactory.Get();
            _subscribers = new List<ITicTacToeCallback>(2);
        }

        #region Implementation of ITicTacToeService

        public Player Join()
        {
            try
            {
                return _game.CreatePlayer();
            }
            catch (PlayerNameExistsException)
            {
                return null;
            }
            catch (CannotJoinToGameException)
            {
                return null;
            }
        }

        public void MakeTurn(Sign sign, Field field)
        {
            var turnResult = _game.MakeTurn(sign, field);

            _subscribers.ForEach(callback =>
                                 {
                                     if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                                     {
                                         callback.OnTurnEnd(turnResult, sign, field);
                                         if (turnResult == TurnResult.Win)
                                             _subscribers.Remove(callback);
                                     }
                                     else
                                     {
                                         _subscribers.Remove(callback);
                                     }
                                 });
        }

        public bool Subscribe()
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<ITicTacToeCallback>();
                if (!_subscribers.Contains(callback))
                    _subscribers.Add(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Unsubscribe()
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<ITicTacToeCallback>();
                if (!_subscribers.Contains(callback))
                    _subscribers.Remove(callback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
