using System;
using System.Collections.Generic;
using Mirea;
using NUnit.Framework;

namespace Test
{
    public class PrimaryTaskInteractorTest
    {
        private PrimaryTaskInteractor action = new PrimaryTaskInteractor();

        [TestCase("hello", new String[] {"ohel"})]
        [TestCase("error", new String[] {"reo"})]
        [TestCase("l", new String[] {"l"})]
        [TestCase("", new String[] { })]
        [TestCase("hello error l", new String[] {"ohel", "reo", "l"})]
        [TestCase("ww ,,    ww", new String[] {"w", "w"})]
        public void Test(String input, String[] output)
        {
            Assert.AreEqual(output, action.Apply(input));
        }
    }
}