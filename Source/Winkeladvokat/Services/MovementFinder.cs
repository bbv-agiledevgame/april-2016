using System.Linq;
using Winkeladvokat.Models;

namespace Winkeladvokat.Services
{
    using Movements;

    public class MovementFinder
    {
        private Board board;

        public MovementFinder(Board board)
        {
            this.board = board;
        }

        public IMovement GetMovement(BoardField selectedField, Player currentPlayer)
        {
            if (this.IsAngleMovement(selectedField))
            {
                var advokateTokenField = this.GetAdvokateTokenField(currentPlayer);
                AngleMovement angleMovement = new AngleMovement(advokateTokenField);

                angleMovement.SelectField(selectedField);

                return angleMovement;
            }
            else if(this.IsParagraphMovement(selectedField))
            {
                ParagraphMovement paragraphMovement = new ParagraphMovement(selectedField);

                return paragraphMovement;
            }

            return null;
        }

        private bool IsAngleMovement(BoardField selectedField)
        {
            return selectedField.Token == null;
        }

        private bool IsParagraphMovement(BoardField selectedField)
        {
            return selectedField.Token != null;
        }

        private BoardField GetAdvokateTokenField(Player player)
        {
            var playerBoardField = this.board.Fields.SelectMany(x => x)
                .FirstOrDefault(x => x.Token != null && x.Token.Type == TokenType.Advocate && x.Token.Player == player);

            return playerBoardField;
        }
    }
}