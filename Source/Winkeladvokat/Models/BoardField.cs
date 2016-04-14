using System.Windows.Media;

namespace Winkeladvokat.Models
{
    public class BoardField : PropertyChangedBase
    {
        private Player player;

        public BoardField(int value, Brush color, Position position)
        {
            this.Value = value;
            this.FieldColor = color;
            this.Position = position;
            this.Player = null;
        }

        public int Value { get; set; }

        public Brush FieldColor { get; set; }

        public Position Position { get; set; }

        public Player Player
        {
            get
            {
                return this.player;
            }

            set
            {
                if (this.player != value)
                {
                    this.player = value;
                    this.OnPropertyChanged(this.Player);
                    this.OnPropertyChanged(this.Token);
                }
            }
        }

        public Player Token
        {
            get { return this.Player; }
        }

        public bool HasToken
        {
            get { return this.Token != null; }
        }
    }
}
