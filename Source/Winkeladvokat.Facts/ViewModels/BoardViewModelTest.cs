﻿namespace Winkeladvokat.ViewModels
{
    using System.Windows.Media;
    using FluentAssertions;
    using Xunit;

    public class BoardViewModelTest
    {
        private readonly BoardViewModel testee;

        public BoardViewModelTest()
        {
            this.testee = new BoardViewModel();
        }

        [Fact]
        public void TesteeWhenInitializedShouldDisplayCorretStartFieldPlayerColors()
        {
            var player1Color = new SolidColorBrush(Colors.Cyan);
            var player2Color = new SolidColorBrush(Colors.Magenta);
            var player3Color = new SolidColorBrush(Colors.Yellow);
            var player4Color = new SolidColorBrush(Colors.Blue);

            this.testee.Fields[0][0].FieldColor.ShouldBeEquivalentTo(player1Color);
            this.testee.Fields[0][7].FieldColor.ShouldBeEquivalentTo(player2Color);
            this.testee.Fields[7][0].FieldColor.ShouldBeEquivalentTo(player3Color);
            this.testee.Fields[7][7].FieldColor.ShouldBeEquivalentTo(player4Color);
        }
    }
}
