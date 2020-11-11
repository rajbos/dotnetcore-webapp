using OpenQA.Selenium;

namespace dotnetcorewebapp.webtests.PageObjects
{
    class MainMenuPageObject
    {
        private readonly IWebDriver Driver;

        const string PageLinkText = "Privacy";
        const string PageMainText = "Privacy Policy";

        public MainMenuPageObject(IWebDriver driver)
        {
            Driver = driver;
        }

        public bool GoToPrivacyPage()
        {
            IWebElement element = Driver.FindElement(By.LinkText(PageLinkText));

            element.Click();

            element = Driver.FindElement(By.XPath($"//*[contains(text(), '{PageMainText}')]"));

            return element != null;
        }
    }
}
