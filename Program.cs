using System;

namespace TheFinalBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Skeleton skeleton1 = new Skeleton();
            Skeleton skeleton2 = new Skeleton();

            GameManager gameManager = new GameManager();

            gameManager.Heroes.Add(skeleton1);
            gameManager.Monsters.Add(skeleton2);

            gameManager.Start();
        }

        public class GameManager
        {
            public Heroes Heroes { get; set; }
            public Monsters Monsters { get; set; }

            public GameManager()
            {
                Heroes = new Heroes();
                Monsters = new Monsters();
            }

            private void CharacterTurn(Character character)
            {
                Console.WriteLine($"It's {character.Name}'s turn...");
                character.Action();
                Console.WriteLine("");
            }

            public void Start()
            {
                while (true)
                {
                    for (int i = 0; i < Heroes.Characters.Count; i++)
                    {
                        CharacterTurn(Heroes.Characters[i]);
                    }

                    for (int i = 0; i < Monsters.Characters.Count; i++)
                    {
                        CharacterTurn(Monsters.Characters[i]);
                    }
                }
            }
        }

        public class Heroes : Party
        {
        }

        public class Monsters : Party
        {
        }

        public class Party
        {
            public List<Character> Characters { get; private set; }

            public Party()
            {
                Characters = new List<Character>();
            }

            public void Add(params Character[] characters)
            {
                foreach (Character character in characters)
                {
                    Characters.Add(character);
                }
            }
        }

        public class Skeleton : Character
        {
            public Skeleton() : base("SKELETON")
            {
            }
        }

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
}
