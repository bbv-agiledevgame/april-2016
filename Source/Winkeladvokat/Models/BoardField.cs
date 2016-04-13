using System.Windows.Media;

namespace Winkeladvokat.Models
{
    public class BoardField
    {
        public BoardField(int value, Color color)
        {
            this.Value = value;
            this.FieldColor = color;
        }

        public int Value { get; set; }

        public Color FieldColor { get; set; }
    }
}
