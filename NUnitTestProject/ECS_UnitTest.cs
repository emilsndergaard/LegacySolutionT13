using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using LegacySolutionT13;

namespace LegacySolutionT13.UnitTest
{
    class ECS_UnitTest
    {
        private ECS uut;
       
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(1003)]
        public void Regulate_thresholdIs10insertHighX_ExpectTurnOff(int X)
        {
            MockHeater mh = new MockHeater();
            uut = new ECS(new StubTempSensor(X), mh,10);
            uut.Regulate();
            Assert.That(mh.isHeaterOff, Is.True);
        }


        class MockHeater : IHeater
        {
            public bool isHeaterOff;
            public void TurnOn(){}

            public void TurnOff()
            {
                isHeaterOff = true;
            }

            bool IHeater.RunSelfTest()
            {
                throw new NotImplementedException();
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }

        class StubTempSensor : ITempSensor
        {
            public IRandom RandomGen { get; set; }
            private int _temp;

            public StubTempSensor(int temp)
            {
                _temp = temp;

            }

            public int GetTemp()
            {
                return 1;
                //return temp;
            }

            public bool RunSelfTest()
            {
                return true;
            }

    } 
    }
}
