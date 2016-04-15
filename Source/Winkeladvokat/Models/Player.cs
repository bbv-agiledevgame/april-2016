namespace Winkeladvokat.Models
{
    using System.Windows.Media;
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class Player
    {
        public Player(Color color)
        {
            this.Color = color;
        }
        
        public Color Color { get; set; }
    }
}
