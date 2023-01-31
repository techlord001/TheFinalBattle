namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }

        public CharacterBase(string name)
        {
            Name = name;
        }

        public void Action()
        {
            Console.WriteLine($"{Name} did NOTHING");
            Thread.Sleep(500);
        }
        //enum Action
        //{
        //    Nothing
        //}
    }
}