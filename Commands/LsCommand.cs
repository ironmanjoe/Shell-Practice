using System;
using System.Collections.Generic;

namespace CustomShell.Commands
{
    public class LsCommand : ICommand
    {
        public string Description => "ls [path] - List files and directories in the specified path (or current directory if no path is provided)";
        public void Execute(List<string> args)
        {
            string path = args.Count > 0 ? args[0] : Environment.CurrentDirectory;
            if (Directory.Exists(path))
            {
                var entries = Directory.GetFileSystemEntries(path);
                Array.Sort(entries);
                foreach (var entry in entries)
                {
                    if (Directory.Exists(entry))
                    {
                        Console.WriteLine($"{Path.GetFileName(entry)}\\");
                    }
                    else
                    {
                        Console.WriteLine($"{Path.GetFileName(entry)}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"The directory '{path}' does not exist.");
            }
        }
    }
}