using TheFinalBattle.Class.Items;
using TheFinalBattle.Class.Party;

public class Monsters : PartyBase
{
    public Monsters() 
    {
        for (int i = 0; i < 1; i++)
        {
            Inventory.Add(new HealthPotion());
        }
    }
}