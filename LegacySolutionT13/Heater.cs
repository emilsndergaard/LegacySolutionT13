namespace LegacySolutionT13
{
    public class Heater : IHeater
    {
        private ILogger ilLogger;

        public Heater(ILogger ilLogger)
        {
            this.ilLogger = ilLogger;
        }
        public void TurnOn()
        {
            ilLogger.PrintOn();
        }

        public void TurnOff()
        {
            ilLogger.PrintOff();
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}