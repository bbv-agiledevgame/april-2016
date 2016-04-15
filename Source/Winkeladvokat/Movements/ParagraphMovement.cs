namespace Winkeladvokat.Movements
{
    using Models;

    public class ParagraphMovement : IMovement
    {
        public ParagraphMovement(BoardField startField)
        {
        }

        public bool SelectField(BoardField field)
        {
            return false;
        }
    }
}