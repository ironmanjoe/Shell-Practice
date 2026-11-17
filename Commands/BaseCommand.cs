using System;
using System.Collections.Generic;
using System.IO;

namespace CustomShell.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract string Description { get; }
        public void Execute(List<string> args)
        {
            try
            {
                ExecuteCommand(args);
            }

            catch (UnauthorizedAccessException)
            {
                Styling.ColorMode(1);
                Console.WriteLine("Error: Access denied.");
            }

            catch (DirectoryNotFoundException)
            {
                Styling.ColorMode(1);
                Console.WriteLine("Error: Directory not found.");
            }

            catch (FileNotFoundException)
            {
                Styling.ColorMode(1);
                Console.WriteLine("Error: File not found.");
            }

            catch (IOException ex)
            {
                Styling.ColorMode(1);
                Console.WriteLine($"Error: {ex.Message}");
            }

            catch (Exception ex)
            {
                Styling.ColorMode(1);
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Styling.ColorMode(0);
            }
        }
        protected abstract void ExecuteCommand(List<string> args);
    }
}