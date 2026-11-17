using System;
using System.Collections.Generic;
using System.IO;
namespace CustomShell.Commands
{
    public class TouchCommand : BaseCommand
    {
        public override string Description => "touch <filename> - Create a new empty file with the specified filename.";
        protected override void ExecuteCommand(List<string> args)
        {
            if (args.Count == 0)
            {
                throw new ArgumentException("No argument provided. Usage: touch <filename>");
            }

            if (Directory.Exists(args[0]))
            {
                throw new DirectoryNotFoundException($"Error: Path '{args[0]}' already exists.");
            }

            if (File.Exists(args[0]))
            {
                throw new FileNotFoundException($"File '{args[0]}' already exists.");
            }

            string filename = args[0];

            using (FileStream fs = File.Create(filename))
            {
                Console.WriteLine($"File '{filename}' created successfully.");
            }
        }
    }
}