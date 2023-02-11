using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

public class GameManager
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    private Battle? NewBattle { get; set; }

    private int totalRounds = 2;
    private int currentRound = 0;

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
    }

    private bool End()
    {
        if (Heroes.Characters.Count == 0)
        {
            Console.WriteLine("All the heroes have been defeated. All hope is lost! The Uncoded One & his forces have prevailed!");
            return true;
        }

        if (Monsters.Characters.Count == 0 && currentRound == totalRounds)
        {
            Console.WriteLine($"The Uncoded One and his minions have been defeated! You, {Heroes.Characters[0].Name.ToUpper()} have won the day and saved these realms! You are the True Programmer of legend!");
            return true;
        }

        return false;
    }

    public void Start()
    {
        for (int i = 0; i < totalRounds; i++)
        {
            currentRound++;

            for (int j = 0; j < currentRound; j++)
            {
                Monsters.Add(new Skeleton());
            }

            NewBattle = new Battle(Heroes, Monsters);

            if (!NewBattle.Start())
            {
                if (End())
                {
                    break;
                }

                continue;
            }
        }

    }
}
