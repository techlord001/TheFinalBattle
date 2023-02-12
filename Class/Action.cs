using TheFinalBattle.Class.Character;

public static class Action
{
    public static void Attack(string name, AttackType attackType, CharacterBase enemy)
    {
        int attackDamage = attackType.Name == "Bone Crunch" || attackType.Name == "Unraveling" ? new Random().Next(0, attackType.AttackDamage + 1) : attackType.AttackDamage;

        Message.Write($"{name.ToUpper()} used {attackType.Name.ToUpper()} on {enemy.Name.ToUpper()}.", ConsoleColor.White);
        Message.WriteLine($"{attackType.Name.ToUpper()} dealt {attackDamage} damage to {enemy.Name.ToUpper()}.", ConsoleColor.White);

        enemy.CurrentHP = enemy.CurrentHP - attackDamage;

        if (enemy.CurrentHP < 0)
        {
            enemy.CurrentHP = 0;
        }

        if (enemy.CurrentHP <= 2)
        {
            Message.WriteLine($"{enemy.Name.ToUpper()} is now at {enemy.CurrentHP}/{enemy.MaxHP} HP.", ConsoleColor.Red);
        }
        else
        {
            Message.WriteLine($"{enemy.Name.ToUpper()} is now at {enemy.CurrentHP}/{enemy.MaxHP} HP.", ConsoleColor.Green);
        }
    }

    public static void Nothing(string name)
    {
        Message.WriteLine($"{name.ToUpper()} did NOTHING.", ConsoleColor.DarkGray);
    }
}

public record class AttackType(string Name, int AttackDamage);