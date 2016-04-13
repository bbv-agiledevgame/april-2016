using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Winkeladvokat.Models;
using Winkeladvokat.Properties;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<List<BoardField>> Fields { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                            fields[row].Add(new BoardField(this.boardfieldValues[row, column], new SolidColorBrush(Colors.Red)));
                            break;
                        case 7:
                            fields[row].Add(new BoardField(this.boardfieldValues[row, column], new SolidColorBrush(Colors.Blue)));
                            break;
                        case 56:
                            fields[row].Add(new BoardField(this.boardfieldValues[row, column], new SolidColorBrush(Colors.Green)));
                            break;
                        case 63:
                            fields[row].Add(new BoardField(this.boardfieldValues[row, column], new SolidColorBrush(Colors.Yellow)));
                            break;
                        default:
                            fields[row].Add(new BoardField(this.boardfieldValues[row, column], new SolidColorBrush(Colors.Transparent)));
                            break;
                    }

                    index++;
                }
            }

            return fields;
        }
    }
}
