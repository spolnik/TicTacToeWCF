using System;
using System.ServiceModel;
using System.Windows;
using CircleCrossGame.TicTacToeServiceReference;

namespace CircleCrossGame
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class TicTacToeProxy : ITicTacToeServiceCallback, IDisposable
    {
        private readonly TicTacToeServiceClient _ticTacToeService;
        private readonly MainWindow _window;

        public TicTacToeProxy(MainWindow window)
        {
            this._window = window;
            var context = new InstanceContext(this);
            this._ticTacToeService = new TicTacToeServiceClient(context);
        }

        #region Implementation of ITicTacToeServiceCallback

        public void OnTurnEnd(TurnResult turnResult, Sign sign, Field field)
        {
            if (turnResult == TurnResult.Wrong)
            {
                this.WrongTurnEval(sign);
                return;
            }

            switch (field)
            {
                case Field.A1:
                    GameHelper.MakeTurn(_window.buttonA1, sign);
                    break;
                case Field.A2:
                    GameHelper.MakeTurn(_window.buttonA2, sign);
                    break;
                case Field.A3:
                    GameHelper.MakeTurn(_window.buttonA3, sign);
                    break;
                case Field.B1:
                    GameHelper.MakeTurn(_window.buttonB1, sign);
                    break;
                case Field.B2:
                    GameHelper.MakeTurn(_window.buttonB2, sign);
                    break;
                case Field.B3:
                    GameHelper.MakeTurn(_window.buttonB3, sign);
                    break;
                case Field.C1:
                    GameHelper.MakeTurn(_window.buttonC1, sign);
                    break;
                case Field.C2:
                    GameHelper.MakeTurn(_window.buttonC2, sign);
                    break;
                case Field.C3:
                    GameHelper.MakeTurn(_window.buttonC3, sign);
                    break;
            }

            if (turnResult == TurnResult.Win)
                MessageBox.Show(string.Format("Player {0} win.", sign), "End of game");
        }

        private void WrongTurnEval(Sign sign)
        {
            if (this._window.Player.PlayerSign == sign)
                MessageBox.Show("It is wrong turn.", "Error");
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            this._ticTacToeService.Unsubscribe();
            this._ticTacToeService.Close();
        }

        #endregion

        public Player Join()
        {
            this._ticTacToeService.Subscribe();
            return this._ticTacToeService.Join();
        }

        public void MakeTurn(Sign sign, Field field)
        {
            this._ticTacToeService.MakeTurn(sign, field);
        }
    }
}