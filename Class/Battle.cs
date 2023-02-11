using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class Battle
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }
    private bool BattleOver { get; set; } = false;

    public Battle(Heroes heroes, Monsters monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    private void EnemyHealthCheck(PartyBase party)
    {
        // TODO : Look at adding lock for potential fix for this code
        // ERROR : System.InvalidOperationException: 'Collection was modified; enumeration operation may not execute.'
        //foreach (CharacterBase character in party.Characters)
        //{
        //    if (character.CurrentHP == 0)
        //    {
        //        Console.WriteLine($"{character.Name.ToUpper()} has been defeated!");
        //        party.Characters.Remove(character);

        //        if (party.Characters.Count == 0)
        //        {
        //            break;
        //        }
        //    }
        //}

        for (int i = 0; i < party.Characters.Count; i++)
        {
            if (party.Characters[i]
                .CurrentHP == 0)
            {
                Console.WriteLine($"{party.Characters[i].Name.ToUpper()} has been defeated!");
                party.Characters.Remove(party.Characters[i]);
            }
        }
    }

    private void CharacterTurn(CharacterBase character, Player player, PartyBase enemyParty)
    {
        Console.WriteLine($"It's {character.Name.ToUpper()}'s turn...");
        character.PlayerAction(player, enemyParty);
        Console.WriteLine("");
    }

    public bool End() => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0 ? true : false;

    public bool Start()
    {
        Console.WriteLine("A new battle begins! Prepare yourself...");
        Thread.Sleep(1000);

        while (!BattleOver)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                CharacterTurn(Heroes.Characters[i], Heroes.Player, Monsters);
                EnemyHealthCheck(Monsters);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                CharacterTurn(Monsters.Characters[i], Monsters.Player, Heroes);
                EnemyHealthCheck(Heroes);
            }

            BattleOver = End();
        }

        return false;
    }
}