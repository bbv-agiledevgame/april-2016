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

        public int Margin => this.GetMarginFromType(this.Type);

        public bool IsCurrentToken
        {
            get { return this.Player.IsCurrent && this.Type == TokenType.Advocate; }
        }

        public int BorderThickness
        {
            get { return this.IsCurrentToken ? 10 : 5; }
        }

        public Token(TokenType type)
        {
            this.Type = type;
        }

        public Token(TokenType type, Player player) : this(type)
        {
            this.Player = player;
        }

        private int GetMarginFromType(TokenType type)
        {
            int margin = type == TokenType.Advocate ? 3 : 10;
            return margin;
        }
    }

}
