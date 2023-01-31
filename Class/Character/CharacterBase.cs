using TheFinalBattle.Class.Party;

namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }

        public CharacterBase(string name)
        {
            Name = name;
        }

        public void Action(Player player)
        {
            if (player == Player.Human)
            {
                Console.WriteLine("Enter a number to perform one of the following options: ");

                for (int i = 0; i < Enum.GetNames(typeof(Action)).Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {Enum.GetName(typeof(Action), i)}");
                }

                switch ((Action)Convert.ToInt32(Console.ReadLine()) - 1)
                {
                    case Character.Action.Nothing:
                        Console.WriteLine($"{Name} did NOTHING");
                        Thread.Sleep(500);
                        break;
                    default:
                        break;
                }
            }
            else if (player == Player.Computer)
            {
                Random random = new Random();

                Console.WriteLine("Calculating move...");
                Thread.Sleep(500);

                switch ((Action)random.Next(Enum.GetNames(typeof(Action)).Length))
                {
                    case Character.Action.Nothing:
                        Console.WriteLine($"{Name} did NOTHING");
                        Thread.Sleep(500);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public enum Action
    {
        Nothing
    }
}