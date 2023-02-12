using TheFinalBattle.Class.Party;
using Utilities;

namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }
        public AttackType AttackType { get; }
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
            Message.WriteLine($"It's {Name.ToUpper()}'s turn...", ConsoleColor.Blue);

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
                        Action.Attack(this, enemyParty.Selection());
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(this);
                        break;
                    default:
                        break;
                }
            }
            else if (player == Player.Computer)
            {
                Random random = new Random();

                Message.WriteLine("Calculating move...", ConsoleColor.Yellow);

                switch ((PlayerAction)random.Next(Enum.GetNames(typeof(PlayerAction)).Length))
                {
                    case Character.PlayerAction.Attack:
                        Action.Attack(this, enemyParty.Characters[random.Next(enemyParty.Characters.Count)]);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(this);
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