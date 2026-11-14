using CustomShell;
namespace CustomShell.Commands
{
    public class CdCommand : ICommand
    {
        public string Description => "cd [path] - Change directory to the specified path. (defaults to home)";
        public void Execute(List<string> args)
        {
            string targetDir = args.Count == 0 || args[0].Equals("~") ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) : args[0];
            Styling.ColorMode(1);
            try
            {
                Directory.SetCurrentDirectory(targetDir);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: Directory '{targetDir}' not found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access to directory '{targetDir}' is denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing directory: {ex.Message}");
            }
            Styling.ColorMode(0);
        }
    }
}