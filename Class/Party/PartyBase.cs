using TheFinalBattle.Class.Character;

namespace TheFinalBattle.Class.Party
{
    public class PartyBase
    {
        public List<CharacterBase> Characters { get; private set; }
        public Player Player { get; set; }

        public PartyBase()
        {
            Characters = new List<CharacterBase>();
        }

        public void Add(params CharacterBase[] characters)
        {
            foreach (CharacterBase character in characters)
            {
                Characters.Add(character);
            }
        }

        public CharacterBase Selection()
        {
            Console.WriteLine("Select which enemy you'd like to attack: ");

            for (int i = 0; i < Characters.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Characters[i].Name.ToUpper()}");
            }

            return Characters[Convert.ToInt32(Console.ReadLine()) - 1];
        }
    }

    public enum Player
    {
        Human,
        Computer
    }
}