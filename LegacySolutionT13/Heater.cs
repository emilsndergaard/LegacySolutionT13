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
<<<<<<< HEAD
            ilLogger.PrintOn();
=======
            System.Console.WriteLine("Heater is off");
>>>>>>> cd93e2b68717d6bf689a95c349c7ba258c09a242
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