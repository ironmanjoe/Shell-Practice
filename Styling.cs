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
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 1:
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor =  ConsoleColor.Red;
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