using LegacySolutionT13;
using NSubstitute;
using NUnit.Framework;

namespace LecazySolutionT13HH.Test.Unit
{
    public class ECS_Test_Unit
    {
        private ECS uut;
        private IHeater _fakeHeater;
        private ITempSensor _fakeTempSensor; 

        [SetUp]
        public void Setup()
        {
            //Arrange
            _fakeHeater = Substitute.For<IHeater>();
            _fakeTempSensor = Substitute.For<ITempSensor>();
            uut = new ECS(_fakeTempSensor,_fakeHeater,10);
        }

        [TestCase(10)]
        [TestCase(11)]
        [TestCase(1003)]
        public void Regulate_thresholdIs10insertHighX_ExpectTurnOff(int X)
        {
            //Arrange
            _fakeTempSensor.GetTemp().Returns(X);

            //Act
            uut.Regulate();

            //Assert
            _fakeHeater.Received(1).TurnOff();
            
        }

        [TestCase(9)]
        [TestCase(0)]
        [TestCase(-1003)]
        public void Regulate_thresholdIs10insertlowX_ExpectTurnOn(int X)
        {
            //Arrange
            _fakeTempSensor.GetTemp().Returns(X);

            //Act
            uut.Regulate();

            //Assert
            _fakeHeater.Received(1).TurnOn();
        }


        [TestCase(-10)]
        [TestCase(0)]
        [TestCase(-1007)]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(1056)]
        public void SetThreshold_initiateWithXChangeToY_ThresholdIsY( int Y)
        {
            //Arrange
            //Act
            uut.SetThreshold(Y);

            //Act
            Assert.That(uut.GetThreshold(), Is.EqualTo(Y));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(-140)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(11)]
        public void GetThreshold_SetToX_ThresholdIsX(int X)
        {
            //Arrange
            uut.SetThreshold(X);

            //Act
            int result = uut.GetThreshold();

            //Assert
            Assert.That(result, Is.EqualTo(X));
        }

        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(9)]
        [TestCase(900)]
        public void GetCurTemp_StubIsSetToX_CurTempIsX(int X)
        {
            //Arrange
            _fakeTempSensor.GetTemp().Returns(X);
            
            //Act
            int result = uut.GetCurTemp();

            //Assert
            Assert.That(result, Is.EqualTo(X));
        }

        [TestCase(false, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(true, true, true)]
        public void RunSelfTest_StubsSetToXandY_ExpectZ(bool X, bool Y, bool Z)
        {
            //Arrange
            _fakeHeater.RunSelfTest().Returns(X);
            _fakeTempSensor.RunSelfTest().Returns(Y);

            //Act
            bool result = uut.RunSelfTest();

            //Assert
            Assert.That(result, Is.EqualTo(Z));
        }



    }
}
