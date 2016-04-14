using Winkeladvokat.Models;

namespace Winkeladvokat.Movements
{
    using FluentAssertions;
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
            AdvocateToken token = new AdvocateToken();
            BoardField startField = BoardField.Empty;
            startField.Token = token;

            BoardField selectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            testee.SelectField(selectedField);

            startField.Token.Should().Be(token);
            selectedField.Token.Should().BeNull();
        }

        [Fact]
        public void SelectField_WhenSecondFieldHasBeenSelected_ThenMoveTokenToSecondField()
        {
            AdvocateToken token = new AdvocateToken();
            BoardField startField = BoardField.Empty;
            startField.Token = token;

            BoardField firstSelectedField = BoardField.Empty;
            BoardField secondSelectedField = BoardField.Empty;
            AngleMovement testee = new AngleMovement(startField);

            testee.SelectField(firstSelectedField);
            testee.SelectField(secondSelectedField);

            startField.Token.Should().BeNull("start field should not have a token after angle move");
            firstSelectedField.Token.Should().BeNull();
            secondSelectedField.Token.Should().Be(token);
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