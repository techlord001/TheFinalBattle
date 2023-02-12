using TheFinalBattle.Class.Character;
using TheFinalBattle.Class.Party;

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
            if (party.Characters[i]
                .CurrentHP == 0)
            {
                Console.WriteLine($"{party.Characters[i].Name.ToUpper()} has been defeated!");
                party.Characters.Remove(party.Characters[i]);
            }
        }
    }

    public bool End() => Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0 ? true : false;

    public bool Start()
    {
        Console.WriteLine("A new battle begins! Prepare yourself...");
        Thread.Sleep(1000);

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

            BattleOver = End();
        }

        return false;
    }
}