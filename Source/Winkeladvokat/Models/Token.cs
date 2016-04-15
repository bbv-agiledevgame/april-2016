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

        public Token(TokenType type) : this()
        {
            this.Type = type;
        }

        public Token(TokenType type, Player player) : this(type)
        {
            this.Player = player;
        }
    }

}
