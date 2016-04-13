using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Winkeladvokat.Models;

namespace Winkeladvokat
{
    using System.Collections.Generic;

    public class BoardViewModel : INotifyPropertyChanged
    {
        private readonly int[,] boardfieldValues =
        {
            { 0, 2, 2, 2, 2, 2, 2, 0 },
            { 2, 4, 4, 4, 4, 4, 4, 2 },
            { 2, 4, 8, 8, 8, 8, 4, 2 },
            { 2, 4, 8, 16, 16, 8, 4, 2 },
            { 2, 4, 8, 16, 16, 8, 4, 2 },
            { 2, 4, 8, 8, 8, 8, 4, 2 },
            { 2, 4, 4, 4, 4, 4, 4, 2 },
            { 0, 2, 2, 2, 2, 2, 2, 0 }
        };

        public BoardViewModel()
        {
            this.Fields = this.CreateFields();
            this.Players = this.InitializePlayers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<List<BoardField>> Fields { get; set; }

        public List<Player> Players { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Player> InitializePlayers()
        {
            var playersList = Utils.PlayerStartPositionsDictionary.Select(pair => new Player(pair.Value)).ToList();
            return playersList;
        }

        private List<List<BoardField>> CreateFields()
        {
            var fields = new List<List<BoardField>>();

            var index = 0;
            for (var row = 0; row < 8; row++)
            {
                fields.Add(new List<BoardField>());

                for (var column = 0; column < 8; column++)
                {
                    switch (index)
                    {
                        case 0:
                            var boardField = new BoardField(
                                this.boardfieldValues[row, column],
                                new SolidColorBrush(Colors.Cyan),
                                new Position(row, column));
                            fields[row].Add(boardField);
                            break;
                        case 7:
                            fields[row].Add(new BoardField(
                                this.boardfieldValues[row, column],
                                new SolidColorBrush(Colors.Magenta),
                                new Position(row, column)));
                            break;
                        case 56:
                            fields[row].Add(new BoardField(
                                this.boardfieldValues[row, column],
                                new SolidColorBrush(Colors.Yellow),
                                new Position(row, column)));
                            break;
                        case 63:
                            fields[row].Add(new BoardField(
                                this.boardfieldValues[row, column],
                                new SolidColorBrush(Colors.Blue),
                                new Position(row, column)));
                            break;
                        default:
                            fields[row].Add(new BoardField(
                                this.boardfieldValues[row, column],
                                new SolidColorBrush(Colors.Transparent),
                                new Position(row, column)));
                            break;
                    }

                    index++;
                }
            }

            return fields;
        }
    }
}
