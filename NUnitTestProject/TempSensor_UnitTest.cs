using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LegacySolutionT13.UnitTest
{
    public class TempSensor_UnitTest
    {
        private ITempSensor uut;

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(40)]
        public void TestGetTemp_ExpextReturnX(int ExpextedValueToReturn)
        {
            uut = new RealTempSensor(new FakeRandom(ExpextedValueToReturn));
            int result =  uut.GetTemp();

           Assert.That(result, Is.EqualTo(ExpextedValueToReturn));
        }

        [Test]
        public void TestRunselftest_ExpectTrue()
        {
            uut = new RealTempSensor(new FakeRandom(1));
            bool retult = uut.RunSelfTest();

            Assert.That(retult, Is.True);
        }

    }
}
