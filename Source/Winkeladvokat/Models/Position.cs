namespace Winkeladvokat.Models
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int xPos, int yPos)
        {
            this.X = xPos;
            this.Y = yPos;
        }
    }
}