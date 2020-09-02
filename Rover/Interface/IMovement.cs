using System;
using System.Collections.Generic;
using System.Text;

namespace Rover.Interfaces
{
    interface IMovement
    {
        #region "Imovement Implementation
        void Move();
        #endregion
        #region "Change direction"
        void ChangeDirection(Char directionCode, int degree);
        #endregion
    }
}
