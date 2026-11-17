using System;
using System.IO;

namespace CustomShell.Commands
{
    public class RmCommand : BaseCommand
    {
        public override string Description => "rm <filename> - Remove the specified files or directories.";
        protected override void ExecuteCommand(List<string> args)
        {
            if (args.Count == 0)
            {
                throw new ArgumentException("No path provided. Usage: rm [-r] <filename>");
            }

            bool recursive = false;
            string filename;

            if (args.Count > 1 && args[0].Equals("-r", StringComparison.CurrentCultureIgnoreCase))
            {
                recursive = true;
                filename = args[1];
            }

            else
            {
                filename = args[0];
            }

            if(string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("No path provided. Usage: rm [-r] <filename>");
            }

            if (!File.Exists(filename) && !Directory.Exists(filename))
            {
                throw new FileNotFoundException($"Error: Path '{filename}' does not exist.");
            }


            if (Directory.Exists(filename))
            {
                if (recursive)
                {
                    Directory.Delete(filename, recursive);
                    Console.WriteLine($"Directory '{filename}' deleted successfully.");
                }

                else
                {
                    throw new ArgumentException($"Error: '{filename}' is a directory. Use 'rm -r <directory>' to delete it recursively.");
                }
            }

            else
            {
                File.Delete(filename);
                Console.WriteLine($"File '{filename}' deleted successfully.");
            }
        }
    }
}