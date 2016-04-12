using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Winkeladvokat
{
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

        private readonly BoardFieldViewModel[,] boardfields;

        public BoardViewModel()
        {
            var xLenght = this.boardfieldValues.GetLength(0); 
            var yLength = this.boardfieldValues.GetLength(1);

            this.boardfields = new BoardFieldViewModel[xLenght, yLength];

            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLenght; x++)
                {
                    var value = boardfieldValues[x, y];
                    this.boardfields[x, y] = new BoardFieldViewModel(value);
                }
            }
        }

        public BoardFieldViewModel[,] BoardFields
        {
            get { return this.boardfields; }    
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
