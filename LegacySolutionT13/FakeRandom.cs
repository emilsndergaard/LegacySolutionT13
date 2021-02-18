namespace LegacySolutionT13
{
    public class FakeRandom : IRandom
    {
        //Allways return 1
        public int GetNext()
        {
            return 1;
        }
    }
}