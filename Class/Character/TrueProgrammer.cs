using TheFinalBattle.Class.Character;

public class TrueProgrammer : CharacterBase
{
    public TrueProgrammer() : base("True Programmer", new AttackType("Punch", 1), 25)
    {
    }

    public void Rename()
    {
        Console.WriteLine("What is your name True Programmer? ");
        Name = Console.ReadLine() ?? "";
    }
}