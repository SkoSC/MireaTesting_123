using System;
using System.Collections.Generic;
using System.Text;
using Mirea;
using NUnit.Framework;

namespace Test
{
    class TextSplitterTest
    {
        private TextSplitter _splitter = TextSplitter.Default;

        [TestCase("hello world", new String[] {"hello", "world"})]
        [TestCase("hello        world", new String[] { "hello", "world" })]
        [TestCase("hello world;!", new String[] { "hello", "world", "!" })]
        [TestCase("", new String[] { })]
        [TestCase("    ;;   ", new String[] { })]
        public void DefaultImplementation(String input, String[] output)
        {
            Assert.AreEqual(output, _splitter.Split(input));
        }
    }
}