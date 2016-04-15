using PropertyChanged;

namespace Winkeladvokat.Models
{
    public enum TokenType
    {
        Advocate,
        Paragraph
    }

    [ImplementPropertyChanged]
    public class Token
    {
        public Player Player { get; private set; }

        public TokenType Type { get; private set; }

        protected Token()
        {
            this.Player = null;
            this.Type = TokenType.Advocate;
        }

        protected Token(Player player) : this()
        {
            this.Player = player;
        }

        public Token(Player player, TokenType type) : this(player)
        {
            this.Type = type;
        }
    }

}
