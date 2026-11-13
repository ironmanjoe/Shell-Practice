using System;
using System.IO;
using System.Collections.Generic;

namespace CustomShell.Commands
{
    public static class CommandRegistry
    {
        private static readonly Dictionary<string, ICommand> _commands = new()
        {
            { "cd", new Cd() },
            { "pwd", new Pwd() },
            { "cls", new Cls() },
            { "help", new Help() }
        };

        public static bool IsCommand(string input)
        {
            return _commands.ContainsKey(input.ToLower());
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