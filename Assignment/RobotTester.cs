using System;
using Assignment.InterfaceCommand;
// New update: creat interface for user
namespace Assignment
{
    public class RobotTester
    {
        public void Run()
        {
            Robot robot = new Robot(6); // Create a robot with a capacity of 6 commands

            Console.WriteLine("Possible commands are: on, off, north, south, east, west");

            for (int i = 0; i < robot.NumCommands; i++)
            {
                Console.Write($"Assign command #{i + 1}: ");
                string input = Console.ReadLine();

                IRobotCommand command = CreateCommand(input);

                if (command != null)
                {
                    bool loaded = robot.LoadCommand(command);

                    if (!loaded)
                    {
                        Console.WriteLine("Maximum number of commands reached. Cannot load more commands.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command - try again");
                    i--;
                }
            }

            Console.WriteLine(robot);

            // Execute the loaded commands
            robot.Run();
        }

        private static IRobotCommand CreateCommand(string input)
        {
            switch (input.ToLower())
            {
                case "on":
                    return new OnCommand();
                case "off":
                    return new OffCommand();
                case "north":
                    return new NorthCommand();
                case "south":
                    return new SouthCommand();
                case "east":
                    return new EastCommand();
                case "west":
                    return new WestCommand();
                default:
                    return null;
            }
        }
    }
}
