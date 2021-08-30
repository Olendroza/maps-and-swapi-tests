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
            if(WebDriver.GetType().Name == "ChromeDriver")
                    WebDriver.FindElements(ButtonSelector).
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
