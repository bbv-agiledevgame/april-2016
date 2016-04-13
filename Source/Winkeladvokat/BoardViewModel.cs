using System.ComponentModel;
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

            for (var row = 0; row < 8; row++)
            {
                fields.Add(new List<BoardField>());

                for (var column = 0; column < 8; column++)
                {
                    fields[row].Add(new BoardField(this.boardfieldValues[row, column], Colors.Transparent));
                }
            }

            return fields;
        }
    }
}
