namespace CustomShell.Commands
{
    public class MvCommand : BaseCommand
    {
        public override string Description => "mv <source> <destination> - Move/rename files or directories.";
        protected override void ExecuteCommand(List<string> args)
        {
            if (args.Count < 2)
            {
                throw new ArgumentException("Insufficient arguments. Usage: mv <source> <destination>");
            }

            string source = args[0];
            string destination = args[1];

            if (!File.Exists(source) && !Directory.Exists(source))
            {
                throw new FileNotFoundException($"Error: Source path '{source}' does not exist.");
            }

            string finalDestination = destination;

            if (Directory.Exists(destination))
            {
                finalDestination = Path.Combine(destination, Path.GetFileName(source));
            }

            if (Directory.Exists(source))
            {
                Directory.Move(source, finalDestination);
                Console.WriteLine($"Directory '{source}' moved to '{finalDestination}' successfully.");
            }

            else
            {
                File.Move(source, finalDestination);
                Console.WriteLine($"File '{source}' moved to '{finalDestination}' successfully.");
            }
        }
    }
}