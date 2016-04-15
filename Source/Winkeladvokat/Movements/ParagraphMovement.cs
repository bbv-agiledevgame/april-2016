namespace Winkeladvokat.Movements
{
    using Models;

    public class ParagraphMovement : IMovement
    {
        private readonly BoardField startField;

        public ParagraphMovement(BoardField startField)
        {
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

            field.Token = this.startField.Token;
            this.startField.Token = null;

            return true;
        }

        private bool IsNotInSameRowOrColumn(BoardField field)
        {
            return field.Position.X != this.startField.Position.X && field.Position.Y != startField.Position.Y;
        }
    }
}