public class TrueProgrammer : CharacterBase
{
    public TrueProgrammer() : base("The True Programmer", new AttackType("Punch", 1), 25)
    {
    }

    public void Rename()
    {
        Console.WriteLine("What is your name True Programmer? ");
        string? name = Console.ReadLine();
        Name = String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) ? Name : name;
    }
}