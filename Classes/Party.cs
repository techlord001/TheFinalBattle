using Player;

namespace PlayerGroup
{
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
}