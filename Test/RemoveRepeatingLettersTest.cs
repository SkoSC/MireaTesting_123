using System;
using Mirea;
using NUnit.Framework;

namespace Test
{
    public class RemoveRepeatingLettersTest
    {
        private RemoveRepeatingLetters action = new RemoveRepeatingLetters();

        [TestCase("car", "car")]
        [TestCase("tt", "t")]
        [TestCase("", "")]
        [TestCase("two two", "two ")]
        public void Test(String input, String output)
        {
            Assert.AreEqual(output, action.Apply(input));
        }
    }
}