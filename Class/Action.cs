using System.Xml.Linq;
using TheFinalBattle.Class.Items;

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

    public static void UseItem(PartyBase party, PartyBase enemyParty) 
    {
        if (party.Player == Player.Computer)
        {
            for (int i = 0; i < party.Characters.Count; i++)
            {
                if (party.Characters[i].CurrentHP < party.Characters[i].MaxHP / 2)
                {
                    for (int j = 0; j < party.Inventory.Count; j++)
                    {
                        if (party.Inventory[j] is HealthPotion)
                        {
                            party.Inventory[j].consumeItem(party, enemyParty);
                            party.Inventory.Remove(party.Inventory[j]);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        else
        {
            Message.Write("Which item would you like to use? ", ConsoleColor.White);

            for (int i = 0; i < party.Inventory.Count; i++)
            {
                Message.Write($"{i + 1} - {party.Inventory[i].Name}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice < 1 || choice > party.Inventory.Count)
            {
                Message.WriteLine("Please provide a valid number", ConsoleColor.Red);
                choice = Convert.ToInt32(Console.ReadLine());
            }

            // Use item
            party.Inventory[choice - 1].consumeItem(party, enemyParty);

            // Delete item
            party.Inventory.Remove(party.Inventory[choice - 1]);
        }
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