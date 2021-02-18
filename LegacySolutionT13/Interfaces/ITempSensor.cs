namespace LegacySolutionT13
{
    public interface ITempSensor
    {
        public IRandom RandomGen { get; set; }
        public int GetTemp();

        public bool RunSelfTest();

    }
}