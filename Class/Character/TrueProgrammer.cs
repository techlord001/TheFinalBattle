using TheFinalBattle.Class.Character;

public class TrueProgrammer : CharacterBase
{
    public TrueProgrammer() : base("True Programmer")
    {
    }

    public void Rename()
    {
        Console.WriteLine("What is your name True Programmer? ");
        Name = Console.ReadLine() ?? "";
    }
}