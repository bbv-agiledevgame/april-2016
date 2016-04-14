namespace Winkeladvokat.Models2
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
