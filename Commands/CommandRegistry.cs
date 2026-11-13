using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

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
                if(Activator.CreateInstance(type) is ICommand commandInstance)
                {
                    _commands[type.Name.Replace("Command", "").ToLower()] = commandInstance;
                }
            }
        }

        public static bool IsCommand(string input)
        {
            return _commands.ContainsKey(input.ToLower());
        }

        public static IEnumerable<ICommand> GetCommands(){
            return _commands.Values;
        }

        public static bool ExecuteCommand(string command, List<string> args)
        {
            string cmd = command.ToLower();
            if (_commands.TryGetValue(cmd, out ICommand? commandInstance))
            {
                commandInstance.Execute(args);
                return true;
            }
            else
            {
                Styling.ColorMode(1);
                Console.WriteLine($"[debug] Unknown command: {command}");
                PrintTokens(args);
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