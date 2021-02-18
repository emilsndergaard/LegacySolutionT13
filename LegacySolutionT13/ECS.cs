using System.Collections.Generic;
using System.Text;

namespace LegacySolutionT13
{
    public class ECS
    {
        public ITempSensor _tempSensor { get; private set; }
        //public IHeater _Heater { get; private set; }
        private int _threshold;

        public ECS(ITempSensor tempSensor, /*IHeater heater,*/ int thr)
        {
            _tempSensor = tempSensor;
            //_Heater = heater;
            _threshold = thr;
        }

        public void Regulate()
        {
            
            var t = _tempSensor.GetTemp();
            /*
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
            */
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
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() /* && _heater.RunSelfTest()*/;
        }

    }
}
