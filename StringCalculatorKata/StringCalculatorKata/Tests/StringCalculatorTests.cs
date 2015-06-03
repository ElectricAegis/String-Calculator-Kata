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
        List<char> separators = new List<char> {',','\n'};

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
            var stringCalculator = new StringCalculator(separators);
            Assert.AreEqual((decimal)result, stringCalculator.Add(numbers));
        }

        [TestCase("1\n2", 3)]
        [TestCase("0,12\n25", 37)]
        [TestCase("10\n1234,1", 1245)]
        [TestCase("13.5\n127.7,1", 142.2)]
        public void CanAddHandleMixedDelimiters(string numbers, double result)
        {
            var stringCalculator = new StringCalculator(separators);
            Assert.AreEqual((decimal)result, stringCalculator.Add(numbers));
        }
    }
}
