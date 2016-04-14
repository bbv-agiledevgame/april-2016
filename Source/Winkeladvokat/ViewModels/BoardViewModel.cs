using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PropertyChanged;
using Winkeladvokat.Commands;
using Winkeladvokat.Models;
using Winkeladvokat.Movements;
using Winkeladvokat.Services;

namespace Winkeladvokat.ViewModels
{
    [ImplementPropertyChanged]
    public class BoardViewModel
    {
        private readonly Board board;
        private readonly MovementFinder movementFinder;
        private IMovement currentMovement;

        public BoardViewModel()
        {
            BoardBuilder boardBuilder = new BoardBuilder();
            this.board = boardBuilder.CreateBoard();
            this.movementFinder = new MovementFinder(this.board);
            this.Players = this.InitializePlayers();
            this.InitializeTokens();
            this.CurrentPlayer = this.Players[0];
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
                Action<BoardField> act = this.DoMovement;
                Func<BoardField, bool> canExecuteFunc = x => true;

                return new ActionCommand<BoardField>(act, canExecuteFunc);
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
                    this.CurrentPlayer = this.Players[(this.Players.IndexOf(this.CurrentPlayer) + 1) % 4];
                }
            }
        }

        private List<Player> InitializePlayers()
        {
            var playersList = Utils.PlayerStartPositions.Select(pair => new Player(pair.Value)).ToList();

            return playersList;
        }

        private void InitializeTokens()
        {
            List<Point> corners = Utils.PlayerStartPositions.Select(x => x.Value).ToList();
            int index = 0;
            foreach (var cornerPosition in corners)
            {
                BoardField field = this.Fields[(int)cornerPosition.Y][(int)cornerPosition.X];

                if (field == null)
                {
                    throw new Exception("Field must not be null!");
                }

                field.Token = new AdvocateToken()
                {
                    Player = this.Players[index++]
                };
            }
        }
    }
}
