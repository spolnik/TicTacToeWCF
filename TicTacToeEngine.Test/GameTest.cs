using NUnit.Framework;
using TicTacToeEngine.Errors;
using TicTacToeEngine.Game;
using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Test
{
    [TestFixture]
    public class GameTest
    {
        private IGame _game;

        private Player _playerOne;
        private Player _playerTwo;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Get();
            this._playerOne = this._game.CreatePlayer();
            this._playerTwo = this._game.CreatePlayer();
        }

        [Test]
        public void PlayersSignsAfterJoin()
        {
            Assert.AreEqual(Sign.O, this._playerOne.PlayerSign);
            Assert.AreEqual(Sign.X, this._playerTwo.PlayerSign);
        }

        [Test]
        public void JoinThirdPlayer()
        {
            Assert.Catch(typeof(CannotJoinToGameException), () => this._game.CreatePlayer());
        }

        [Test]
        public void ActualPlayerOnStart()
        {
            Assert.AreEqual(this._playerOne, this._game.CurrentPlayer);
        }

        [Test]
        public void CurrentPlayerMakeTurn()
        {
            Assert.AreEqual(TurnResult.Next, this.FirstTurn());
            Assert.AreEqual(this._playerTwo, this._game.CurrentPlayer);
        }

        [Test]
        public void CurrentPlayerIsNotPlayerWhoMakeTurn()
        {
            Assert.AreEqual(TurnResult.Next, this.FirstTurn());
            Assert.Catch(typeof(ItIsNotYourTurnException), () => this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2));
        }

        [Test]
        public void FirstTurnIsOkayAndSecondIsNot()
        {
            this.FirstTurn();
            Assert.AreEqual(this._playerTwo, this._game.CurrentPlayer);
            Assert.AreEqual(TurnResult.Wrong, this._game.MakeTurn(this._playerTwo.PlayerSign, Field.A2));
            Assert.AreEqual(this._playerTwo, this._game.CurrentPlayer);
        }


        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // x x -
        // o o o
        // - - - 
        [Test]
        public void GameFirstCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.A1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerOne.PlayerSign, Field.C2));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // x x x
        // o o -
        // - o - 
        [Test]
        public void GameSecondCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.A1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B3);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerTwo.PlayerSign, Field.C1));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // - o -
        // o o -
        // x x x 
        [Test]
        public void GameThirdCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.A3);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B3);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B1);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerTwo.PlayerSign, Field.C3));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // o x x
        // - o -
        // - - o 
        [Test]
        public void GameFourthCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A1);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.B2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.C1);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerOne.PlayerSign, Field.C3));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // o - x
        // o x -
        // x - o 
        [Test]
        public void GameFiveCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A1);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.A3);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B2);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.C3);
            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerTwo.PlayerSign, Field.C1));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // o x -
        // o x -
        // o - - 
        [Test]
        public void GameSixthCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A1);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B2);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerOne.PlayerSign, Field.A3));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // o x -
        // o x -
        // - x o 
        [Test]
        public void GameSeventhCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A1);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B2);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.C3);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B3));
        }

        // A1 B1 C1
        // A2 B2 C2
        // A3 B3 C3
        // 
        // - x o
        // - x o
        // - - o 
        [Test]
        public void GameEighthCase()
        {
            this._game.MakeTurn(this._playerOne.PlayerSign, Field.C1);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B1);

            this._game.MakeTurn(this._playerOne.PlayerSign, Field.C2);
            this._game.MakeTurn(this._playerTwo.PlayerSign, Field.B2);

            Assert.AreEqual(TurnResult.Win, this._game.MakeTurn(this._playerOne.PlayerSign, Field.C3));
        }

        private TurnResult FirstTurn()
        {
            return this._game.MakeTurn(this._playerOne.PlayerSign, Field.A2);
        }
    }
}