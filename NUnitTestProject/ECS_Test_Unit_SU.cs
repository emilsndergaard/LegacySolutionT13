using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace LegacySolutionT13.UnitTest
{
    class ECS_Test_Unit_SU
    {
        private ECS uut;
        private IHeater fakeHeater;
        private ITempSensor fakeTempSensor;

        [SetUp]
        public void Setup()
        {
            fakeHeater = Substitute.For<IHeater>();
            fakeTempSensor = Substitute.For<ITempSensor>();
            uut = new ECS(fakeTempSensor, fakeHeater, 50);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(49)]
        public void Regulate_thresholdIs10insertHighX_ExpectTurnOff(int X)
        {
            fakeTempSensor.GetTemp().Returns(X);
            uut.Regulate();
            fakeHeater.Received(1).TurnOn();
        }

        //[TestCase(9)]
        //[TestCase(0)]
        //[TestCase(-1003)]
        //public void Regulate_thresholdIs10insertlowX_ExpectTurnOff(int X)
        //{
        //    MockHeater mh = new MockHeater();
        //    uut = new ECS(new StubTempSensor(X), mh, 10);
        //    uut.Regulate();
        //    Assert.That(mh.isHeaterOn, Is.True);
        //}

        //[TestCase(0, -10)]
        //[TestCase(0, -1)]
        //[TestCase(0, -140)]
        //[TestCase(1, 0)]
        //[TestCase(0, 1)]
        //[TestCase(0, 11)]
        //public void SetThreshold_initiateWithXChangeToY_ThresholdIsY(int X, int Y)
        //{
        //    uut = new ECS(new dummyTemoSensor(), new dummyHeater(), X);
        //    uut.SetThreshold(Y);

        //    Assert.That(uut.GetThreshold(), Is.EqualTo(Y));
        //}

        //[TestCase(-10)]
        //[TestCase(-1)]
        //[TestCase(-140)]
        //[TestCase(0)]
        //[TestCase(1)]
        //[TestCase(11)]
        //public void GetThreshold_initiateWithXChangeToY_ThresholdIsY(int X)
        //{
        //    uut = new ECS(new dummyTemoSensor(), new dummyHeater(), X);

        //    Assert.That(uut.GetThreshold(), Is.EqualTo(X));
        //}

        //[TestCase(-10)]
        //[TestCase(-1)]
        //[TestCase(0)]
        //[TestCase(1)]
        //[TestCase(9)]
        //[TestCase(900)]
        //public void GetCurTemp_StubIsSetToX_CurTempIsX(int X)
        //{
        //    StubTempSensor sts = new StubTempSensor(X);
        //    uut = new ECS(sts, new dummyHeater(), 10);

        //    int result = uut.GetCurTemp();
        //    Assert.That(result, Is.EqualTo(X));
        //}

        //[TestCase(false, false, false)]
        //[TestCase(false, true, false)]
        //[TestCase(true, false, false)]
        //[TestCase(true, true, true)]
        //public void RunSelfTest_StubsSetToXandY_ExpectZ(bool X, bool Y, bool Z)
        //{
        //    StubTempSensor sts = new StubTempSensor(0);
        //    sts.RunSelftestBool = X;
        //    StubHeater sh = new StubHeater();
        //    sh.RunSelftestBool = Y;
        //    uut = new ECS(sts, sh, 10);

        //    bool result = uut.RunSelfTest();

        //    Assert.That(result, Is.EqualTo(Z));

        //}
    }
}
