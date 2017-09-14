using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _07.Hack.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public Mock<IMath> mathMock;
        public const double number = -17.3d;

        [TestInitialize]
        public void InitializeMock()
        {
            mathMock = new Mock<IMath>();
            mathMock
                .Setup(x => x.Abs(It.IsAny<double>()))
                .Returns<double>(Math.Abs);


            mathMock
                .Setup(n => n.Floor(It.IsAny<double>()))
                .Returns<double>(Math.Floor);
        }

        [TestMethod]
        public void TestMathAbs()
        {
            IMath absMath = this.mathMock.Object;
            var resultAbs = absMath.Abs(number);
            Assert.AreEqual(resultAbs, 17.3);
        }

        [TestMethod]
        public void TestMathFloor()
        {
            IMath floorMath = this.mathMock.Object;
            var resultFloor = floorMath.Floor(number);
            Assert.AreEqual(resultFloor, -18);
        }
    }
}