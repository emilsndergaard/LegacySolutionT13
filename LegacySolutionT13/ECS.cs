using System.Collections.Generic;
using System.Text;

namespace LegacySolutionT13
{
    public class ECS
    {
        public ITempSensor TempSensor { get; private set; }
        public IHeater Heater { get; private set; }
        private int _threshold;

        public ECS(ITempSensor tempSensor, IHeater heater, int thr)
        {
            TempSensor = tempSensor;
            Heater = heater;
            _threshold = thr;
        }

        public void Regulate()
        {
            
            var t = TempSensor.GetTemp();
            
            if (t < _threshold)
                Heater.TurnOn();
            else
                Heater.TurnOff();
            
        }
        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return TempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return TempSensor.RunSelfTest()  && Heater.RunSelfTest();
        }

    }
}
