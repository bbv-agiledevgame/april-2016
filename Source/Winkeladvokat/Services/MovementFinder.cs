﻿namespace Winkeladvokat.Services
{
    using Models;
    using Movements;

    public class MovementFinder
    {
        public IMovement GetMovement(BoardField selectedField)
        {
            if (this.IsAngleMovement(selectedField))
            {
                return new AngleMovement(selectedField);
            }

            return null;
        }

        private bool IsAngleMovement(BoardField selectedField)
        {
            return selectedField.Player == null;
        }
    }
}