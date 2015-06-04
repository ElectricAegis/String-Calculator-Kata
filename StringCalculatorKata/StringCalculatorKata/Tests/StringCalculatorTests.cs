using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("",0)]
        [TestCase("1",1)]
        [TestCase("0", 0)]
        [TestCase("10",10)]
        [TestCase("13.5", 13.5)]
        [TestCase("1,2", 3)]
        [TestCase("0,12", 12)]
        [TestCase("10,1234", 1244)]
        [TestCase("13.5,127.7", 141.2)]
        [TestCase("35.058,75.376,73.986,12.168,82.792,57.5,51.252,80.478,29.899,54.893",553.402)]
        public void CanAddReturnCorrectSum(string numbers, double result)
        {
            var stringCalculator = new StringCalculator();
            Assert.AreEqual((decimal)result, stringCalculator.Add(numbers));
        }

        [TestCase("1\n2", 3)]
        [TestCase("0,12\n25", 37)]
        [TestCase("10\n1234,1", 1245)]
        [TestCase("13.5\n127.7,1", 142.2)]
        public void CanAddHandleMixedDelimiters(string numbers, double result)
        {
            var stringCalculator = new StringCalculator();
            Assert.AreEqual((decimal)result, stringCalculator.Add(numbers));
        }

        [TestCase("//;\n", 0)]
        [TestCase("//;\n1", 1)]
        [TestCase("//;\n1;2",3)]
        [TestCase("//*\n10*1234*1", 1245)]
        [TestCase("//\n\n10\n1234\n1", 1245)]
        [TestCase("//$\n13.5$127.7$1", 142.2)]
        public void CanAddParseCustomDelimiters(string numbers, double result)
        {
            var stringCalculator = new StringCalculator();
            Assert.AreEqual((decimal)result, stringCalculator.Add(numbers));
        }

        [TestCase("-1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1")]
        [TestCase("//;\n-1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1")]
        [TestCase("-1,2", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1")]
        [TestCase("//;\n-1;2", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1")]
        [TestCase("-10,-1234,1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -10,-1234")]
        [TestCase("//*\n10*-1234*-1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1,-1234")]
        [TestCase("-13.5,-127.7\n-1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1,-13.5,-127.7")]
        [TestCase("//$\n-13.5$-127.7$-1", ExpectedException = typeof(ArgumentException), ExpectedMessage = "negatives not allowed: -1,-13.5,-127.7")]
        public void AddCannotTakeNegativeNumbers(string numbers)
        {
            var stringCalculator = new StringCalculator();
            stringCalculator.Add(numbers);
        }
    }
}
