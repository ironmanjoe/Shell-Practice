namespace CustomShell.Commands
{
    public class ClsCommand : ICommand
    {
        public string Description => "cls - Clear the screen";
        public void Execute(List<string> args)
        {
            Console.Clear();
        }
    }
}