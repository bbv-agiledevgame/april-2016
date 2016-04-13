using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                { 2, 4, 8,16,16, 8, 4, 2 },
                { 2, 4, 8,16,16, 8, 4, 2 },
                { 2, 4, 8, 8, 8, 8, 4, 2 },
                { 2, 4, 4, 4, 4, 4, 4, 2 },
                { 0, 2, 2, 2, 2, 2, 2, 0 }
            };

        public BoardViewModel()
        {
            this.Fields = this.CreateFields();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<List<int>> Fields { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<List<int>> CreateFields()
        {
            List<List<int>> fields = new List<List<int>>();

            for (int row = 0; row < this.boardfieldValues.GetLength(0); row++)
            {
                fields.Add(new List<int>());

                for (int column = 0; column < this.boardfieldValues.GetLength(1); column++)
                {
                    fields[row].Add(this.boardfieldValues[row, column]);
                }
            }

            return fields;
        }
    }
}
