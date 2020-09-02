using System;
using System.Collections.Generic;
using System.Text;
using Rover.Utility;

namespace Rover.Classes
{
    public class Plateau
    {
        public int  X { get; set; }
        public int Y { get; set; }

        public List<RoverUtility> Rovers;
        /// <summary>
        /// Width and height of the Plateau
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Plateau(int x =0, int y =0)
        {
            X = x;
            Y = y;
            Rovers = new List<RoverUtility>();
        }
    }
}
