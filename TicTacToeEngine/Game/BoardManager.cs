using System.Collections.Generic;
using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Game
{
    class BoardManager : IBoardManager
    {
        private readonly Dictionary<Field, Sign> _board;

        public BoardManager()
        {
            this._board = new Dictionary<Field, Sign>(9);
            this.InitFieldsOnStart();
        }

        private void InitFieldsOnStart()
        {
            this._board.Add(Field.A1, Sign.None);
            this._board.Add(Field.A2, Sign.None);
            this._board.Add(Field.A3, Sign.None);

            this._board.Add(Field.B1, Sign.None);
            this._board.Add(Field.B2, Sign.None);
            this._board.Add(Field.B3, Sign.None);

            this._board.Add(Field.C1, Sign.None);
            this._board.Add(Field.C2, Sign.None);
            this._board.Add(Field.C3, Sign.None);
        }

        #region Implementation of IBoardManager

        TurnResult IBoardManager.MakeTurn(Sign sign, Field field)
        {
            if (this._board[field] != Sign.None)
                return TurnResult.Wrong;

            this._board[field] = sign;

            return this.CheckIfWin() ? TurnResult.Win : TurnResult.Next;
        }

        private bool CheckIfWin()
        {
            return this.CheckIfRowWin() || this.CheckIfColumnWin() || this.CheckIfCrossWin();
        }

        private bool CheckIfCrossWin()
        {
            if (this._board[Field.A1] != Sign.None
                && (this._board[Field.A1] == this._board[Field.B2])
                && (this._board[Field.B2] == this._board[Field.C3]))
            {
                return true;
            }

            return this._board[Field.C1] != Sign.None
                   && (this._board[Field.C1] == this._board[Field.B2])
                   && (this._board[Field.B2] == this._board[Field.A3]);
        }

        private bool CheckIfColumnWin()
        {
            if (this._board[Field.A1] != Sign.None
                && (this._board[Field.A1] == this._board[Field.A2])
                && (this._board[Field.A2] == this._board[Field.A3]))
            {
                return true;
            }

            if (this._board[Field.B1] != Sign.None
                && (this._board[Field.B1] == this._board[Field.B2])
                && (this._board[Field.B2] == this._board[Field.B3]))
            {
                return true;
            }

            return this._board[Field.C1] != Sign.None
                   && (this._board[Field.C1] == this._board[Field.C2])
                   && (this._board[Field.C2] == this._board[Field.C3]);
        }

        private bool CheckIfRowWin()
        {
            if (this._board[Field.A1] != Sign.None
                && (this._board[Field.A1] == this._board[Field.B1])
                && (this._board[Field.B1] == this._board[Field.C1]))
            {
                return true;
            }

            if (this._board[Field.A2] != Sign.None
                && (this._board[Field.A2] == this._board[Field.B2])
                && (this._board[Field.B2] == this._board[Field.C2]))
            {
                return true;
            }

            return this._board[Field.A3] != Sign.None
                   && (this._board[Field.A3] == this._board[Field.B3])
                   && (this._board[Field.B3] == this._board[Field.C3]);
        }

        #endregion
    }
}