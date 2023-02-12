public static class Action
{
    public static void Attack(CharacterBase character, CharacterBase enemy)
    {
        int attackDamage = character.AttackType.Name == "Bone Crunch" || character.AttackType.Name == "Unraveling" 
            ? new Random().Next(0, character.AttackType.AttackDamage + 1) : character.AttackType.AttackDamage;

        Message.Write($"{character.Name.ToUpper()} used {character.AttackType.Name.ToUpper()} on {enemy.Name.ToUpper()}.", ConsoleColor.White);
        Message.WriteLine($"{character.AttackType.Name.ToUpper()} dealt {attackDamage} damage to {enemy.Name.ToUpper()}.", ConsoleColor.White);

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

    public static void Nothing(CharacterBase character)
    {
        Message.WriteLine($"{character.Name.ToUpper()} did NOTHING.", ConsoleColor.DarkGray);
    }
}

public record class AttackType(string Name, int AttackDamage);