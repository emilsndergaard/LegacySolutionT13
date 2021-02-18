using System;

namespace LegacySolutionT13
{
    public class RandomGen : IRandom
    {
        private Random r;

        public RandomGen()
        {
            r = new Random();
        }
        public int GetNext()
        {
            int value = r.Next(-5,45);
            return value;
        }
    }
}