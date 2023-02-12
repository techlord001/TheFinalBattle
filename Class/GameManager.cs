public class GameManager
{
    private Heroes Heroes { get; set; }
    private Monsters Monsters { get; set; }

    private Battle? NewBattle { get; set; }

    private int totalRounds = 3;
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
            string loseMessage = "All the heroes have been defeated. All hope is lost! The Uncoded One & his forces have prevailed!";
            Message.WriteLine(loseMessage, ConsoleColor.DarkRed);
            return true;
        }

        if (Monsters.Characters.Count == 0 && currentRound == totalRounds)
        {
            string winMessage = $"The Uncoded One and his minions have been defeated! You, {Heroes.Characters[0].Name.ToUpper()} have won the day and saved these realms! You are the True Programmer of legend!";
            Message.WriteLine(winMessage, ConsoleColor.Cyan);
            return true;
        }

        return false;
    }

    public void Start()
    {
        for (int i = 0; i < totalRounds; i++)
        {
            currentRound++;

            if (currentRound == 1)
            {
                Monsters.Add(new Skeleton());
            }
            else if (currentRound == 2)
            {
                Monsters.Add(new Skeleton());
                Monsters.Add(new Skeleton());
            }
            else if (currentRound == 3)
            {
                Monsters.Add(new UncodedOne());
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
