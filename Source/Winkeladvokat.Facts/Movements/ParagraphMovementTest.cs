namespace Winkeladvokat.Movements
{
    using FluentAssertions;
    using Models;
    using Xunit;

    public class ParagraphMovementTest
    {
        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameRow_ThenMoveParagraphToken()
        {
            ParagraphToken token = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = token};
            BoardField selectedField = new BoardField(new Position(3, 1));
            ParagraphMovement testee = new ParagraphMovement(startField);

            testee.SelectField(selectedField);

            startField.Token.Should().BeNull();
            selectedField.Token.Should().Be(token);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameColumn_ThenMoveParagraphToken()
        {
            ParagraphToken token = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = token};
            BoardField selectedField = new BoardField(new Position(1, 3));
            ParagraphMovement testee = new ParagraphMovement(startField);

            testee.SelectField(selectedField);

            startField.Token.Should().BeNull();
            selectedField.Token.Should().Be(token);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsInSameRowOrColumn_ThenMoveIsFinished()
        {
            ParagraphToken token = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = token};
            BoardField selectedField = new BoardField(new Position(1, 3));
            ParagraphMovement testee = new ParagraphMovement(startField);

            var result = testee.SelectField(selectedField);

            result.Should().BeTrue();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsNotInSameRowOrColumn_ThenMoveIsNotFinished()
        {
            ParagraphToken token = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = token};
            BoardField selectedField = new BoardField(new Position(3, 3));
            ParagraphMovement testee = new ParagraphMovement(startField);

            var result = testee.SelectField(selectedField);

            result.Should().BeFalse();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldIsNotInSameRowOrColumn_ThenDoNotMoveParagraphToken()
        {
            ParagraphToken token = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = token};
            BoardField selectedField = new BoardField(new Position(3, 3));
            ParagraphMovement testee = new ParagraphMovement(startField);

            testee.SelectField(selectedField);

            startField.Token.Should().Be(token);
            selectedField.Token.Should().BeNull();
        }

        [Fact]
        public void SelectField_WhenDestinationFieldHasAlreadyAToken_ThenDoNotMoveParagraphToken()
        {
            ParagraphToken playerToken = new ParagraphToken(null);
            ParagraphToken occupyToken = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) {Token = playerToken};
            BoardField selectedField = new BoardField(new Position(3, 3)) {Token = occupyToken};
            ParagraphMovement testee = new ParagraphMovement(startField);

            testee.SelectField(selectedField);

            startField.Token.Should().Be(playerToken);
            selectedField.Token.Should().Be(occupyToken);
        }

        [Fact]
        public void SelectField_WhenDestinationFieldHasAlreadyAToken_ThenMoveIsNotFinished()
        {
            ParagraphToken playerToken = new ParagraphToken(null);
            ParagraphToken occupyToken = new ParagraphToken(null);
            BoardField startField = new BoardField(new Position(1, 1)) { Token = playerToken };
            BoardField selectedField = new BoardField(new Position(3, 3)) { Token = occupyToken };
            ParagraphMovement testee = new ParagraphMovement(startField);

            var result = testee.SelectField(selectedField);

            result.Should().BeFalse();
        }
    }
}