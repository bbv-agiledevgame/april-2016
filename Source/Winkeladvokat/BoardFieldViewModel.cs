using System.ComponentModel;

namespace Winkeladvokat
{
    public class BoardFieldViewModel : INotifyPropertyChanged
    {
        public BoardFieldViewModel(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}