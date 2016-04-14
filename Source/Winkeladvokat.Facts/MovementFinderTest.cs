namespace Winkeladvokat
{
    using FluentAssertions;
    using Models;
    using Movements;
    using Services;
    using Xunit;

    public class MovementFinderTest
    {
        [Fact]
        public void GetMovement_WhenFieldIsEmpty_ThenShouldReturnAngleMovement()
        {
            BoardField selectedField = BoardField.Empty;
            MovementFinder testee = new MovementFinder();

            var result = testee.GetMovement(selectedField);

            result.Should().BeOfType<AngleMovement>();
        }
    }
}