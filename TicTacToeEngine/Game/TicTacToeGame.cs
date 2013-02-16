using System;
using System.Collections.Generic;
using TicTacToeEngine.Errors;
using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Game
{
    internal class TicTacToeGame : IGame
    {
        public static readonly int MaximumNumberOfPlayers = 2;
        private readonly IBoardManager _boardManager;
        private readonly List<Player> _players;

        private Player _currentPlayer;

        internal TicTacToeGame()
        {
            this._players = new List<Player>(MaximumNumberOfPlayers);
            this._boardManager = new BoardManager();
        }

        #region IGame Members

        Player IGame.CurrentPlayer
        {
            get { return this._currentPlayer; }
        }

        TurnResult IGame.MakeTurn(Sign sign, Field field)
        {
            if (!sign.Equals(this._currentPlayer.PlayerSign))
                throw new ItIsNotYourTurnException();

            var result = this._boardManager.MakeTurn(sign, field);

            if (result == TurnResult.Wrong || result == TurnResult.Win)
                return result;

            this._currentPlayer = this.GetCurrentPlayerOpponent();

            return result;
        }

        Player IGame.CreatePlayer()
        {
            lock (this._players)
            {
                if (this._players.Count == MaximumNumberOfPlayers)
                    throw new CannotJoinToGameException("Game has maximum number of players.");

                var playerContext = Guid.NewGuid().ToString();

                var player = new Player(playerContext, this._players.Count == 0 ? Sign.O : Sign.X);

                this.SetCurrentPlayerOnStart(player);

                this._players.Add(player);

                return player;
            }
        }

        #endregion

        private Player GetCurrentPlayerOpponent()
        {
            return this._currentPlayer.PlayerSign == Sign.O ? this._players[1] : this._players[0];
        }

        private void SetCurrentPlayerOnStart(Player player)
        {
            if (this._players.Count == 0)
                this._currentPlayer = player;
        }
    }
}
