using System;
//new update
using Assignment.InterfaceCommand;

namespace Assignment
{
    public class Robot
    {
        public int NumCommands { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }

        private IRobotCommand[] _commands;
        private int _commandsLoaded;

        public Robot(int numCommands)
        {
            NumCommands = numCommands;
            _commands = new IRobotCommand[numCommands];
            _commandsLoaded = 0;
        }

        public override string ToString()
        {
            return $"[{X} {Y} {IsPowered}]";
        }

        public void Run()
        {
            for (int i = 0; i < _commandsLoaded; i++)
            {
                _commands[i].Run(this);
                Console.WriteLine(this);
            }
        }

        public bool LoadCommand(IRobotCommand command)
        {
            if (_commandsLoaded < NumCommands)
            {
                _commands[_commandsLoaded] = command;
                _commandsLoaded++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
