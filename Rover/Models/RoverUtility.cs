using System;
using Rover.Classes;
using Rover.Interfaces;
using Rover.Entity;

namespace Rover.Utility
{
    /// <summary>
    /// Defines and shows the direction of the rover
    /// </summary>
    public enum Direction
    {
        N = 90,
        E = 180,
        S = 270,
        W = 360
    }

    public class RoverUtility : RoverEntity, IMovement, IPosition
    {
        /// <summary>
        /// Constructor of this class
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <param name="plateau"></param>
        /// 
        public Plateau Plateau;
        public RoverUtility(Int32 x, Int32 y, Direction direction, Plateau plateau)
        {
            PositionX = x;
            PositionY = y;
            RoverDirection = direction;
            Plateau = plateau;
        }

        public RoverUtility()
        { }

        /// <summary>
        /// Perform the move operation
        /// </summary>
        public void Move()
        {
            //switch(RoverDirection)
            //{
            //    case Direction.N:
            //        PositionY++;
            //        break;
            //    case Direction.E:
            //        PositionX++;
            //        break;
            //    case Direction.S:
            //        PositionY--;
            //        break;
            //    case Direction.W:
            //        PositionX--;
            //        break;

            //}

            if (RoverDirection == Direction.N && Plateau.Y > PositionY)
            {
                PositionY++;
            }
            else if (RoverDirection == Direction.E && Plateau.X > PositionX)
            {
                PositionX++;
            }
            else if (RoverDirection == Direction.S && PositionY > 0)
            {
                PositionY--;
            }
            else if (RoverDirection == Direction.W && PositionX > 0)
            {
                PositionX--;
            }
        }
        /// <summary>
        ///  Get the position and direction of the rover at the end of the command
        /// </summary>
        /// <returns></returns>

        public string GetPosition()
        {
            string roverPosition = string.Format("{0} {1} {2}", PositionX, PositionY, RoverDirection);
            //Console.WriteLine(printedRoverPosition);
            return roverPosition;
        }
        /// <summary>
        /// change the direction of Rover
        /// </summary>
        /// <param name="directionCode"></param>
        /// <param name="degree"></param>
        public void ChangeDirection(char directionCode, int degree)
        {
            if (directionCode.Equals('L'))
                RoverDirection = (RoverDirection - degree) < Direction.N ? Direction.W : RoverDirection - degree;
            else if (directionCode.Equals('R'))
                RoverDirection = (RoverDirection + degree) > Direction.W ? Direction.N : RoverDirection + degree;
           
        }

        /// <summary>
        /// Process the Command given in String
        /// </summary>
        /// <param name="commandStr"></param>
        public void Command(string commandStr)
        {
            foreach (var command in  commandStr.ToUpper())
            {
                if (command.Equals('L') || command.Equals('R'))
                    ChangeDirection(command, 90);
                else if (command.Equals('M'))
                    Move();
                else
                    Console.WriteLine("Please enter valid movement.");
            }
        }

        public bool IsValidRoverPosition(int x, int y, ref Plateau Plt)
        {
            bool ret = false;
            if(!string.IsNullOrWhiteSpace( x.ToString()) || !(string.IsNullOrWhiteSpace(x.ToString())) || 
                            !(string.IsNullOrWhiteSpace(Plt.X.ToString()))|| !string.IsNullOrWhiteSpace(Plt.Y.ToString()))
            {
                if (x > Plt.X || y > Plt.Y)
                    ret = false;
                else if (Plt.X < 0 || Plt.Y < 0)
                {
                    if (x < Plt.X || y < Plt.Y)
                        ret = false;
                }
                else
                    ret = true;
                
            }
            return ret; 
        }
    }
}
