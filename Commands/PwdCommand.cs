namespace CustomShell.Commands
{
    [ShellCommand("pwd")]
    public class PwdCommand: BaseCommand
    {
        public override string Description => "pwd - Print the current working directory";
        protected override void ExecuteCommand(List<string> args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
        }
    }
}