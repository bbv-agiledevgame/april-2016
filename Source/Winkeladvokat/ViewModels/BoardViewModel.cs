namespace Winkeladvokat.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Media;
    using Commands;
    using Models;
    using Movements;
    using PropertyChanged;
    using Services;

    [ImplementPropertyChanged]
    public class BoardViewModel
    {
        private readonly Board board;
        private readonly MovementFinder movementFinder;
        private readonly Color[] playerColors = { Colors.Cyan, Colors.Magenta, Colors.Blue, Colors.Yellow };
        private readonly ScoreCalculator scoreCalculator;
        private readonly GameOverDetector gameOverDetector;
        private readonly IDialogService dialogService;

        private IMovement currentMovement;

        public BoardViewModel()
        {
            this.Players = this.InitializePlayers();
            this.CurrentPlayer = this.Players[0];
            this.scoreCalculator = new ScoreCalculator();
            this.gameOverDetector = new GameOverDetector();
            this.dialogService = new DialogService();

            BoardBuilder boardBuilder = new BoardBuilder();
            this.board = boardBuilder.CreateBoard(this.Players);
            this.movementFinder = new MovementFinder(this.board);

            this.FieldSize = 50;
        }

        public double FieldSize { get; set; }

        public List<List<BoardField>> Fields { get { return this.board.Fields; } }

        public List<Player> Players { get; set; }

        public Player CurrentPlayer { get; set; }

        public ICommand SelectField
        {
            get
            {
                return new ActionCommand<BoardField>(this.DoMovement, x => true);
            }
        }

        private void DoMovement(BoardField selectedField)
        {
            if (this.currentMovement == null)
            {
                this.currentMovement = this.movementFinder.GetMovement(selectedField, this.CurrentPlayer);
            }
            else
            {
                var movementEnded = this.currentMovement.SelectField(selectedField);

                if (movementEnded)
                {
                    this.currentMovement = null;
                    this.CurrentPlayer.IsCurrent = false;
                    this.CurrentPlayer = this.Players[(this.Players.IndexOf(this.CurrentPlayer) + 1) % this.Players.Count];
                    this.CurrentPlayer.IsCurrent = true;
                    this.GetPlayerScores();

                    if (this.gameOverDetector.IsGameOver(this.board, this.CurrentPlayer))
                    {
                        this.dialogService.ShowGameOver();
                    }
                }
            }
        }

        private void GetPlayerScores()
        {
            var scoresList = this.scoreCalculator.GetScores(this.Players, this.board);
            for (var i = 0; i < scoresList.Count; i++)
            {
                this.Players[i].Score = scoresList[i];
            }
        }

        private List<Player> InitializePlayers()
        {
            var players = Enumerable.Range(0, 4).Select(x => new Player(this.playerColors[x])).ToList();

            return players;
        }
    }
}
