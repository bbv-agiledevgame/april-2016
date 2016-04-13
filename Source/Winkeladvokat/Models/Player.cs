namespace Winkeladvokat.Models
{
    public class Player
    {
        public Player(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; set; }
    }
}
