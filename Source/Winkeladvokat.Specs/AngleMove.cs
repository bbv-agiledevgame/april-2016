namespace Winkeladvokat
{
    using FluentAssertions;
    using Models;
    using ViewModels;
    using Xbehave;

    public class AngleMove
    {
        [Scenario]
        public void RegularMove(BoardViewModel boardViewModel)
        {
            "establish board"._(() =>
            {
                boardViewModel = new BoardViewModel();
            });

            "when first player moves valid angle"._(() =>
            {
                boardViewModel.SelectField.Execute(boardViewModel.Fields[0][6]);
                boardViewModel.SelectField.Execute(boardViewModel.Fields[7][6]);
            });

            "it should put current player token on new field"._(() =>
            {
                boardViewModel.Fields[7][6].Token.Type.Should().Be(TokenType.Advocate);
                boardViewModel.Fields[7][6].Token.Player.Should().Be(boardViewModel.Players[0]);
            });

            "it should place paragraph token on first clicked field"._(() =>
            {
                boardViewModel.Fields[0][6].Token.Type.Should().Be(TokenType.Paragraph);
                boardViewModel.Fields[0][6].Token.Player.Should().Be(boardViewModel.Players[0]);
            });

            "it should clear token on player's previous field"._(() =>
            {
                boardViewModel.Fields[0][0].Token.Should().BeNull();
            });

            "it should give turn to player 2"._(() =>
            {
                boardViewModel.CurrentPlayer.Should().Be(boardViewModel.Players[1]);
            });
        }
    }
}
