using System;
using System.Collections.Generic;
using System.Text;
using LegacySolutionT13;
using NUnit.Framework;
using NSubstitute;

namespace LegacySolutionT13.UnitTest
{
    class SU_Test_Unit
    {
        private IHeater uut;
        private ILogger fakeLogger;

        [SetUp]
        public void Setup()
        {
            fakeLogger = Substitute.For<ILogger>();
            uut = new Heater(fakeLogger);
        }

        [Test]
        public void TurnOn_CallMethodTurnOn_ResultIsTrue()
        {
            uut.TurnOn();
            fakeLogger.Received(1).PrintOn();
        }

        [Test]
        public void TurnOff_CallMethodTurnOff_ResultIsTrue()
        {
            uut.TurnOff();
            fakeLogger.Received(1).PrintOff();
        }
        [Test]
        public void SelfTest_CallMethodSelfTest_ResultIsTrue()
        {
            uut.RunSelfTest();
            Assert.IsTrue(uut.RunSelfTest());
        }

    }

  
}

