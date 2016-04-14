using FluentAssertions;
using Winkeladvokat.Models;
using Winkeladvokat.ViewModels;
using Xbehave;

namespace Winkeladvokat
{
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
                boardViewModel.Fields[7][6].Token.Should().BeOfType<AdvocateToken>();
                boardViewModel.Fields[7][6].Token.Player.Should().Be(boardViewModel.Players[0]);
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
