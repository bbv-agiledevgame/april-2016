namespace Winkeladvokat.Services
{
    using System.Collections.Generic;
    using System.Windows.Media;
    using Models;

    public class BoardBuilder
    {
        private readonly int[,] boardFieldValues =
        {
            { 0, 2, 2, 2, 2, 2, 2, 0 },
            { 2, 4, 4, 4, 4, 4, 4, 2 },
            { 2, 4, 8, 8, 8, 8, 4, 2 },
            { 2, 4, 8, 16, 16, 8, 4, 2 },
            { 2, 4, 8, 16, 16, 8, 4, 2 },
            { 2, 4, 8, 8, 8, 8, 4, 2 },
            { 2, 4, 4, 4, 4, 4, 4, 2 },
            { 0, 2, 2, 2, 2, 2, 2, 0 }
        };

        private readonly int[] startPositions = { 0, 56, 63, 7 };

        private readonly Color defaultColor = Colors.Transparent;

        public int[,] BoardFieldValues
        {
            get { return this.boardFieldValues; }
        }

        public Board CreateBoard(IEnumerable<Player> players)
        {
            var fields = new List<List<BoardField>>();
            this.InitializeFields(fields);
            this.InitializeStartFields(fields, players);
            var board = new Board(fields);

            return board;
        }

        private void InitializeFields(List<List<BoardField>> fields)
        {
            for (var row = 0; row < 8; row++)
            {
                fields.Add(new List<BoardField>());

                for (var column = 0; column < 8; column++)
                {
                    fields[row].Add(new BoardField(
                        this.BoardFieldValues[row, column],
                        new SolidColorBrush(this.defaultColor),
                        new Position(row, column)));
                }
            }
        }

        private void InitializeStartFields(List<List<BoardField>> fields, IEnumerable<Player> players)
        {
            int index = 0;
            foreach (var player in players)
            {
                int row = this.startPositions[index] / 8;
                int column = this.startPositions[index] % 8;

                BoardField startField = fields[row][column];
                startField.FieldColor = new SolidColorBrush(player.Color);
                startField.Token = new Token(TokenType.Advocate, player);

                index++;
            }
        }
    }
}