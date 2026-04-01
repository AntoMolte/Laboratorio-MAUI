using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppSpesaTest
{
    public class Tests
    {
        private WindowsDriver _driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();

            options.PlatformName = "Windows";
            options.AutomationName = "Windows";
            options.DeviceName = "WindowsPC";
            options.App = "com.companyname.appspese_9zz4h110yvjzm!App";

            options.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            var serverUri = new Uri("http://127.0.0.1:4723/");
            _driver = new WindowsDriver(serverUri, options);
        }

        [Test]
        public void Test1()
        {

            var bottone = _driver.FindElement(MobileBy.AccessibilityId("BtnSalva"));

            Assert.That(bottone.Text, Is.EqualTo("SALVA SPESA"));
            bottone.Click();
            System.Threading.Thread.Sleep(500); // Pausa tecnica per l'aggiornamento UI        }

            [TearDown]
            public void TearDown()
            {
                _driver?.Quit();
                _driver?.Dispose();
            }

        }
    }