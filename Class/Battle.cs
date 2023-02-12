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

    public bool Start()
    {
        Message.WriteLine("A new battle begins! Prepare yourself...", ConsoleColor.White);

        while (!BattleOver)
        {
            for (int i = 0; i < Heroes.Characters.Count; i++)
            {
                Heroes.Characters[i].PlayerAction(Heroes.Player, Monsters);
                EnemyHealthCheck(Monsters);
            }

            for (int i = 0; i < Monsters.Characters.Count; i++)
            {
                Monsters.Characters[i].PlayerAction(Monsters.Player, Heroes);
                EnemyHealthCheck(Heroes);
            }

            BattleOver = Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0;
        }

        return false;
    }
}