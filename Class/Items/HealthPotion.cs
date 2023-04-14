using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalBattle.Class.Items
{
    internal class HealthPotion : Item
    {
        public string Name { get; }
        private int Health { get; }

        public HealthPotion() 
        {
            Name = "Health Potion";
            Health = 10;
        }

        public void consumeItem(PartyBase party, PartyBase enemyParty)
        {
            if (party.Player == Player.Computer)
            {
                for (int i = 0; i < party.Characters.Count; i++)
                {
                    if (party.Characters[i].CurrentHP < party.Characters[i].MaxHP / 2)
                    {
                        party.Characters[i].CurrentHP += Health;
                        Message.WriteLine($"{party.Characters[i].Name} used {Name}.", ConsoleColor.DarkRed);
                        Message.WriteLine($"{party.Characters[i].Name} is now at {party.Characters[i].CurrentHP}/{party.Characters[i].MaxHP}HP", ConsoleColor.Blue);
                        break;
                    }
                }
            }
            else
            {
                Message.Write("Which party member would you like to apply the Health Potion to (this will restore upto 10HP)?", ConsoleColor.Green);

                for (int i = 0; i < party.Characters.Count; i++)
                {
                    Message.Write($"{i + 1} - {party.Characters[i].Name}");
                }

                int choice = Convert.ToInt32(Console.ReadLine());

                party.Characters[choice - 1].CurrentHP += Health;

                Message.WriteLine($"{party.Characters[choice - 1].Name} used {Name}.", ConsoleColor.DarkRed);
                Message.WriteLine($"{party.Characters[choice - 1].Name} is now at {party.Characters[choice - 1].CurrentHP}/{party.Characters[choice - 1].MaxHP}HP", ConsoleColor.Blue);
            }
            

        }
    }
}
