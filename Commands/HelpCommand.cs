namespace CustomShell.Commands
{
    public class HelpCommand : ICommand
    {
        public string Description => "help - Display this help message";
        public void Execute(List<string> args)
        {
            Console.WriteLine("\n== Available Commands ==");
            foreach (var cmd in CommandRegistry.GetCommands())
            {
                Console.WriteLine(cmd.Description);
            }
            Console.WriteLine("== Type 'exit' to quit the shell ==");
        }
    }
}