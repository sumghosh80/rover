using System;
using Rover.Classes;
using Rover.Utility;
using Rover.Entity;
using System.Linq;

namespace Rover
{
    public class Rover
    {
        static void Main()
        {
            try
            {
                //if (args.Length == 0)
                //    throw new Exception("No input is entered");
                RoverUtility RoverUtil = new RoverUtility();

                Console.WriteLine("Please enter the coordinates of plateau (x, y): ");
                string coordinates = Console.ReadLine();
                string[] CoordPlt = coordinates.Split(',').ToArray();
                int x = 0, y = 0, TotalRovers = 0;
                if (CoordPlt.Length == 2)
                {
                    x = Convert.ToInt16(CoordPlt[0].Trim());
                    y = Convert.ToInt16(CoordPlt[1].Trim());
                }

                Plateau Plt = new Plateau(x, y);
                Console.WriteLine("Please enter number of rovers on plateau : ");
                string numOfRovers = Console.ReadLine();
                if (!string.IsNullOrEmpty(numOfRovers))
                {
                    TotalRovers = Convert.ToInt16(numOfRovers.Trim());
                }

                int xRover = 0, yRover = 0;
                for (int i = 0; i < TotalRovers; i++)
                {
                    Console.WriteLine(string.Format("Please enter starting coordinates and facing direction(N,S,E,W) of rover{0} (x y): ", i + 1));

                    string Coord = Console.ReadLine();
                    string[] cordRover = Coord.Split(' ').ToArray();
                    xRover = Convert.ToInt16(cordRover[0].Trim());
                    yRover = Convert.ToInt16(cordRover[1].Trim());
                    Plt.X = x;
                    Plt.Y = y;
                    Direction c = Direction.N;
                    if (RoverUtil.IsValidRoverPosition(xRover, yRover, ref Plt))
                    {
                        switch (cordRover[2].Trim().ToUpper())
                        {
                            case "N":
                                c = Direction.N;
                                break;
                            case "W":
                                c = Direction.W;
                                break;
                            case "S":
                                c = Direction.S;
                                break;
                            case "E":
                                c = Direction.E;
                                break;
                            default:
                                c = Direction.N;
                                break;
                        }
                        //RoboticRover rover = new RoboticRover(xRover, yRover, c);
                        Console.WriteLine(string.Format("Please enter commands for rover{0}", i + 1));
                        string command = Console.ReadLine();
                        RoverUtility RoverUt = new RoverUtility(x, y, c, Plt);
                        RoverUt.Command(command.Trim());
                        Plt.Rovers.Add(RoverUt);


                    }
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Final position of Rovers respectively: ");
                    foreach (var rover in Plt.Rovers)
                    {
                        Console.WriteLine(rover.GetPosition());
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
