using System;
using System.Collections.Generic;
using System.IO;

namespace CustomShell.Commands
{
    [ShellCommand("cd")]
    public class CdCommand : BaseCommand
    {
        public override string Description => "cd <path> - Change directory to the specified path. (defaults to home)";
        protected override void ExecuteCommand(List<string> args)
        {
            string targetDir = args.Count == 0 || args[0].Equals("~") ? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) : args[0];
            Directory.SetCurrentDirectory(targetDir);
        }
    }
}