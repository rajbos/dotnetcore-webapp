using System;
using System.Diagnostics;
using System.Threading;
using dotnetcorewebapp.webtests.Helpers;
using dotnetcorewebapp.webtests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace dotnetcorewebapp.webtests
{
    [TestClass]
    public class UnitTest1
    {
        private static string GetUrl()
        {
           return Configuration.GetApplicationConfiguration().testUrl;
        }
        /// <summary>
        /// Central store of the driver instance to use
        /// </summary>
        private static IWebDriver Driver;

        /// <summary>
        /// Initialization per class instance. We'll setup a new driver so that it can be reused between tests
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var options = new ChromeOptions();
            if (!Debugger.IsAttached)
            {
                options.AddArguments("headless");
            }
            //Create the reference for our browser
            Driver = new ChromeDriver(options);

            var url = GetUrl();
            //Navigate to start page
            Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Test going to the index page
        /// </summary>
        [TestMethod]
        public void GoToIndexPage()
        {
            foreach (var pageName in new string[] { "Home", "Privacy", "dotnetcore_webapp", "Home", "Privacy", "dotnetcore_webapp" })
            {
                IWebElement element = Driver.FindElement(By.LinkText(pageName));

                element.Click();
                Wait();

                Assert.AreEqual(true, true);
            }
        }

        /// <summary>
        /// Test going to the about page
        /// </summary>
        [TestMethod]
        public void GoToPrivacyPage()
        {
            Wait();
            var pageName = "Privacy";
            IWebElement element = Driver.FindElement(By.LinkText(pageName));

            element.Click();

            var findText = "Privacy Policy";

            element = Driver.FindElement(By.XPath($"//*[contains(text(), '{findText}')]"));
            Wait();

            Assert.IsNotNull(element, $"Couldn't find description text '{findText}' on page '{pageName}'");
        }

        private static void Wait()
        {
            if (Debugger.IsAttached)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        /// <summary>
        /// Test going to the about page by using a page object
        /// </summary>
        [TestMethod]
        public void GoToPrivacyPagebyPageObject()
        {
            var mainMenuObject = new MainMenuPageObject(Driver);

            var contactPage = mainMenuObject.GoToPrivacyPage();

            Assert.IsTrue(contactPage, $"Navigation to contact page failed. Current url: '{Driver.Url}'");
        }

        /// <summary>
        /// Cleanup selenium driver object to prevent any lingering chrome instances
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            //Close the browser
            Driver.Close();
            // and actually close the chromedriver.exe
            Driver.Quit();
        }
    }
}
