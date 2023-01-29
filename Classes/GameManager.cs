using Player;
using PlayerGroup;

public class GameManager
{
    public Heroes Heroes { get; set; }
    public Monsters Monsters { get; set; }

    public GameManager()
    {
        Heroes = new Heroes();
        Monsters = new Monsters();

        Heroes.AddTrueProgrammer();
    }

    private void CharacterTurn(Character character)
    {
        Console.WriteLine($"It's {character.Name}'s turn...");
        character.Action();
        Console.WriteLine("");
    }

    public void Start()
    {
        while (true)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                CharacterTurn(Heroes.Characters[i]);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                CharacterTurn(Monsters.Characters[i]);
            }
        }
    }
}
