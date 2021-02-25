using LegacySolutionT13;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestProjectÉµil
{
    public class TestsECS
    {

        private ECS uut;
        private IHeater heater;
        private ITempSensor tempSensor;
        [SetUp]
        public void Setup()
        {
            heater = Substitute.For<IHeater>();
            tempSensor = Substitute.For<ITempSensor>();
           
        }


        [TestCase(10)]
        [TestCase(11)]
        [TestCase(1003)]
        public void Regulate_thresholdIs10insertHighX_ExpectTurnOff(int X)
        {
            uut = new ECS(tempSensor, heater, 10);
            tempSensor.GetTemp().Returns(X);
            uut.Regulate();
            heater.Received(1).TurnOff();
        }

        [TestCase(10)]
        [TestCase(11)]
        [TestCase(1003)]
        public void Regulate_thresholdIs1004insertLowX_ExpectTurnOn(int X)
        {
            uut = new ECS(tempSensor, heater, 1004);
            tempSensor.GetTemp().Returns(X);
            uut.Regulate();
            heater.Received(1).TurnOn();
        }
        [TestCase(0, -10)]
        [TestCase(0, -1)]
        [TestCase(0, -140)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 11)]
        public void SetThreshold_initiateWithXChangeToY_ThresholdIsY(int X, int Y)
        {
            uut = new ECS(tempSensor, heater, X);
            uut.SetThreshold(Y);
            Assert.That(uut.GetThreshold(), Is.EqualTo(Y));
        }
        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(-140)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(11)]
        public void GetThreshold_initiateWithXChangeToY_ThresholdIsY(int X)
        {
            uut = new ECS(tempSensor, heater, X);
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
            uut = new ECS(tempSensor, heater, 10);
            tempSensor.GetTemp().Returns(X);
            int result = uut.GetCurTemp();
            Assert.That(result, Is.EqualTo(X));
        }

        [TestCase(false, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(true, true, true)]
        public void RunSelfTest_StubsSetToXandY_ExpectZ(bool X, bool Y, bool Z)
        {
            uut = new ECS(tempSensor, heater, 10);
            tempSensor.RunSelfTest().Returns(X);
            heater.RunSelfTest().Returns(Y);
            Assert.That(uut.RunSelfTest, Is.EqualTo(Z));

        }


    }

    public class TestsTemp
    {
        private ECS uut;
        private IHeater heater;
        private ITempSensor tempSensor;

        [SetUp]
        public void Setup()
        {
            heater = Substitute.For<IHeater>();
            tempSensor = Substitute.For<ITempSensor>();

        }
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(1003)]
        public void Regulate_thresholdIs10insertHighX_ExpectTurnOff(int X)
        {
            uut = new ECS(tempSensor, heater, 10);
            tempSensor.GetTemp().Returns(X);
            uut.Regulate();
            heater.Received(1).TurnOff();
        }
    }
}