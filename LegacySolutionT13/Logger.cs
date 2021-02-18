using System;
using System.Collections.Generic;
using System.Text;

namespace LegacySolutionT13
{
    public class Logger : ILogger
    {
        public string SpringTurnOn()
        {
            return "Heater is on";
        }

        public string SpringTurnOff()
        {
            return "Heater is off";
        }
    }
}
