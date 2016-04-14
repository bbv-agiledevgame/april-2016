namespace Winkeladvokat.Commands
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class ActionCommandTest
    {
        [Fact]
        public void Execute_ThenInvokeAction()
        {
            const bool expectedResult = true;

            bool result = false;
            Action<bool> act = x => result = x;
            ActionCommand<bool> testee = new ActionCommand<bool>(act, null);

            testee.Execute(true);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CanExecute_WhenCanExecuteActionReturnsValue_ThenReturnValue(bool expectedCanExecute)
        {
            Func<bool, bool> canExecuteFunc = x => expectedCanExecute;
            ActionCommand<bool> testee = new ActionCommand<bool>(null, canExecuteFunc);

            var result = testee.CanExecute(true);

            result.Should().Be(expectedCanExecute);
        }

    }
}