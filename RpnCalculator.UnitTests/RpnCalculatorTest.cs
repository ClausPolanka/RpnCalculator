using NSubstitute;
using NUnit.Framework;

namespace RpnCalculator.UnitTests
{
    [TestFixture]
    public class RpnCalculatorTest
    {
        [Test]
        public void AddThreeNumbers()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Add();
            sut.Pressed(4.0);
            sut.Add();
            displayMock.Received(2).Show(1.0);
            displayMock.Received(1).Show(2.0);
            displayMock.Received(1).Show(3.0);
            displayMock.Received(1).Show(4.0);
            displayMock.Received(1).Show(7.0);
        }

        [Test]
        public void SubtractThreeNumbers()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(3.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Subtract();
            sut.Pressed(5.0);
            sut.Subtract();
            displayMock.Received(2).Show(3.0);
            displayMock.Received(1).Show(2.0);
            displayMock.Received(1).Show(1.0);
            displayMock.Received(1).Show(5.0);
            displayMock.Received(1).Show(-4.0);
        }

        [Test]
        public void MultiplyThreeNumbers()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(3.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Multiply();
            sut.Pressed(5.0);
            sut.Multiply();
            displayMock.Received(2).Show(3.0);
            displayMock.Received(1).Show(2.0);
            displayMock.Received(1).Show(6.0);
            displayMock.Received(1).Show(5.0);
            displayMock.Received(1).Show(30.0);
        }

        [Test]
        public void DivideThreeNumbers()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(10.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Divide();
            sut.Pressed(2.0);
            sut.Divide();
            displayMock.Received(2).Show(10.0);
            displayMock.Received(2).Show(2.0);
            displayMock.Received(1).Show(5.0);
            displayMock.Received(1).Show(2.5);
        }

        [Test]
        public void AddOneNumberWithoutEnter()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Add();
            displayMock.Received(2).Show(1.0);
        }
        
        [Test]
        public void SubtractOneNumberWithoutEnter()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Subtract();
            displayMock.Received(1).Show(1.0);
            displayMock.Received(1).Show(-1.0);
        }

        [Test]
        public void MultiplyOneNumberWithoutEnter()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Multiply();
            displayMock.Received(1).Show(1.0);
            displayMock.Received(1).Show(0.0);
        }

        [Test]
        public void DivideOneNumberWithoutEnter()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Divide();
            displayMock.Received(1).Show(1.0);
            displayMock.Received(1).Show(0.0);
        }

        [Test]
        public void DivisionByZeroThrowsException()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Enter();
            sut.Pressed(0.0);
            Assert.Throws<RpnCalc.DivisionException>(sut.Divide);
        }

        [Test]
        public void DivideTwoNumbersHavingAVeryLargeQuotientAndRoundItToTwoDigits()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(2.0);
            sut.Enter();
            sut.Pressed(9.0);
            sut.Divide();
            displayMock.Received(2).Show(2.0);
            displayMock.Received(1).Show(9.0);
            displayMock.Received(1).Show(0.22);
        }

        [Test(Description = "(1+2) x (4-1) = 9")]
        public void IntegrationTestAddingSubtractingAndMultiplying()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1);
            sut.Enter();
            sut.Pressed(2);
            sut.Add();
            sut.Pressed(4);
            sut.Enter();
            sut.Pressed(1);
            sut.Subtract();
            sut.Multiply();
            displayMock.Received(3).Show(1.0);
            displayMock.Received(1).Show(2.0);
            displayMock.Received(2).Show(3.0);
            displayMock.Received(2).Show(4.0);
            displayMock.Received(1).Show(9.0);
        }

        [Test(Description = "2+2+1")]
        public void AddingTwiceAfterEnterWasPressed()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(1.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Enter();
            sut.Add();
            sut.Add();
            displayMock.Received(1).Show(4.0);
            displayMock.Received(1).Show(5.0);
        }
        
        [Test(Description = "2x2x3")]
        public void MultiplyingTwiceAfterEnterWasPressed()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(3.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Enter();
            sut.Multiply();
            sut.Multiply();
            displayMock.Received(1).Show(4.0);
            displayMock.Received(1).Show(12.0);
        }
        
        [Test(Description = "0/(3/(2/2))")]
        public void DividingTwiceAfterEnterWasPressed()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(3.0);
            sut.Enter();
            sut.Pressed(2.0);
            sut.Enter();
            sut.Divide();
            sut.Divide();
            sut.Divide();
            Assert.Throws<RpnCalc.DivisionException>(sut.Divide);
            displayMock.Received(1).Show(1.0);
            displayMock.Received(3).Show(3.0);
            displayMock.Received(1).Show(0.0);
        }

        [Test(Description = "6-(6-(4-(3-3))")]
        public void SubtractingTwiceAfterEnterWasPressedWhileReachingStackBoundary()
        {
            var displayMock = Substitute.For<Display>();
            var sut = new RpnCalc(displayMock);
            sut.Pressed(6.0);
            sut.Enter();
            sut.Pressed(4.0);
            sut.Enter();
            sut.Pressed(3.0);
            sut.Enter();
            sut.Subtract();
            sut.Subtract();
            sut.Subtract();
            sut.Subtract();
            displayMock.Received(1).Show(0.0);
            displayMock.Received(4).Show(4.0);
            displayMock.Received(1).Show(2.0);
        }

    }
}
