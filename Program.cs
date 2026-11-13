// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using CustomShell;
using CustomShell.Commands;

class MyShell
{
    static void Main(string[] args)
    {
        Styling.SetUp();
        while (true)
        {
            string curDir = Environment.CurrentDirectory;
            Console.Write($"[MyBalls] {curDir}> ");

            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            List<string> tokens = Parser.Tokenize(input);
            if (tokens.Count == 0) continue;

            string command = tokens[0].ToLower();

            if (command == "exit")
            {
                Console.WriteLine("Exiting MyBalls. Goodbye!");
                Styling.ColorMode(-1);
                break;
            }
            
            if (CommandRegistry.IsCommand(command))
            {
                List<string> commandArgs = tokens.GetRange(1, tokens.Count - 1);
                CommandRegistry.ExecuteCommand(command, commandArgs);
            }
            else
            {
                Console.WriteLine($"[debug] Unknown command: {command}");
                CommandRegistry.PrintTokens(tokens);
            }
        }
    }
}