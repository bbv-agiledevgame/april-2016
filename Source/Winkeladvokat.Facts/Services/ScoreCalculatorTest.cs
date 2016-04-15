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
        }

        [Fact]
        public void GetPlayerScore_WhenFirstPlayerPassed_ShouldReturnScoreOfFirstPlayer()
        {
            this.board.Fields[0][2].Token = new ParagraphToken(this.players[0]);
            this.board.Fields[2][2].Token = new ParagraphToken(this.players[0]);
            this.board.Fields[3][3].Token = new ParagraphToken(this.players[0]);

            this.players[0].Score = this.testee.GetPlayerScore(this.players[0], this.board);

            this.players[0].Score.Should().Be(26);
        }
    }
}
