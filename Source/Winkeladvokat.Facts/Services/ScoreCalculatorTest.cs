using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using FluentAssertions;
using Winkeladvokat.Models;
using Xunit;

namespace Winkeladvokat.Services
{
    public class ScoreCalculatorTest
    {
        private readonly ScoreCalculator testee;
        private Board board;
        private List<Player> players;

        public ScoreCalculatorTest()
        {
            this.testee = new ScoreCalculator();
            BoardBuilder builder = new BoardBuilder();
            this.players = Enumerable.Range(0, 4).Select(x => new Player(Colors.Red)).ToList();
            this.board = builder.CreateBoard(this.players);

            this.board.Fields[0][2].Token = new Token(TokenType.Paragraph, this.players[0]);
            this.board.Fields[2][2].Token = new Token(TokenType.Paragraph, this.players[0]);
            this.board.Fields[3][3].Token = new Token(TokenType.Paragraph, this.players[0]);

            this.board.Fields[1][1].Token = new Token(TokenType.Paragraph, this.players[1]);
            this.board.Fields[2][1].Token = new Token(TokenType.Paragraph, this.players[1]);
            this.board.Fields[3][1].Token = new Token(TokenType.Paragraph, this.players[1]);
        }

        [Fact]
        public void GetScores_ShouldReturnAllScoresCorrectly()
        {
            var scoresList = this.testee.GetScores(this.players, this.board);
            this.players[0].Score = scoresList[0];
            this.players[1].Score = scoresList[1];

            this.players[0].Score.Should().Be(26);
            this.players[1].Score.Should().Be(12);
        }
    }
}
