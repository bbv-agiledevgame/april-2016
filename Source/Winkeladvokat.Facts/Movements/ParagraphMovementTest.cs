namespace Winkeladvokat.Movements
{
    using System.Collections.Generic;
    using System.Windows.Media;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class ParagraphMovementTest
    {
        private readonly Board board;
        private readonly BoardField startField;
        private readonly ParagraphMovement testee;
        private readonly Token playerToken;
        private readonly Player player;

        public ParagraphMovementTest()
        {
            this.board = this.CreateBoard();
            this.player = new Player(Colors.Transparent);
            this.playerToken = new Token(TokenType.Paragraph, this.player);
            this.startField = this.board.Fields[1][1];
            this.startField.Token = this.playerToken;
            this.testee = new ParagraphMovement(this.board, this.startField);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameRow_ThenMoveParagraphToken()
        {
            BoardField selectedField = this.board.Fields[3][1];

            this.testee.SelectField(selectedField);

            this.startField.Token.Should().BeNull();
            selectedField.Token.Should().Be(this.playerToken);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameColumn_ThenMoveParagraphToken()
        {
            BoardField selectedField = this.board.Fields[1][3];

            this.testee.SelectField(selectedField);

            this.startField.Token.Should().BeNull();
            selectedField.Token.Should().Be(this.playerToken);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameRowOrColumn_ThenMoveIsFinished()
        {
            BoardField selectedField = this.board.Fields[1][3];

            var result = this.testee.SelectField(selectedField);

            result.Should().BeTrue();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsNotInSameRowOrColumn_ThenMoveIsNotFinished()
        {
            BoardField selectedField = this.board.Fields[3][3];

            var result = this.testee.SelectField(selectedField);

            result.Should().BeFalse();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsNotInSameRowOrColumn_ThenDoNotMoveParagraphToken()
        {
            BoardField selectedField = this.board.Fields[3][3];

            this.testee.SelectField(selectedField);

            this.startField.Token.Should().Be(this.playerToken);
            selectedField.Token.Should().BeNull();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldHasAlreadyAToken_ThenDoNotMoveParagraphToken()
        {
            Token occupyToken = new Token(TokenType.Paragraph);
            BoardField selectedField = this.board.Fields[1][3];
            selectedField.Token = occupyToken;

            this.testee.SelectField(selectedField);

            this.startField.Token.Should().Be(this.playerToken);
            selectedField.Token.Should().Be(occupyToken);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldHasAlreadyAToken_ThenMoveIsNotFinished()
        {
            Token occupyToken = new Token(TokenType.Paragraph);
            BoardField selectedField = this.board.Fields[1][3];
            selectedField.Token = occupyToken;


            var result = this.testee.SelectField(selectedField);

            result.Should().BeFalse();
        }

        [Fact]
        public void SelectField_WhenEnemyParagraphTokenIsBetweenStartAndDestinationField_ThenRemoveEnemyParagraphToken()
        {
            Player enemyPlayer = new Player(Colors.Transparent);
            Token enemyToken = new Token(TokenType.Paragraph, enemyPlayer);
            BoardField enemyField = this.board.Fields[1][2];
            enemyField.Token = enemyToken;
            BoardField selectedField = new BoardField(new Position(1, 3));

            this.testee.SelectField(selectedField);

            enemyField.Token.Should().BeNull();
        }

        private Board CreateBoard()
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