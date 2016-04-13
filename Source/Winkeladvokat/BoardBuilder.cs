namespace Winkeladvokat
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

        public Color[] PlayerColors
        {
            get
            {
                return new[]
                {
                    Colors.Cyan,
                    Colors.Magenta,
                    Colors.Yellow,
                    Colors.Blue
                };
            }
        }

        public int[,] BoardFieldValues
        {
            get { return this.boardFieldValues; }
        }

        public List<List<BoardField>> CreateFields()
        {
            var fields = new List<List<BoardField>>();

            var index = 0;
            for (var row = 0; row < 8; row++)
            {
                fields.Add(new List<BoardField>());

                for (var column = 0; column < 8; column++)
                {
                    Color color = GetFieldColor(index);

                    fields[row].Add(new BoardField(
                                this.BoardFieldValues[row, column],
                                new SolidColorBrush(color),
                                new Position(row, column)));

                    index++;
                }
            }

            return fields;
        }

        private Color GetFieldColor(int index)
        {
            var specialColors = GetPlayerStartFields();
            Color defaultColor = Colors.Transparent;

            if (specialColors.ContainsKey(index))
            {
                return specialColors[index];
            }

            return defaultColor;
        }

        private Dictionary<int, Color> GetPlayerStartFields()
        {
            int columns = this.boardFieldValues.GetLength(0) - 1;
            int rows = this.boardFieldValues.GetLength(1) - 1;

            int firstPlayerPosition = this.GetFieldIndex(0, 0);
            int secondPlayerPosition = this.GetFieldIndex(0, columns);
            int thirdPlayerPosition = this.GetFieldIndex(rows, 0);
            int fourthPlayerPosition = this.GetFieldIndex(rows, columns);

            Dictionary<int, Color> specialColors = new Dictionary<int, Color>
            {
                { firstPlayerPosition, this.PlayerColors[0] },
                { secondPlayerPosition, this.PlayerColors[1] },
                { thirdPlayerPosition, this.PlayerColors[2] },
                { fourthPlayerPosition, this.PlayerColors[3] }
            };

            return specialColors;
        }

        private int GetFieldIndex(int row, int column)
        {
            return row * boardFieldValues.GetLength(0) + column;
        }
    }
}