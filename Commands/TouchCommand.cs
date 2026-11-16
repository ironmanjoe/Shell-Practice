namespace CustomShell.Commands
{
    public class TouchCommand : ICommand
    {
        public string Description => "touch <filename> - Create a new empty file with the specified filename.";
        public void Execute(List<string> args)
        {
            Styling.ColorMode(1);
            if (args.Count == 0)
            {
                Console.WriteLine("No argument provided. Usage: touch <filename>");
                Styling.ColorMode(0);
                return;
            }
            if (Directory.Exists(args[0]))
            {
                Console.WriteLine($"Error: Path '{args[0]}' already exists.");
                Styling.ColorMode(0);
                return;
            }
            if (File.Exists(args[0]))
            {
                Styling.ColorMode(0);
                Console.WriteLine($"File '{args[0]}' already exists.");
                return;
            }
            string filename = args[0];
            try
            {
                using (FileStream fs = File.Create(filename))
                {
                    Styling.ColorMode(0);
                    Console.WriteLine($"File '{filename}' created successfully.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access to create file '{filename}' is denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file '{filename}': {ex.Message}");
            }
            Styling.ColorMode(0);
        }
    }
}