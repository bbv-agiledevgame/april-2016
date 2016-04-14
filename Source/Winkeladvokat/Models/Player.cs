using System.Windows;
using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public class Player
    {
        public Player(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}
