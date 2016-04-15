using System.Linq;

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

        private readonly Dictionary<int, int[]> startPositionDictionary = new Dictionary<int, int[]>()
        {
            { 2, new int[] { 0, 63 } },
            { 3, new int[] { 63, 7, 0 } },
            { 4, new int[] { 0, 56, 63, 7 } }
        };

        private readonly Color defaultColor = Colors.Transparent;

        public int[,] BoardFieldValues
        {
            get { return this.boardFieldValues; }
        }

        public Board CreateBoard(IEnumerable<Player> players)
        {
            var fields = new List<List<BoardField>>();
            this.InitializeFields(fields);
            var enumerable = players as IList<Player> ?? players.ToList();
            this.InitializeStartFields(fields, enumerable);
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
            var playerEnumerable = players as IList<Player> ?? players.ToList();
            foreach (var player in playerEnumerable)
            {
                int row = this.startPositionDictionary[playerEnumerable.Count][index] / 8;
                int column = this.startPositionDictionary[playerEnumerable.Count][index] % 8;

                BoardField startField = fields[row][column];
                startField.FieldColor = new SolidColorBrush(player.Color);
                startField.Token = new Token(TokenType.Advocate, player);

                index++;
            }
        }
    }
}