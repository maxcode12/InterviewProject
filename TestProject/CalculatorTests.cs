using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        [Test]
        public void CalculateSum_WhenCalled_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = _calculator.CalculateSum(1, 2);
            
            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateSum_WhenCalledWithNegativeNumbers_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = _calculator.CalculateSum(-1, -2);
            
            // Assert
            Assert.AreEqual(-3, result);
        }

        [Test]

        public void CalculateSum_WhenCalledWithNegativeAndPositiveNumbers_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = _calculator.CalculateSum(-1, 2);
            
            // Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CalculateSum_WhenCalledWithZero_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            var calculator = new Calculator();
            
            // Act
            var result = _calculator.CalculateSum(0, 10);
            
            // Assert
            Assert.AreEqual(10, result);
        }
    }
}
