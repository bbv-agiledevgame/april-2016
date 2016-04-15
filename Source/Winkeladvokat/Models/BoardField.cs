using System.Windows.Media;
using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public class BoardField
    {
        public BoardField(Position position)
        {
            this.Position = position;
        }

        public BoardField(int value, Brush color, Position position)
        {
            this.Value = value;
            this.FieldColor = color;
            this.Position = position;
        }

        public static BoardField Empty
        {
            get { return new BoardField(0, new SolidColorBrush(Colors.Transparent), default(Position)); }
        }

        public int Value { get; set; }

        public Brush FieldColor { get; set; }

        public Position Position { get; set; }

        public Token Token { get; set; }

        public bool HasToken
        {
            get { return this.Token != null; }
        }
    }
}
