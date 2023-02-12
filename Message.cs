namespace Utilities
{
    public static class Message
    {
        public static void WriteLine(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
        }

        public static void Write(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
        }
    }
}