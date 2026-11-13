namespace CustomShell.Commands
{
    public interface ICommand
    {
        public string Description { get; }
        void Execute(List<string> args);
    }
}