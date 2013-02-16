using System;

namespace TicTacToeEngine.Errors
{
    public class CannotJoinToGameException : ApplicationException
    {
        public CannotJoinToGameException(string message)
            : base(message)
        {
        }
    }
}