using OpenQA.Selenium;
using System.Linq;

namespace AvanssurRecruitment.PageObjects
{
    class TermsAndConditionsPageObject : PageElement
    {
        public TermsAndConditionsPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        private By ButtonTagSelector => By.TagName("button");
        public SearchMapsPageObject ClickAgreeButton()
        {
            WebDriver.FindElements(ButtonTagSelector).Single(button => button.Text == "Zgadzam się").Click();
            return new SearchMapsPageObject(WebDriver);
        }
    }
}
