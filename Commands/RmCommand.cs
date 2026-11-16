namespace CustomShell.Commands
{
    public class RmCommand : ICommand
    {
        public string Description => "rm <filename> - Remove the specified files or directories.";
        public void Execute(List<string> args)
        {
            Styling.ColorMode(1);
            if (args.Count == 0)
            {
                Console.WriteLine("No path provided. Usage: rm [-r] <filename>");
                Styling.ColorMode(0);
                return;
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
                Console.WriteLine("No path provided. Usage: rm [-r] <filename>");
                Styling.ColorMode(0);
                return;
            }
            if (!File.Exists(filename) && !Directory.Exists(filename))
            {
                Console.WriteLine($"Error: Path '{filename}' does not exist.");
                Styling.ColorMode(0);
                return;
            }
            try
            {
                if (Directory.Exists(filename))
                {
                    if (recursive)
                    {
                        Directory.Delete(filename, recursive);
                        Styling.ColorMode(0);
                        Console.WriteLine($"Directory '{filename}' deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: '{filename}' is a directory. Use 'rm -r <directory>' to delete it recursively.");
                    }
                }
                else
                {
                    File.Delete(filename);
                    Styling.ColorMode(0);
                    Console.WriteLine($"File '{filename}' deleted successfully.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access to delete file '{filename}' is denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file '{filename}': {ex.Message}");
            }
            Styling.ColorMode(0);
        }
    }
}