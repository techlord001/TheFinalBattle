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
    }

    public enum Player
    {
        Human,
        Computer
    }
}