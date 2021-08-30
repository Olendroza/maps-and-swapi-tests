using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AvanssurRecruitment.PageObjects
{
    public abstract class PageElement
    {
        protected WebDriverWait WaitForElement { get; }
        public IWebDriver WebDriver { get; }

        protected PageElement(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            WaitForElement = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };
        }

        protected static By GuidedHelpIdSelector(string selector) => By.CssSelector($"[guidedhelpid='{selector}']");

        protected By InputSelector => By.TagName("input");
        protected By DivSelector => By.TagName("div");
        protected By ButtonSelector => By.TagName("button");


        protected IWebElement WaitForVisibleElement(By by) =>
                WaitForElement.Until(ExpectedConditions.ElementIsVisible(by));
    }
}
