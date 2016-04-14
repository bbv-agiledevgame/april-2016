using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using PropertyChanged;
using Winkeladvokat.Models;
using Winkeladvokat.Services;

namespace Winkeladvokat.ViewModels
{
    [ImplementPropertyChanged]
    public class BoardViewModel
    {
        private readonly Board board;
        private MovementFinder movementFinder;

        public BoardViewModel()
        {
            BoardBuilder boardBuilder = new BoardBuilder();
            this.movementFinder = new MovementFinder();
            this.board = boardBuilder.CreateBoard();
            this.Players = this.InitializePlayers();
            this.InitializeTokens();
            this.CurrentPlayer = this.Players[0];
            this.FieldSize = 50;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double FieldSize { get; set; }

        public List<List<BoardField>> Fields { get { return this.board.Fields; } }

        public List<Player> Players { get; set; }

        public Player CurrentPlayer { get; set; }

        public ICommand SelectField { get { return null; } }

        private List<Player> InitializePlayers()
        {
            var playersList = Utils.PlayerStartPositions.Select(pair => new Player(pair.Value)).ToList();
            return playersList;
        }

        private void InitializeTokens()
        {
            List<Point> corners = Utils.PlayerStartPositions.Select(x => x.Value).ToList();
            foreach (var cornerPosition in corners)
            {
                BoardField field = this.Fields[(int) cornerPosition.Y][(int) cornerPosition.X];

                if (field == null)
                {
                    throw new Exception("Field must not be null!");
                }

                field.Token = new AdvocateToken();
            }
        }
    }
}
