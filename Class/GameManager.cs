using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class GameManager
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    public GameManager()
    {
        Heroes = new Heroes();
        Monsters = new Monsters();

        PartyCreation();
    }

    private void PartyCreation()
    {
        Console.WriteLine("Are the Heroes human-controlled? Y or N");
        Heroes.Player = Console.ReadLine() switch
        {
            "Y" => Player.Human,
            "N" => Player.Computer,
            _ => Player.Computer
        };
        Console.WriteLine("Are the Monsters human-controlled? Y or N");
        Monsters.Player = Console.ReadLine() switch
        {
            "Y" => Player.Human,
            "N" => Player.Computer,
            _ => Player.Computer
        };

        Heroes.AddTrueProgrammer();

        Monsters.Add(new Skeleton());
    }

    private void CharacterTurn(CharacterBase character)
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
