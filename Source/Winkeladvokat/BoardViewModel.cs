namespace Winkeladvokat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Media;
    using Models;

    public class BoardViewModel : PropertyChangedBase
    {
        private readonly int[,] boardfieldValues =
        {
            {0, 2, 2, 2, 2, 2, 2, 0},
            {2, 4, 4, 4, 4, 4, 4, 2},
            {2, 4, 8, 8, 8, 8, 4, 2},
            {2, 4, 8, 16, 16, 8, 4, 2},
            {2, 4, 8, 16, 16, 8, 4, 2},
            {2, 4, 8, 8, 8, 8, 4, 2},
            {2, 4, 4, 4, 4, 4, 4, 2},
            {0, 2, 2, 2, 2, 2, 2, 0}
        };

        private readonly Board board;

        private int playerTurnCounter;

        public BoardViewModel()
        {
            BoardBuilder boardBuilder = new BoardBuilder();
            this.board = boardBuilder.CreateBoard();
            this.Players = this.InitializePlayers();
            this.InitializeTokens();
            this.CurrentPlayer = this.Players[0];
            this.playerTurnCounter = 0;
            this.FieldSize = 50;
        }

        public double FieldSize { get; set; }

        public List<List<BoardField>> Fields { get { return this.board.Fields; } }

        public List<BoardField> FlatFields
        {
            get { return this.Fields.SelectMany(x => x).ToList(); }
        }

        public List<Player> Players { get; set; }

        public Player CurrentPlayer { get; set; }

        public void EndTurn()
        {
            var indexOfCurrentPlayer = this.Players.IndexOf(this.CurrentPlayer);
            this.CurrentPlayer = indexOfCurrentPlayer < 3 ? this.Players[indexOfCurrentPlayer + 1] : this.Players[0];
        }

        public void MakeTurn(Position endPosition)
        {
            this.CurrentPlayer.Position = endPosition;
            this.RemovePlayerOnPreviousBoardField(this.CurrentPlayer);
            this.MovePlayerToNewBoardField(this.CurrentPlayer);
            if (this.playerTurnCounter == 1)
            {
                this.EndTurn();
                this.playerTurnCounter = 0;
            }
            else
            {
                this.playerTurnCounter++;
            }
        }

        private BoardField BoardFieldWithPosition(Position position)
        {
            return this.Fields.SelectMany(row => row).FirstOrDefault(boardField => boardField.Position.X == position.X && boardField.Position.Y == position.Y);
        }

        private void MovePlayerToNewBoardField(Player player)
        {
            var boardField = this.BoardFieldWithPosition(player.Position);
            boardField.Player = player;
        }

        private void RemovePlayerOnPreviousBoardField(Player player)
        {
            var field = this.Fields.SelectMany(row => row).FirstOrDefault(boardField => boardField.Position.X == player.Position.X && boardField.Position.Y == player.Position.Y);
            if (field != null)
            {
                field.Player = null;
            }
        }

        private List<Player> InitializePlayers()
        {
            var playersList = Utils.PlayerStartPositions.Select(pair => new Player(pair.Value)).ToList();
            return playersList;
        }

        private void InitializeTokens()
        {
            List<Position> corners = Utils.PlayerStartPositions.Select(x => x.Value).ToList();
            for (int i = 0; i < corners.Count; i++)
            {
                BoardField field = this.FlatFields.FirstOrDefault(
                    f => f.Position.X == corners[i].X &&
                    f.Position.Y == corners[i].Y);

                if (field == null)
                {
                    throw new Exception("Field must not be null!");
                }

                var player = (PlayerColor)(i + 1);
                field.Player = new Player(corners[i], player);
            }
        }        
    }
}
