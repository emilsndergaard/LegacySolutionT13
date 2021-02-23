using LegacySolutionT13;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        private IHeater uut;
        private FakeLogger fakeLogger;
        [SetUp]
        public void Setup()
        {
            fakeLogger = new FakeLogger();
            uut = new Heater(fakeLogger);
        }

        [Test]
        public void TurnOn_CallMethodTurnOn_ResultIsTrue()
        {
           uut.TurnOn();
           Assert.That(fakeLogger.PrintBool, Is.True);
        }

        [Test]
        public void TurnOff_CallMethodTurnOff_ResultIsTrue()
        {
            uut.TurnOff();
            Assert.That(fakeLogger.PrintBool, Is.True);
        }
        [Test]
        public void SelfTest_CallMethodSelfTest_ResultIsTrue()
        {
            bool test;
            test = uut.RunSelfTest();
            Assert.That(test, Is.True);
        }

    }

    public class FakeLogger : ILogger
    {
        public bool PrintBool { get; set; } = false;
        public void PrintOn()
        {
            PrintBool = true;
        }
        public void PrintOff()
        {
            PrintBool = true;
        }

    }
   
}