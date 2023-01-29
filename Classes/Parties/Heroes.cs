using Player;

namespace PlayerGroup
{
    public class Heroes : Party
    {
        public void AddTrueProgrammer()
        {
            TrueProgrammer trueProgrammer = new TrueProgrammer();
            trueProgrammer.Rename();
            Add(trueProgrammer);
        }
    }
}