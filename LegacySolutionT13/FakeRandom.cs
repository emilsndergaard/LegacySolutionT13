namespace LegacySolutionT13
{
    public class FakeRandom : IRandom
    {
        private readonly int _valueToReturn;
        /// <summary>
        /// Denne klasse den værdi der indtastes i Ctors parameter
        /// </summary>
        /// <param name="valueToReturn"></param>
        public FakeRandom(int valueToReturn)
        {
            _valueToReturn = valueToReturn;
        }
        
        public int GetNext()
        {
            return _valueToReturn;
        }
    }
}