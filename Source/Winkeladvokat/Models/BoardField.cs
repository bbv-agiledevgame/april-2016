using System.Windows.Media;

namespace Winkeladvokat.Models
{
    public class BoardField
    {
        public BoardField(int value, Brush color)
        {
            this.Value = value;
            this.FieldColor = color;
        }

        public int Value { get; set; }

        public Brush FieldColor { get; set; }
    }
}
