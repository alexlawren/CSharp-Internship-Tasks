using CalculatorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            var calculator = new Calculator();
            double firstValue = 10;
            double secondValue = 5;
            double expectedResult = 15;

            double actualResult = calculator.Add(firstValue, secondValue);

            Assert.AreEqual(expectedResult, actualResult, "Сложение 10 и 5 должно было вернуть 15.");
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            var calculator = new Calculator();
            double firstValue = 20;
            double secondValue = 5;
            double expectedResult = 15;

            double actualResult = calculator.Subtract(firstValue, secondValue);

            Assert.AreEqual(expectedResult, actualResult, "Вычитание 5 из 20 должно было вернуть 15.");
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsCorrectProduct()
        {
            var calculator = new Calculator();
            double firstValue = 7;
            double secondValue = 3;
            double expectedResult = 21;

            double actualResult = calculator.Multiply(firstValue, secondValue);

            Assert.AreEqual(expectedResult, actualResult, "Умножение 7 на 3 должно было вернуть 21.");
        }

        [TestMethod]
        public void Divide_ValidNumbers_ReturnsCorrectQuotient()
        {
            var calculator = new Calculator();
            double firstValue = 100;
            double secondValue = 10;
            double expectedResult = 10;

            double actualResult = calculator.Divide(firstValue, secondValue);

            Assert.AreEqual(expectedResult, actualResult, "Деление 100 на 10 должно было вернуть 10.");
        }

        [TestMethod]
        public void Divide_DivisionByZero_ThrowsDivideByZeroException()
        {
            var calculator = new Calculator();
            double firstValue = 15;
            double secondValue = 0;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(firstValue, secondValue));
        }
    }

}
