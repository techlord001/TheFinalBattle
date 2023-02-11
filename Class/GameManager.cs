using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class GameManager
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    private Battle? NewBattle { get; set; }

    public GameManager()
    {
        Heroes = new Heroes();
        Monsters = new Monsters();

        GameSetup();
    }

    private void GameSetup()
    {
        Console.WriteLine("Select your game: ");
        Console.WriteLine("1 - P1 vs AI");
        Console.WriteLine("2 - P1 vs P2");
        Console.WriteLine("3 - AI vs AI");

        (Heroes.Player, Monsters.Player) = Console.ReadLine() switch
        {
            "1" => (Player.Human, Player.Computer),
            "2" => (Player.Human, Player.Human),
            "3" => (Player.Computer, Player.Computer),
            _ => (Player.Computer, Player.Computer)
        };

        Heroes.AddTrueProgrammer();

        Monsters.Add(new Skeleton());
    }

    public void Start()
    {
        NewBattle = new Battle(Heroes, Monsters);

        NewBattle.Start();
    }
}
