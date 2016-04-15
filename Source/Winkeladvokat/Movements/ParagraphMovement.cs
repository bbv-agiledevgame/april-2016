namespace Winkeladvokat.Movements
{
    using System;
    using Models;

    public class ParagraphMovement : IMovement
    {
        private readonly BoardField startField;
        private readonly Board board;

        public ParagraphMovement(Board board, BoardField startField)
        {
            this.board = board;
            this.startField = startField;
        }

        public bool SelectField(BoardField field)
        {
            if (field.Token != null)
            {
                return false;
            }

            if (this.IsNotInSameRowOrColumn(field))
            {
                return false;
            }

            this.RemoveEnemyToken(field);

            field.Token = this.startField.Token;
            this.startField.Token = null;

            return true;
        }

        private bool IsNotInSameRowOrColumn(BoardField field)
        {
            return field.Position.X != this.startField.Position.X && field.Position.Y != this.startField.Position.Y;
        }

        private void RemoveEnemyToken(BoardField field)
        {
            var differenceX = Math.Sign(field.Position.X - this.startField.Position.X);
            var differenceY = Math.Sign(field.Position.Y - this.startField.Position.Y);

            var enemyField =
                this.board.Fields[this.startField.Position.X + differenceX][this.startField.Position.Y + differenceY];
            enemyField.Token = null;
        }
    }
}