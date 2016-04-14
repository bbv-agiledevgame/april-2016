using System.Windows;
using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public class Player
    {
        public Player(Point position)
        {
            this.Position = position;
        }

        public Point Position { get; set; }
    }
}
