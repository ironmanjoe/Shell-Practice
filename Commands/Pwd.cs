namespace CustomShell.Commands
{
    public class Pwd: ICommand
    {
        public void Execute(List<string> args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
        }
    }
}