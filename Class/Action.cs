public static class Action
{
    public static void Attack(CharacterBase character, CharacterBase enemy)
    {
        int attackDamage = character.StandardAttack.Name == "Bone Crunch" || character.StandardAttack.Name == "Unraveling" 
            ? new Random().Next(0, character.StandardAttack.AttackDamage + 1) : character.StandardAttack.AttackDamage;

        Message.Write($"{character.Name.ToUpper()} used {character.StandardAttack.Name.ToUpper()} on {enemy.Name.ToUpper()}.", ConsoleColor.White);
        Message.WriteLine($"{character.StandardAttack.Name.ToUpper()} dealt {attackDamage} damage to {enemy.Name.ToUpper()}.", ConsoleColor.White);

        enemy.CurrentHP = enemy.CurrentHP - attackDamage;

        Message.WriteLine($"{enemy.Name.ToUpper()} is now at {enemy.CurrentHP}/{enemy.MaxHP} HP.", enemy.CurrentHP <= 2 ? ConsoleColor.Red : ConsoleColor.Green);
    }

    public static void Nothing(CharacterBase character)
    {
        Message.WriteLine($"{character.Name.ToUpper()} did NOTHING.", ConsoleColor.DarkGray);
    }
}

/// <summary>
/// Provide a name and how much damage the attack will do.
/// </summary>
/// <param name="Name"></param>
/// <param name="AttackDamage"></param>
public record class AttackType(string Name, int AttackDamage);