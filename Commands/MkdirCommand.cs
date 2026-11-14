using CustomShell;
using System.IO;
namespace CustomShell.Commands
{
    public class MkdirCommand : ICommand
    {
        public string Description => "mkdir [path] - Create a new directory at the specified path.";
        public void Execute(List<string> args)
        {
            Styling.ColorMode(1);
            if (args.Count == 0)
            {
                Console.WriteLine("Error: No directory name provided.");
                Styling.ColorMode(0);
                return;
            }
            if(Directory.Exists(args[0]) || File.Exists(args[0]))
            {
                Console.WriteLine($"Error: Path '{args[0]}' already exists.");
                Styling.ColorMode(0);
                return;
            }

            string dirName = args[0];
            try
            {
                Directory.CreateDirectory(dirName);
                Styling.ColorMode(0);
                Console.WriteLine($"Directory '{dirName}' created successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access to create directory '{dirName}' is denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
            Styling.ColorMode(0);
        }
    }
}