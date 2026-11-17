namespace CustomShell.Commands
{
    public class MvCommand : ICommand
    {
        public string Description => "mv <source> <destination> - Move/rename files or directories.";
        public void Execute(List<string> args)
        {
            Styling.ColorMode(1);

            if (args.Count < 2)
            {
                Console.WriteLine("Insufficient arguments. Usage: mv <source> <destination>");
                Styling.ColorMode(0);
                return;
            }

            string source = args[0];
            string destination = args[1];

            if (!File.Exists(source) && !Directory.Exists(source))
            {
                Console.WriteLine($"Error: Source path '{source}' does not exist.");
                Styling.ColorMode(0);
                return;
            }

            try
            {
                string finalDestination = destination;
                if (Directory.Exists(destination))
                {
                    finalDestination = Path.Combine(destination, Path.GetFileName(source));
                }

                if (Directory.Exists(source))
                {
                    Directory.Move(source, finalDestination);
                    Styling.ColorMode(0);
                    Console.WriteLine($"Directory '{source}' moved to '{finalDestination}' successfully.");
                }

                else
                {
                    File.Move(source, finalDestination);
                    Styling.ColorMode(0);
                    Console.WriteLine($"File '{source}' moved to '{finalDestination}' successfully.");
                }
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access denied while moving '{source}' to '{destination}'.");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Styling.ColorMode(0);
        }
    }
}