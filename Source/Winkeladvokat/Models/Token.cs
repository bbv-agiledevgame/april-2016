using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public abstract class Token
    {
        public Player Player { get; set; }
    }
}
