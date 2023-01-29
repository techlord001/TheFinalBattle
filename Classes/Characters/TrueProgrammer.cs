namespace Player
{
    public class TrueProgrammer : Character
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
}