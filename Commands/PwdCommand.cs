namespace CustomShell.Commands
{
    public class PwdCommand: ICommand
    {
        public string Description => "pwd - Print the current working directory";
        public void Execute(List<string> args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
        }
    }
}