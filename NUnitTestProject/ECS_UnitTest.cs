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

        [TestCase(9)]
        [TestCase(0)]
        [TestCase(-1003)]
        public void Regulate_thresholdIs10insertlowX_ExpectTurnOff(int X)
        {
            MockHeater mh = new MockHeater();
            uut = new ECS(new StubTempSensor(X), mh, 10);
            uut.Regulate();
            Assert.That(mh.isHeaterOn, Is.True);
        }

        [TestCase(0,-10)]
        [TestCase(0, -1)]
        [TestCase(0, -140)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 11)]
        public void SetThreshold_initiateWithXChangeToY_ThresholdIsY(int X, int Y)
        {
            uut = new ECS(new dummyTemoSensor(), new dummyHeater(), X);
            uut.SetThreshold(Y);

            Assert.That(uut.GetThreshold(),Is.EqualTo(Y));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(-140)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase( 11)]
        public void GetThreshold_initiateWithXChangeToY_ThresholdIsY(int X)
        {
            uut = new ECS(new dummyTemoSensor(), new dummyHeater(), X);

            Assert.That(uut.GetThreshold(), Is.EqualTo(X));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(9)]
        [TestCase(900)]
        public void GetCurTemp_StubIsSetToX_CurTempIsX(int X)
        {
            StubTempSensor sts = new StubTempSensor(X);
            uut = new ECS(sts, new dummyHeater(), 10);

            int result = uut.GetCurTemp();
            Assert.That(result, Is.EqualTo(X));
        }

        [TestCase(false,false,false)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(true,true,true)]
        public void RunSelfTest_StubsSetToXandY_ExpectZ(bool X, bool Y, bool Z)
        {
            StubTempSensor sts = new StubTempSensor(0);
            sts.RunSelftestBool = X;
            StubHeater sh = new StubHeater();
            sh.RunSelftestBool = Y;
            uut = new ECS(sts,sh,10);

            bool result = uut.RunSelfTest();

            Assert.That(result, Is.EqualTo(Z));

        }



        #region Fakes
        //Til regulate
        class MockHeater : IHeater
        {
            public bool isHeaterOff;
            public bool isHeaterOn;

            public void TurnOn()
            {
                isHeaterOn = true;
            }

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
            public bool RunSelftestBool { get; set; }
            private int _temp;

            public StubTempSensor(int temp)
            {
                _temp = temp;

            }

            public int GetTemp()
            {
                return _temp;
            }

            public bool RunSelfTest()
            {
                return RunSelftestBool;
            }

        }

        //Til set og get threshold
        class dummyTemoSensor : ITempSensor
        {
            public IRandom RandomGen { get; set; }
            public int GetTemp()
            {
                return 0;
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }
        class dummyHeater : IHeater
        {
            public void TurnOn()
            {
            }

            public void TurnOff()
            {
             
            }

            public bool RunSelfTest()
            {
                return true;
            }
        }

        //Til selfregulation
        class StubHeater : IHeater
        {
            public bool RunSelftestBool { get; set; }
            public void TurnOn()
            {
                
            }

            public void TurnOff()
            {
                
            }

            public bool RunSelfTest()
            {
                return RunSelftestBool;
            }
        }

        #endregion

    }
}
