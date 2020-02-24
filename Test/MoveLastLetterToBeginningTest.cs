using System;
using System.Collections.Generic;
using Mirea;
using NUnit.Framework;

namespace Test
{
    public class MoveLastLetterToBeginningTest
    {
        private MoveLastLetterToBeginning action = new MoveLastLetterToBeginning();

        [TestCase("hello", "ohell")]
        [TestCase("error", "rerro")]
        [TestCase("l", "l")]
        [TestCase("", "")]
        public void Test(String input, String output)
        {
            Assert.AreEqual(output, action.Apply(input));
        }
    }
}