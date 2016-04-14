namespace Winkeladvokat.Movements
{
    using FluentAssertions;
    using Models;
    using Xunit;

    public class AngleMovementTest
    {
        [Fact]
        public void SelectField_WhenFirstFieldHasBeenSelected_ThenMovementIsNotFinished()
        {
            BoardField startField = BoardField.Empty;
            BoardField selectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            var result = testee.SelectField(selectedField);

            result.Should().BeFalse();
        }

        [Fact]
        public void SelectField_WhenFirstFieldHasBeenSelected_ThenDoNotMoveToken()
        {
            Player token = new Player(new Position(0, 0));
            BoardField startField = BoardField.Empty;
            startField.Player = token;

            BoardField selectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            testee.SelectField(selectedField);

            startField.Player.Should().Be(token);
            selectedField.Player.Should().BeNull();
        }

        [Fact]
        public void SelectField_WhenSecondFieldHasBeenSelected_ThenMoveTokenToSecondField()
        {
            Player token = new Player(new Position(0, 0));
            BoardField startField = BoardField.Empty;
            startField.Player = token;

            BoardField firstSelectedField = BoardField.Empty;
            BoardField secondSelectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            testee.SelectField(firstSelectedField);
            testee.SelectField(secondSelectedField);

            startField.Player.Should().BeNull("start field should not have a token after angle move");
            firstSelectedField.Player.Should().BeNull();
            secondSelectedField.Player.Should().Be(token);
        }

        [Fact]
        public void SelectField_WhenSecondFieldHasBeenSelected_ThenMovementIsFinished()
        {
            BoardField startField = BoardField.Empty;
            BoardField firstSelectedField = BoardField.Empty;
            BoardField secondSelectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            testee.SelectField(firstSelectedField);
            var result = testee.SelectField(secondSelectedField);

            result.Should().BeTrue();
        }
    }
}