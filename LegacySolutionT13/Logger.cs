
﻿namespace LegacySolutionT13
{
    public class Logger : ILogger
    {
        public void PrintOn()
        {
            System.Console.WriteLine("Heater is on");
            

        }

        public void PrintOff()
        {
            System.Console.WriteLine("Heater is off");
            
        }
    }
}
