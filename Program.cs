using System;

namespace TheFinalBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Skeleton skeleton = new Skeleton();

            GameManager gameManager = new GameManager();

            gameManager.Monsters.Add(skeleton);

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

                Heroes.AddTrueProgrammer();
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
            public void AddTrueProgrammer()
            {
                TrueProgrammer trueProgrammer = new TrueProgrammer();
                trueProgrammer.Rename();
                this.Add(trueProgrammer);
            }
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
