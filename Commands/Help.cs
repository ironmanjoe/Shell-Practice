namespace CustomShell.Commands
{
    public class Help : ICommand
    {
        public void Execute(List<string> args)
        {
            Console.WriteLine("\n== Available Commands ==");
            Console.WriteLine("cd [path] - Change directory to the specified path. (defaults to home)");
            Console.WriteLine("pwd - Print the current working directory");
            Console.WriteLine("cls - Clear the screen");
            Console.WriteLine("help - Display this help message");
            Console.WriteLine("== Type 'exit' to quit the shell ==");
        }
    }
}