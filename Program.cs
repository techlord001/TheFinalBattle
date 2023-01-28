using System;

namespace TheFinalBattle
{
    internal class Program
    {
        static void Main(string[] args)
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
