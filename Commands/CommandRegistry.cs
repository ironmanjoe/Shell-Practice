using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace CustomShell.Commands
{
    public static class CommandRegistry
    {
        private static readonly Dictionary<string, ICommand> _commands = new();
        static CommandRegistry()
        {
            // Register commands here
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<ShellCommandAttribute>();
                string commandName;
                
                if (attribute != null)
                {
                    commandName = attribute.Name.ToLower();
                }

                else
                {
                    commandName = type.Name.Replace("Command", "").ToLower();
                }

                if(Activator.CreateInstance(type) is ICommand commandInstance)
                {
                    _commands[commandName] = commandInstance;
                }
            }
        }

        public static bool IsCommand(string input)
        {
            return _commands.ContainsKey(input.Trim().ToLower());
        }

        public static IEnumerable<ICommand> GetCommands(){
            return _commands.Values;
        }

        public static bool ExecuteCommand(string command, List<string> args)
        {
            string cmd = command.Trim().ToLower();

            if (_commands.TryGetValue(cmd, out ICommand? commandInstance))
            {
                commandInstance.Execute(args);
                return true;
            }

            else
            {
                Styling.ColorMode(1);
                Console.WriteLine($"[debug] Unknown command: '{command}'");
                Styling.ColorMode(0);
                return false;
            }
        }

        public static void PrintTokens(List<string> tokens)
        {
            Console.WriteLine($"[debug] Token count: {tokens.Count}");
            for(int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine($"Token {i}: {tokens[i]}");
            }
        }
    }
}