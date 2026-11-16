namespace CustomShell;

public static class Styling
{
    private const string Reset = "\u001b[0m";
    private const string Red = "\u001b[31m";
    private const string Green = "\u001b[32m";
    private const string White = "\u001b[37m";
    private const string Bold = "\u001b[1m";

    public static void SetColors(ConsoleColor background, ConsoleColor foreground)
    {
        Console.BackgroundColor = background;
        Console.ForegroundColor = foreground;
    }

    public static void ResetColors()
    {
        Console.ResetColor();
    }
    public static void ColorMode(int mode)
    {
        switch (mode)
        {
            case 0:
                Console.Write(Green);
                break;
            case 1:
                Console.Write(Red);
                break;
            default:
                Console.Write(Reset);
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