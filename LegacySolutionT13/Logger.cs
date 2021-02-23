<<<<<<< HEAD
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
=======
﻿using System;
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
>>>>>>> cd93e2b68717d6bf689a95c349c7ba258c09a242
