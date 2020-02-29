using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Test
{
    class MainWindowUITest
    {
        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        private static WindowsDriver<WindowsElement> _session;

        [OneTimeSetUp]
        public static void Setup()
        {
            if (_session != null) return;

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", @"C:\Users\Alexey\source\repos\MireaTesting\MIREA TESTING\bin\Debug\netcoreapp3.1\MIREA TESTING.exe");
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            _session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
        }

        [OneTimeTearDown]
        public static void Cleanup()
        {
            _session.Close();
            _session.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            WindowsElement inputBox = _session.FindElementByAccessibilityId("InputBox");
            int textLength = inputBox.Text.Length;
            inputBox.Clear();
        }

        [TestCase("hello", new String[] { "ohel" })]
        [TestCase("error", new String[] { "reo" })]
        [TestCase(",race car,", new String[] { "erac", "rca" })]
        [TestCase("l", new String[] { "l" })]
        [TestCase("", new String[] { })]
        [TestCase("hello error l", new String[] { "ohel", "reo", "l" })]
        [TestCase("hello error,,l", new String[] { "ohel", "reo", "l" })]
        public void Test(String input, String[] output)
        {
            WindowsElement inputBox = _session.FindElementByAccessibilityId("InputBox");
            WindowsElement outputBox = _session.FindElementByAccessibilityId("OutputBox");
            inputBox.SendKeys(input);
            var elements = outputBox.FindElementsByXPath("//ListItem")
                .Select(element => element.Text);
            Assert.AreEqual(output, elements);
        }
    }
}
