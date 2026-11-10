using System;
using System.IO;
using System.Collections.Generic;

namespace CustomShell
{
    public static class Commands
    {
        private static readonly HashSet<string> commands = new HashSet<string>
        {
            "cd", "pwd", "cls", "help"
        };

        public static bool IsCommand(string input)
        {
            return commands.Contains(input.ToLower());
        }

        public static bool ChangeState(string command, List<string> args)
        {
            switch (command.ToLower())
            {
                case "cd":
                    ChangeDirectory(args);
                    break;

                case "pwd":
                    Console.WriteLine(Environment.CurrentDirectory);
                    break;

                case "cls":
                    Console.Clear();
                    break;

                case "help":
                    Help();
                    break;

                default:
                    Console.WriteLine($"[debug] Unknown command: {command}");
                    PrintTokens(args);
                    return false;
            }
            return true;
        }

        private static void ChangeDirectory(List<string> args)
        {
            string targetDir = args.Count > 0 ? string.Join(" ", args) : Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            ColorMode(1);
            try
            {
                Directory.SetCurrentDirectory(targetDir);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Error: Directory '{targetDir}' not found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Access to directory '{targetDir}' is denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing directory: {ex.Message}");
            }
            ColorMode(0);
        }

        private static void Help()
        {
            Console.WriteLine("\n== Available Commands ==");
            Console.WriteLine("cd [path] - Change directory to the specified path. (defaults to home)");
            Console.WriteLine("pwd - Print the current working directory");
            Console.WriteLine("cls - Clear the screen");
            Console.WriteLine("help - Display this help message");
            Console.WriteLine("== Type 'exit' to quit the shell ==");
        }

        public static void PrintTokens(List<string> tokens)
        {
            Console.WriteLine($"[debug] Token count: {tokens.Count}");
            for(int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine($"Token {i}: {tokens[i]}");
            }
        }

        public static void ColorMode(int mode)
        {
            switch (mode)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 1:
                    Console.ForegroundColor =  ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        public static void SetUp()
        {
            ColorMode(0);
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Welcome to MyBalls! Type 'exit' to quit.");
            Console.WriteLine("================================");
        }
    }
}