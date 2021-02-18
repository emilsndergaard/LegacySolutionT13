namespace LegacySolutionT13
{
    public class RealTempSensor : ITempSensor
    {
        public IRandom RandomGen { get; set; }

        public RealTempSensor(IRandom random)
        {
            RandomGen = random;
        }

        public int GetTemp()
        {
            return RandomGen.GetNext();
        }

        public bool RunSelfTest()
        {
            return true;
        }

    }
}