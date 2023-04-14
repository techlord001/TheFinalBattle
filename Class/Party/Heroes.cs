using TheFinalBattle.Class.Items;

public class Heroes : PartyBase
{
    public Heroes() 
    {
        for (int i = 0; i < 3; i++) 
        {
            Inventory.Add(new HealthPotion());
        }
    }

    public void AddTrueProgrammer()
    {
        TrueProgrammer trueProgrammer = new TrueProgrammer();
        trueProgrammer.Rename();
        Add(trueProgrammer);
    }
}