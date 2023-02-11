using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class Round
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    public Round(Heroes heroes, Monsters monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    private void CharacterTurn(CharacterBase character, Player player)
    {
        Console.WriteLine($"It's {character.Name}'s turn...");
        character.Action(player);
        Console.WriteLine("");
    }

    public void Start()
    {
        while (true)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                CharacterTurn(Heroes.Characters[i], Heroes.Player);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                CharacterTurn(Monsters.Characters[i], Monsters.Player);
            }
        }
    }
}