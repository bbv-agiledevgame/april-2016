using PropertyChanged;

namespace Winkeladvokat.Models
{
    [ImplementPropertyChanged]
    public class ParagraphToken : Token
    {
        public ParagraphToken() { }

        public ParagraphToken(Player player)
        {
            this.Player = player;
        }
    }
}
