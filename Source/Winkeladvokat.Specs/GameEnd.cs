namespace Winkeladvokat
{
    using ViewModels;
    using Xbehave;

    public class GameEnd
    {
        [Scenario]
        public void GameOver(BoardViewModel boardViewModel)
        {
            "establish board"._(() =>
            {
                boardViewModel = new BoardViewModel();
            });

            "placing tokens on field"._(() =>
            {

            });
        }
    }
}