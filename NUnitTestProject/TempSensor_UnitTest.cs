using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LegacySolutionT13.UnitTest
{
    public class TempSensor_UnitTest
    {
        private ITempSensor uut;

        //[SetUp]
        public TempSensor_UnitTest()
        {
            uut = new RealTempSensor(new FakeRandom());
        }

        [Test]
        public void TestGetTemp()
        {
           int result =  uut.GetTemp();

           Assert.That(result, Is.EqualTo(1));

        }


    }
}
