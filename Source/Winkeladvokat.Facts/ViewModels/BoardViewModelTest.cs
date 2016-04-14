using System.Linq;

namespace Winkeladvokat.ViewModels
{
    using System.Windows.Media;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class BoardViewModelTest
    {
        private readonly BoardViewModel testee;

        public BoardViewModelTest()
        {
            this.testee = new BoardViewModel();
        }

        [Fact]
        public void TesteeWhenInitializedShouldDisplayCorretStartFieldPlayerColors()
        {
            var player1Color = new SolidColorBrush(Colors.Cyan);
            var player2Color = new SolidColorBrush(Colors.Magenta);
            var player3Color = new SolidColorBrush(Colors.Yellow);
            var player4Color = new SolidColorBrush(Colors.Blue);

            this.testee.Fields[0][0].FieldColor.ShouldBeEquivalentTo(player1Color);
            this.testee.Fields[0][7].FieldColor.ShouldBeEquivalentTo(player2Color);
            this.testee.Fields[7][0].FieldColor.ShouldBeEquivalentTo(player3Color);
            this.testee.Fields[7][7].FieldColor.ShouldBeEquivalentTo(player4Color);
        }

        [Fact]
        public void TesteeWhenInitializedThenPlayersShouldHaveCorrectStartPosition()
        {
            var positionPlayer1 = new Position(0, 0);
            var positionPlayer2 = new Position(0, 7);
            var positionPlayer3 = new Position(7, 0);
            var positionPlayer4 = new Position(7, 7);

            this.testee.Players[0].Position.X.Should().Be(positionPlayer1.X);
            this.testee.Players[0].Position.Y.Should().Be(positionPlayer1.Y);

            this.testee.Players[1].Position.X.Should().Be(positionPlayer2.X);
            this.testee.Players[1].Position.Y.Should().Be(positionPlayer2.Y);

            this.testee.Players[2].Position.X.Should().Be(positionPlayer3.X);
            this.testee.Players[2].Position.Y.Should().Be(positionPlayer3.Y);

            this.testee.Players[3].Position.X.Should().Be(positionPlayer4.X);
            this.testee.Players[3].Position.Y.Should().Be(positionPlayer4.Y);
        }

        [Fact]
        public void EndTurnShouldGiveTurnToNextPlayer()
        {
            const int indexOfNextPlayer = 1;

            this.testee.EndTurn();

            this.testee.Players.IndexOf(this.testee.CurrentPlayer).Should().Be(indexOfNextPlayer);
        }

        [Fact]
        public void EndTurnWhenLastPlayerEndedTurnShouldGiveTurnToFirstPlayerAgain()
        {
            this.testee.CurrentPlayer = this.testee.Players[3];
            const int indexOfCurrentPlayer = 0;

            this.testee.EndTurn();

            this.testee.Players.IndexOf(this.testee.CurrentPlayer).Should().Be(indexOfCurrentPlayer);
        }

        [Fact]
        public void MakeTurnShouldMovePlayerToNewPosition()
        {
            var newPosition = new Position(2, 4);
            var newPositionTwo = new Position(5, 6);
            const int indexOfPlayerMakingTurn = 0;
            const int indexOfNextPlayer = 1;

            this.testee.MakeTurn(newPosition);
            this.testee.MakeTurn(newPositionTwo);

            this.testee.Players[indexOfPlayerMakingTurn].Position.X.Should().Be(newPositionTwo.X);
            this.testee.Players[indexOfPlayerMakingTurn].Position.Y.Should().Be(newPositionTwo.Y);
            this.testee.Players.IndexOf(this.testee.CurrentPlayer).Should().Be(indexOfNextPlayer);
            this.testee.Fields[5][6].Player.ShouldBeEquivalentTo(this.testee.Players[indexOfPlayerMakingTurn]);
        }

        [Fact]
        public void TesteeWhenInitializedThenBoardShouldHaveCorrectNumberOfFlatFields()
        {
            this.testee.FlatFields.Count.Should().Be(64);
        }

        [Fact]
        public void TesteeWhenInitializedThenBoardShouldHavePlayerInEachCorner()
        {
            this.testee.FlatFields.Count(x => x.HasToken).Should().Be(4);
        }

        [Fact]
        public void TesteeWhenInitializedThenBoardShouldHaveNoPlayerOtherFieldsThanCorner()
        {
            this.testee.FlatFields.Count(x => !x.HasToken).Should().Be(60);
        }
    }
}
