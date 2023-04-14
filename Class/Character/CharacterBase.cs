using System.IO;
using System;
using TheFinalBattle.Class.Party;
using Utilities;

namespace TheFinalBattle.Class.Character
{
    public abstract class CharacterBase
    {
        public string Name { get; set; }
        public AttackType StandardAttack { get; }
        public int MaxHP { get; set; }

        private int _currentHP;
        public int CurrentHP 
        {
            get => _currentHP; 
            set => _currentHP = Math.Clamp(value, 0, MaxHP);
        }

        /// <summary>
        /// The class from which all other characters derive, requires 3 params for its constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="attackType"></param>
        /// <param name="maxHP"></param>
        public CharacterBase(string name, AttackType standardAttack, int maxHP)
        {
            Name = name;
            StandardAttack = standardAttack;
            MaxHP = maxHP;
            CurrentHP = maxHP;
        }

        public void PlayerAction(PartyBase party, PartyBase enemyParty)
        {
            Message.WriteLine($"It's {Name.ToUpper()}'s turn...", ConsoleColor.Blue);

            if (party.Player == Player.Human)
            {
                Console.WriteLine("Enter a number to perform one of the following options: ");

                for (int i = 0; i < Enum.GetNames(typeof(PlayerAction)).Length; i++)
                {
                    // Don't show 'Use Item' as an option if inventory is empty
                    if (Enum.GetName(typeof(PlayerAction), i).Equals(Character.PlayerAction.UseItem) && party.Inventory.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"{i + 1} - {Enum.GetName(typeof(PlayerAction), i)}");
                }

                switch ((PlayerAction)Convert.ToInt32(Console.ReadLine()) - 1)
                {
                    case Character.PlayerAction.Attack:
                        Action.Attack(this, enemyParty.Selection());
                        break;
                    case Character.PlayerAction.UseItem:
                        Action.UseItem(party, enemyParty);
                        break;
                    case Character.PlayerAction.Nothing:
                        Action.Nothing(this);
                        break;
                    default:
                        break;
                }
            }
            else if (party.Player == Player.Computer)
            {
                Random random = new Random();

                Message.WriteLine("Calculating move...", ConsoleColor.Yellow);
                
                computerAction(party, enemyParty);
            }
        }

        private void computerAction(PartyBase party, PartyBase enemyParty)
        {
            Random random = new Random();

            switch ((PlayerAction)random.Next(Enum.GetNames(typeof(PlayerAction)).Length))
            {
                case Character.PlayerAction.Attack:
                    Action.Attack(this, enemyParty.Characters[random.Next(enemyParty.Characters.Count)]);
                    break;
                case Character.PlayerAction.UseItem:
                    if (party.Inventory.Count > 0)
                    {
                        Action.UseItem(party, enemyParty);
                    }
                    else
                    {
                        computerAction(party, enemyParty);
                    }
                    break;
                case Character.PlayerAction.Nothing:
                    Action.Nothing(this);
                    break;
                default:
                    break;
            }
        }
    }

    public enum PlayerAction
    {
        Nothing,
        Attack,
        UseItem
    }
}