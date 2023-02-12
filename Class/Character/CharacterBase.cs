using TheFinalBattle.Class.Party;

namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }
        private AttackType AttackType { get; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public CharacterBase(string name, AttackType attackType, int maxHP)
        {
            Name = name;
            AttackType = attackType;
            MaxHP = maxHP;
            CurrentHP = maxHP;
        }

        public void PlayerAction(Player player, PartyBase enemyParty)
        {
            Console.WriteLine($"It's {Name.ToUpper()}'s turn...");
            Console.WriteLine("");

            if (player == Player.Human)
            {
                Console.WriteLine("Enter a number to perform one of the following options: ");

                for (int i = 0; i < Enum.GetNames(typeof(PlayerAction)).Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {Enum.GetName(typeof(PlayerAction), i)}");
                }

                switch ((PlayerAction)Convert.ToInt32(Console.ReadLine()) - 1)
                {
                    case Character.PlayerAction.Attack:
                        Action.Attack(Name, AttackType, enemyParty.Selection());
                        Thread.Sleep(1000);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(Name);
                        Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            }
            else if (player == Player.Computer)
            {
                Random random = new Random();

                Console.WriteLine("Calculating move...");
                Thread.Sleep(1000);

                switch ((PlayerAction)random.Next(Enum.GetNames(typeof(PlayerAction)).Length))
                {
                    case Character.PlayerAction.Attack:
                        Action.Attack(Name, AttackType, enemyParty.Characters[random.Next(enemyParty.Characters.Count)]);
                        Thread.Sleep(1000);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(Name);
                        Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public enum PlayerAction
    {
        Attack,
        Nothing
    }
}