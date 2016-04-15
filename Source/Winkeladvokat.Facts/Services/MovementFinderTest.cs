namespace Winkeladvokat.Services
{
    using System.Collections.Generic;
    using System.Windows.Media;
    using FluentAssertions;
    using Models;
    using Movements;
    using Xunit;

    public class MovementFinderTest
    {
        [Fact]
        public void GetMovement_WhenFieldIsEmpty_ThenShouldReturnAngleMovement()
        {
            Player player = new Player(Colors.Transparent);
            BoardField selectedField = BoardField.Empty;
            BoardField playerField = BoardField.Empty;
            playerField.Token = new Token(TokenType.Advocate, player);
            Board board = new Board(new List<List<BoardField>>(new[] { new List<BoardField> { selectedField, playerField } }));
            MovementFinder testee = new MovementFinder(board);

            var result = testee.GetMovement(selectedField, player);

            result.Should().BeOfType<AngleMovement>();
        }
    }
}