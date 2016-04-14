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
    }
}