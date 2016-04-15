namespace Winkeladvokat.Models
{
    using System.Collections.Generic;
    using PropertyChanged;

    [ImplementPropertyChanged]
    public class Board
    {
        public Board(List<List<BoardField>> fields)
        {
            this.Fields = fields;
        }

        public List<List<BoardField>> Fields { get; private set; }

        public int Height
        {
            get { return this.Fields.Count; }
        }

        public int Width
        {
            get { return this.Fields.Count == 0 ? 0 : this.Fields[0].Count; }
        }
    }
}