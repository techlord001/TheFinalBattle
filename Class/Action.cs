using TheFinalBattle.Class.Character;

public static class Action
{
    public static void Attack(string name, AttackType attackType, CharacterBase enemy)
    {
        int attackDamage = attackType.Name == "Bone Crunch" ? new Random().Next(0, attackType.AttackDamage + 1) : attackType.AttackDamage;

        Console.WriteLine($"{name.ToUpper()} used {attackType.Name.ToUpper()} on {enemy.Name.ToUpper()}.");
        Console.WriteLine($"{attackType.Name.ToUpper()} dealt {attackDamage} damage to {enemy.Name.ToUpper()}.");

        if (enemy.CurrentHP == 0)
        {
            Console.WriteLine($"{enemy.Name.ToUpper()} is already at {enemy.CurrentHP}/{enemy.MaxHP} HP.");
            return;
        }

        enemy.CurrentHP = enemy.CurrentHP - attackDamage;

        Console.WriteLine($"{enemy.Name.ToUpper()} is now at {enemy.CurrentHP}/{enemy.MaxHP} HP.");
    }

    public static void Nothing(string name)
    {
        Console.WriteLine($"{name.ToUpper()} did NOTHING.");
    }
}

public record class AttackType(string Name, int AttackDamage);