namespace CustomShell.Commands
{
    public interface ICommand
    {
        void Execute(List<string> args);
    }
}