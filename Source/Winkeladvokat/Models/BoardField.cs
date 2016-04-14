using System.Windows.Media;

namespace Winkeladvokat.Models
{
    public class BoardField
    {
        public BoardField(int value, Brush color, Position position)
        {
            this.Value = value;
            this.FieldColor = color;
            this.Position = position;
        }

        public int Value { get; set; }

        public Brush FieldColor { get; set; }

        public Position Position { get; set; }

        public Player Player { get; set; }

        public Token Token { get; set; }

        public bool HasToken
        {
            get { return this.Token != null; }
        }
    }
}
