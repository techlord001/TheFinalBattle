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
        for (int i = 0; i < party.Characters.Count; i++)
        {
            if (party.Characters[i].CurrentHP == 0)
            {
                Message.WriteLine($"{party.Characters[i].Name.ToUpper()} has been defeated!", ConsoleColor.Magenta);
                party.Characters.Remove(party.Characters[i]);
            }
        }
    }

    private void Status(CharacterBase player)
    {
        Message.WriteLine(("").PadRight(30, '=') + " BATTLE " + ("").PadRight(30, '='), ConsoleColor.White);

        foreach (CharacterBase character in Heroes.Characters)
        {
            if (character == player)
            {
                Message.WriteLine($"{character.Name, -20}* ( {character.CurrentHP}/{character.MaxHP} )", ConsoleColor.Blue);
            }
            else
            {
                Message.WriteLine($"{character.Name, -20} ( {character.CurrentHP}/{character.MaxHP} )", ConsoleColor.Blue);
            }
        }

        Message.WriteLine(("").PadRight(32, '-') + " VS " + ("").PadRight(32, '-'), ConsoleColor.White);

        foreach (CharacterBase character in Monsters.Characters)
        {
            if (character == player)
            {
                Message.WriteLine($"{character.Name, 58}* ( {character.CurrentHP}/{character.MaxHP} )", ConsoleColor.Red);
            }
            else
            {
                Message.WriteLine($"{character.Name, 59} ( {character.CurrentHP}/{character.MaxHP} )", ConsoleColor.Red);
            }
        }

        Message.WriteLine(("").PadRight(68, '='), ConsoleColor.White);
    }

    public bool Start()
    {
        Message.WriteLine("A new battle begins! Prepare yourself...", ConsoleColor.White);

        while (!BattleOver)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                Status(Heroes.Characters[i]);
                Heroes.Characters[i].PlayerAction(Heroes.Player, Monsters);
                EnemyHealthCheck(Monsters);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                Status(Monsters.Characters[i]);
                Monsters.Characters[i].PlayerAction(Monsters.Player, Heroes);
                EnemyHealthCheck(Heroes);
            }

            BattleOver = Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;
        }

        return false;
    }
}