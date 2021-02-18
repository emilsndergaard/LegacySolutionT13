using LegacySolutionT13;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        private IHeater uut;
        [SetUp]
        public void Setup()
        {
            uut = new Heater();
        }

        [Test]
        public void TurnOn_CallMethodTurnOn_ResultIsTrue()
        {
            uut.TurnOn();
            //Assert.That(uut.);
        }
    }

    class FakeHeater : IHeater
    {
        public bool YesIHaveBeenCalledUpOnTurnOn { get; set; } = false;
        public bool YesIHaveBeenCalledUpOnTurnOff { get; set; }= false;
        public bool YesIHaveBeenCalledUpOnTurnTest { get; set; } = false;
        public void TurnOn()
        {
            YesIHaveBeenCalledUpOnTurnOn = true;
        }

        public void TurnOff()
        {
            YesIHaveBeenCalledUpOnTurnOff = true;
        }

        public bool RunSelfTest()
        {
           return YesIHaveBeenCalledUpOnTurnTest = true;
        }
    }
}