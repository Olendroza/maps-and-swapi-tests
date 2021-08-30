using OpenQA.Selenium;
using System.Linq;

namespace AvanssurRecruitment.PageObjects
{
    public class TermsAndConditionsPageObject : PageElement
    {
        public TermsAndConditionsPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public SearchMapsPageObject ClickAgreeButton()
        {
            WebDriver.FindElements(ButtonSelector).
                Single(button => button.Text == "Zgadzam się")
                .Click();

            return new SearchMapsPageObject(WebDriver);
        }
    }
}
