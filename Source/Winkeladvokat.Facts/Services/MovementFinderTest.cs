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

        [Fact]
        public void GetMovement_WhenFieldIsOccupied_ThenShouldReturnParagraphMovement()
        {
            Player player = new Player(Colors.Transparent);
            BoardField selectedField1 = new BoardField(0, default(Brush), new Position(1, 1));
            selectedField1.Token = new Token(TokenType.Paragraph, player);
            BoardField selectedField2 = new BoardField(0, default(Brush), new Position(1, 2));

            Board board = new Board(new List<List<BoardField>>(new[] { new List<BoardField> { selectedField1, selectedField2 } }));
            MovementFinder testee = new MovementFinder(board);

            var result = testee.GetMovement(selectedField1, player);

            result.Should().BeOfType<ParagraphMovement>();
        }

        [Fact]
        public void GetMovement_WhenSelectingEnemyParagraphTokenField_ThenReturnNullMovement()
        {
            Player player = new Player(Colors.Transparent);
            Player enemyPlayer = new Player(Colors.Transparent);
            BoardField selectedField = new BoardField(0, default(Brush), new Position(1, 1));
            selectedField.Token = new Token(TokenType.Paragraph, enemyPlayer);

            Board board = new Board(new List<List<BoardField>>(new[] { new List<BoardField> { selectedField } }));
            MovementFinder testee = new MovementFinder(board);

            var result = testee.GetMovement(selectedField, player);

            result.Should().BeNull();
        }
    }
}