using CustomShell;
using System.IO;
namespace CustomShell.Commands
{
    public class MkdirCommand : BaseCommand
    {
        public override string Description => "mkdir <path> - Create a new directory at the specified path.";
        protected override void ExecuteCommand(List<string> args)
        {
            if (args.Count == 0)
            {
                throw new ArgumentException("Error: No directory name provided.");
            }
            if(Directory.Exists(args[0]) || File.Exists(args[0]))
            {
                throw new DirectoryNotFoundException($"Error: Path '{args[0]}' already exists.");
            }
            string dirName = args[0];
            Directory.CreateDirectory(dirName);
            Console.WriteLine($"Directory '{dirName}' created successfully.");
        }
    }
}