using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class Battle
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    public Battle(Heroes heroes, Monsters monsters)
    {
        Heroes = heroes;
        Monsters = monsters;
    }

    private void CharacterTurn(CharacterBase character, Player player, PartyBase enemyParty)
    {
        Console.WriteLine($"It's {character.Name.ToUpper()}'s turn...");
        character.PlayerAction(player, enemyParty);
        Console.WriteLine("");
    }

    public void Start()
    {
        while (true)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                CharacterTurn(Heroes.Characters[i], Heroes.Player, Monsters);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                CharacterTurn(Monsters.Characters[i], Monsters.Player, Heroes);
            }
        }
    }
}