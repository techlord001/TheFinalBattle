using TheFinalBattle.Class.Party;

namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }
        private string AttackName { get; }

        public CharacterBase(string name, string attack)
        {
            Name = name;
            AttackName = attack;
        }

        public void PlayerAction(Player player, PartyBase enemyParty)
        {
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
                        Action.Attack(Name, AttackName, enemyParty.Selection().Name);
                        Thread.Sleep(500);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(Name);
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

                switch ((PlayerAction)random.Next(Enum.GetNames(typeof(PlayerAction)).Length))
                {
                    case Character.PlayerAction.Attack:
                        Action.Attack(Name, AttackName, enemyParty.Characters[random.Next(enemyParty.Characters.Count)].Name);
                        Thread.Sleep(500);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(Name);
                        Thread.Sleep(500);
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