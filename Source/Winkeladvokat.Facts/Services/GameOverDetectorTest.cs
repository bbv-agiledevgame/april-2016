namespace Winkeladvokat.Services
{
    using System.Collections.Generic;
    using System.Windows.Media;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class GameOverDetectorTest
    {
        private readonly GameOverDetector testee;
        private readonly Player currentPlayer;

        public GameOverDetectorTest()
        {
            this.testee = new GameOverDetector();
            this.currentPlayer = new Player(Colors.Transparent);
        }

        [Fact]
        public void IsGameOver_WhenNoMoveIsPossibleForCurrentPlayer_ThenReturnsTrue()
        {
            Board board = this.CreateEmptyBoard();
            board.Fields[4][4].Token = new Token(TokenType.Advocate, this.currentPlayer);
            board.Fields[3][4].Token = new Token(TokenType.Advocate, null);
            board.Fields[5][4].Token = new Token(TokenType.Advocate, null);
            board.Fields[4][3].Token = new Token(TokenType.Advocate, null);
            board.Fields[4][5].Token = new Token(TokenType.Advocate, null);

            var result = this.testee.IsGameOver(board, this.currentPlayer);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsGameOver_WhenCurrentPlayerCanMove_ThenReturnsFalse()
        {
            Board board = this.CreateEmptyBoard();
            board.Fields[4][4].Token = new Token(TokenType.Advocate, this.currentPlayer);
            board.Fields[3][4].Token = new Token(TokenType.Advocate, null);
            board.Fields[5][4].Token = new Token(TokenType.Advocate, null);
            board.Fields[4][3].Token = new Token(TokenType.Advocate, null);

            var result = this.testee.IsGameOver(board, this.currentPlayer);

            result.Should().BeFalse();
        }

        private Board CreateEmptyBoard()
        {
            List<List<BoardField>> fields = new List<List<BoardField>>();

            for (int row = 0; row < 8; row++)
            {
                List<BoardField> rowFields = new List<BoardField>();
                for (int column = 0; column < 8; column++)
                {
                    rowFields.Add(new BoardField(new Position(column, row)));
                }

                fields.Add(rowFields);
            }

            return new Board(fields);
        }
    }
}