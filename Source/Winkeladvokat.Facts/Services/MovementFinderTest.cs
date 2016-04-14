using System.Collections.Generic;
using System.Windows;

namespace Winkeladvokat.Services
{
    using FluentAssertions;
    using Models;
    using Movements;
    using Xunit;

    public class MovementFinderTest
    {
        [Fact]
        public void GetMovement_WhenFieldIsEmpty_ThenShouldReturnAngleMovement()
        {
            Player player = new Player(new Point(0, 0));
            BoardField selectedField = BoardField.Empty;
            BoardField playerField = BoardField.Empty;
            playerField.Token = new AdvocateToken(player);
            Board board = new Board(new List<List<BoardField>>(new[] { new List<BoardField> { selectedField, playerField } }));
            MovementFinder testee = new MovementFinder(board);

            var result = testee.GetMovement(selectedField, player);

            result.Should().BeOfType<AngleMovement>();
        }
    }
}