namespace CustomShell;

public static class Styling
{
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