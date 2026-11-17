namespace CustomShell.Commands
{
    public class HelpCommand : BaseCommand
    {
        public override string Description => "help - Display this help message";
        protected override void ExecuteCommand(List<string> args)
        {
            Console.WriteLine("\n== Available Commands ==");
            foreach (var cmd in CommandRegistry.GetCommands())
            {
                Console.WriteLine(cmd.Description);
            }
            Console.WriteLine("== Type 'exit' to quit the shell ==\n");
        }
    }
}