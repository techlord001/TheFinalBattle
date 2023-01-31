using TheFinalBattle.Class.Party;

public class Heroes : PartyBase
{
    public void AddTrueProgrammer()
    {
        TrueProgrammer trueProgrammer = new TrueProgrammer();
        trueProgrammer.Rename();
        Add(trueProgrammer);
    }
}