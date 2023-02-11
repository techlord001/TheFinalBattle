public static class Action
{
    public static void Attack(string name, string action, string enemy)
    {
        Console.WriteLine($"{name.ToUpper()} used {action.ToUpper()} on {enemy.ToUpper()}.");
    }

    public static void Nothing(string name)
    {
        Console.WriteLine($"{name.ToUpper()} did NOTHING.");
    }
}