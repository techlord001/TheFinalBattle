namespace Utilities
{
    public static class Message
    {
        public static void WriteLine(string message, ConsoleColor consoleColor = ConsoleColor.Gray)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(100);
        }

        public static void Write(string message, ConsoleColor consoleColor = ConsoleColor.Gray)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(100);
        }
    }
}