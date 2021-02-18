namespace LegacySolutionT13
{
    public class FakeRandom : IRandom
    {
        public int GetNext()
        {
            return 1;
        }
    }
}