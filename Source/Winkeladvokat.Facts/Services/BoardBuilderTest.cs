namespace Winkeladvokat.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class BoardBuilderTest
    {
        [Fact]
        public void CreateFields_ThenReturnsFieldsWithValues()
        {
            BoardBuilder testee = new BoardBuilder();
            var expectedValues = testee.BoardFieldValues;

            var board = testee.CreateBoard();
            var result = this.To2DArray(board.Fields);

            result.Should().BeEquivalentTo(expectedValues);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 7)]
        [InlineData(2, 7, 0)]
        [InlineData(3, 7, 7)]
        public void CreateFields_ColorizePlayerFields(int playerIndex, int row, int column)
        {
            BoardBuilder testee = new BoardBuilder();
            Color expectedColor = testee.PlayerColors[playerIndex];

            var board = testee.CreateBoard();
            var result = board.Fields[row][column].FieldColor.ToString();

            result.Should().Be(expectedColor.ToString());
        }

        public int[,] To2DArray(List<List<BoardField>> source)
        {
            int max = source.Select(l => l).Max(l => l.Count);
            var result = new int[source.Count, max];

            foreach (var field in source.SelectMany(field => field))
            {
                result[field.Position.X, field.Position.Y] = field.Value;
            }

            return result;
        }
    }
}