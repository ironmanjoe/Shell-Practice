namespace CustomShell.Commands
{
    public class Cls : ICommand
    {
        public void Execute(List<string> args)
        {
            Console.Clear();
        }
    }
}