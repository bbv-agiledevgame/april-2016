namespace Winkeladvokat.Models
{
    public class Player
    {
        public Player(Position position, PlayerColor color = PlayerColor.None)
        {
            this.Position = position;
            this.Color = color;
        }

        public Position Position { get; set; }

        public PlayerColor Color { get; set; }
    }
}
