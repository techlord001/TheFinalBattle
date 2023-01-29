namespace Player
{
    public abstract class Character
    {
        public string Name { get; set; }

        public Character(string name)
        {
            Name = name;
        }

        public void Action()
        {
            Console.WriteLine($"{Name} did NOTHING");
            Thread.Sleep(500);
        }
    }
}