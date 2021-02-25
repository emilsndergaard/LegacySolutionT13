using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;

namespace LegacySolutionT13.UnitTest
{
    public class ECS_UnitTest_MEN
    {


        [SetUp]
        public void Setup()
        {

        }

        [TestCase(true,true,true)]       
        [TestCase(true,false,false)]
        [TestCase(false,true,false)]
        [TestCase(false,false,false)]
        public void TestSelfTest(bool Heater,bool Temp, bool expeted)
        {
            //Arrange
            var subHeater = NSubstitute.Substitute.For<IHeater>();
            var subTemp = NSubstitute.Substitute.For<ITempSensor>();

            var uut = new ECS(subTemp, subHeater, 3);


            //Arrange stub
            subHeater.RunSelfTest().Returns(Heater);
            subTemp.RunSelfTest().Returns(Temp);


            //Act / Assert
            Assert.That(uut.RunSelfTest(),Is.EqualTo(expeted));

        }

        [TestCase(11,1)]
        [TestCase(12,1)]
        [TestCase(13,0)]
        [TestCase(14,0)]
        public void TestRegulate_WithDefirentTemp_ButStaticThresholdAt13(int GetTempReturn,int expectedOutput) 
        {
            //Arrange
            var subHeater = NSubstitute.Substitute.For<IHeater>();
            var subTemp = NSubstitute.Substitute.For<ITempSensor>();

            var uut = new ECS(subTemp, subHeater, 13);

            subTemp.GetTemp().Returns(GetTempReturn);


            //Act
            uut.Regulate();


            //Assert
            subHeater.Received(expectedOutput).TurnOn();

        }

    }
}
