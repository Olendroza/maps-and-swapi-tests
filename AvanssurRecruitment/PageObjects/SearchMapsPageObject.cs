using OpenQA.Selenium;

namespace AvanssurRecruitment.PageObjects
{
    public class SearchMapsPageObject : PageElement
    {
        public SearchMapsPageObject(IWebDriver webDriver) : base(webDriver)
        {
            sectionContainer = WebDriver.FindElement(Section);
        }

        private readonly IWebElement sectionContainer;
        private By Section => By.Id("omnibox");
        private By SearchBoxInput => By.Id("searchboxinput");
        private By DirectionsToButton => By.Id("searchbox-directions");

        public SearchMapsPageObject FillSearchInput(string input)
        {
            sectionContainer
                .FindElement(SearchBoxInput)
                .SendKeys(input);

            return this;
        }

        public DirectionsPageObject ClickDirectionsButton()
        {
            sectionContainer
                .FindElement(DirectionsToButton)
                .Click();

            return new DirectionsPageObject(WebDriver);
        }


    }
}