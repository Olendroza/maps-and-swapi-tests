using AvanssurRecruitment.Infrastructure;
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
            if(WebDriver.IsChrome())
                    WebDriver.FindElements(ButtonSelector).
                    // Assumption - in the task there was a requirement to query maps.google.pl
                    Single(button => button.Text == "Zgadzam się")
                    .Click();
            else
                WebDriver.FindElements(InputSelector).
                    Single(input => input.GetAttribute("value") == "Zgadzam się")
                    .Click();

            return new SearchMapsPageObject(WebDriver);
        }
    }
}
