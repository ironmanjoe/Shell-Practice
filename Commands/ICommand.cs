using System;
namespace CustomShell.Commands
{
    public interface ICommand
    {
        public string Description { get; }
        void Execute(List<string> args);
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ShellCommandAttribute : Attribute
    {
        public string Name { get; }
        public ShellCommandAttribute(string name)
        {
            Name = name;
        }
    }
}