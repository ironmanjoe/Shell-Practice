namespace CustomShell.Commands
{
    [ShellCommand("cls")]
    public class ClsCommand : BaseCommand
    {
        public override string Description => "cls - Clear the screen";
        protected override void ExecuteCommand(List<string> args)
        {
            Console.Clear();
        }
    }
}