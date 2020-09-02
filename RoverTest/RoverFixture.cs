using System;
using Xunit;
using Rover.Classes;
using Rover.Utility;
using Rover.Entity;


namespace RoverTest
{
    public class RoverFixture
    {
        private RoverUtility RoverUt = null;
        private bool bCheck = false;
        private Plateau plt;
        /// <summary>
        /// Set the first Rover
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dir"></param>
        /// <param name="plateaux"></param>
        /// <param name="plateauy"></param>
        private void SetupRover(int x, int y, Direction dir, int plateaux, int plateauy)
        {
            RoverUt = new RoverUtility(x, y, dir, new Plateau(plateaux, plateauy));
            plt = new Plateau(plateaux, plateauy);
            bCheck = RoverUt.IsValidRoverPosition(x, y, ref plt);
        }

        [Fact]
        public void MoveRoverNorthTest()
        {
            SetupRover(0, 3, Direction.N, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("LMLMLMLMM");
                Assert.Equal("1 4 N", RoverUt.GetPosition());
            }

        }

        [Fact]
        public void MoveRoverEastTest()
        {
            SetupRover(1, 2, Direction.E, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("LMLMLMLMM");
                Assert.Equal("2 2 E", RoverUt.GetPosition());
            }
        }

        [Fact]
        public void MoveRoverSouthTest()
        {
            SetupRover(1, 2, Direction.S, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("LMLMLMLMM");
                Assert.Equal("1 1 S", RoverUt.GetPosition());
            }
        }

        [Fact]
        public void MoveRoverWestTest()
        {
            SetupRover(1, 2, Direction.W, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("LMLMLMLMM");
                Assert.Equal("0 2 W", RoverUt.GetPosition());
            }
        }

        [Fact]
        public void CheckBoundryEastTest()
        {
            SetupRover(3, 3, Direction.E, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("MMMMMMMMMM");
                Assert.Equal("5 3 E", RoverUt.GetPosition());
            }
        }
        [Fact]
        public void CheckBoundryNorthTest()
        {
            SetupRover(3, 3, Direction.N, 5, 5);
            if (!bCheck)
            {
                Assert.True(bCheck);
            }
            else
            {
                RoverUt.Command("MMMMMMMMMM");
                Assert.Equal("3 5 N", RoverUt.GetPosition());
            }
        }

    }
}
