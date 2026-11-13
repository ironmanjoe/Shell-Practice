using CustomShell;
namespace CustomShell.Commands
{
    public class Cd : ICommand
    {
        public void Execute(List<string> args)
        {
            string targetDir = args.Count > 0 ? string.Join(" ", args) : Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
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