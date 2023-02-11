using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class Battle
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }
    private bool BattleOngoing { get; set; } = true;

    public Battle(Heroes heroes, Monsters monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    private void EnemyHealthCheck(PartyBase party)
    {
        foreach (CharacterBase character in party.Characters)
        {
            if (character.CurrentHP == 0)
            {
                Console.WriteLine($"{character.Name.ToUpper()} has been defeated!");
                party.Characters.Remove(character);
                break;
            }
        }
    }

    private void CharacterTurn(CharacterBase character, Player player, PartyBase enemyParty)
    {
        Console.WriteLine($"It's {character.Name.ToUpper()}'s turn...");
        character.PlayerAction(player, enemyParty);
        Console.WriteLine("");
    }

    public bool End()
    {
        if (Heroes.Characters.Count == 0)
        {
            Console.WriteLine("All the heroes have been defeated. All hope is lost! The Uncoded One & his forces have prevailed!");
            return false;
        }

        if (Monsters.Characters.Count == 0)
        {
            Console.WriteLine($"The Uncoded One and his minions have been defeated! You, {Heroes.Characters[0].Name.ToUpper()} have won the day and saved these realms! You are the True Programmer of legend!");
            return false;
        }

        return true;
    }

    public void Start()
    {
        while (BattleOngoing)
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

            BattleOngoing = End();
        }
    }
}