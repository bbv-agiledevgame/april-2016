using System.Linq;
using Winkeladvokat.Models;

namespace Winkeladvokat.Services
{
    public class GameOverDetector
    {
        public bool IsGameOver(Board board, Player currentPlayer)
        {
            BoardField playerField = this.GetAdvokateTokenField(board, currentPlayer);

            if (this.CanMoveDown(board, playerField) ||
                this.CanMoveUp(board, playerField) ||
                this.CanMoveRight(board, playerField) ||
                this.CanMoveLeft(board, playerField))
            {
                return false;
            }

            return true;
        }

        private BoardField GetAdvokateTokenField(Board board, Player player)
        {
            var playerBoardField = board.Fields.SelectMany(x => x)
                .FirstOrDefault(x => x.Token != null && x.Token.Type == TokenType.Advocate && x.Token.Player == player);

            return playerBoardField;
        }

        private bool CanMoveDown(Board board, BoardField playerField)
        {
            for (int row = playerField.Position.Y + 1; row < board.Height; row++)
            {
                var column = playerField.Position.X;
                if (board.Fields[row][column].HasToken)
                {
                    break;
                }

                if (this.CanDoSecondMoveHorizontally(board, row, column))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMoveUp(Board board, BoardField playerField)
        {
            for (int row = playerField.Position.Y - 1; row >= 0; row--)
            {
                var column = playerField.Position.X;
                if (board.Fields[row][column].HasToken)
                {
                    break;
                }

                if (this.CanDoSecondMoveHorizontally(board, row, column))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMoveRight(Board board, BoardField playerField)
        {
            for (int column = playerField.Position.Y + 1; column < board.Width; column++)
            {
                var row = playerField.Position.Y;
                if (board.Fields[row][column].HasToken)
                {
                    break;
                }

                if (this.CanDoSecondMoveVertically(board, row, column))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMoveLeft(Board board, BoardField playerField)
        {
            for (int column = playerField.Position.Y - 1; column >= 0; column--)
            {
                var row = playerField.Position.Y;
                if (board.Fields[row][column].HasToken)
                {
                    break;
                }

                if (this.CanDoSecondMoveVertically(board, row, column))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanDoSecondMoveVertically(Board board, int row, int column)
        {
            if ((board.Fields.Count > row + 1 && !board.Fields[row + 1][column].HasToken) ||
                (row - 1 >= 0 && board.Fields[row - 1][column].HasToken))
            {
                return true;
            }

            return false;
        }

        private bool CanDoSecondMoveHorizontally(Board board, int row, int column)
        {
            if ((board.Fields[row].Count > column + 1 && !board.Fields[row][column + 1].HasToken) ||
                (column - 1 >= 0 && !board.Fields[row][column - 1].HasToken))
            {
                return true;
            }

            return false;
        }
    }
}