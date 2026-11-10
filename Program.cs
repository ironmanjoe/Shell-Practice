// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using CustomShell;

class MyShell
{
    static void Main(string[] args)
    {
        Commands.SetUp();
        while (true)
        {
            string curDir = Environment.CurrentDirectory;
            Console.Write($"\n[MyBalls] {curDir}> ");

            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            List<string> tokens = Parser.Tokenize(input);
            if (tokens.Count == 0) continue;

            string command = tokens[0].ToLower();

            if (command == "exit")
            {
                Console.WriteLine("Exiting MyBalls. Goodbye!");
                Commands.ColorMode(-1);
                break;
            }
            if (Commands.IsCommand(command))
            {
                List<string> commandArgs = tokens.GetRange(1, tokens.Count - 1);
                Commands.ChangeState(command, commandArgs);
            }
            else
            {
                Console.WriteLine($"[debug] Unknown command: {command}");
                Commands.PrintTokens(tokens);
            }
        }
    }
}