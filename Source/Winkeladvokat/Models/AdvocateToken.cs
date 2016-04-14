using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public class AdvocateToken : Token
    {
        public AdvocateToken()
        {
        }

        public AdvocateToken(Player player)
        {
            this.Player = player;
        }
    }
}
