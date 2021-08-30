using OpenQA.Selenium;
using System.Linq;

namespace AvanssurRecruitment.PageObjects
{
    public class DirectionsPageObject : PageElement
    {
        public DirectionsPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }
        private By DirectionsFrom => By.Id("directions-searchbox-0");
        private By TravelModeWidget => By.ClassName("widget-directions-travel-mode-switcher-container");
        private By DirectionsXButton => GuidedHelpIdSelector("close_directions");

        public DirectionsPageObject FillDirectionsFrom(string input)
        {
            WaitForVisibleElement(DirectionsFrom);

            WebDriver
                .FindElement(DirectionsFrom)
                .FindElement(InputSelector)
                .SendKeys(input + Keys.Return);

            return this;
        }

        public DirectionsPageObject ChooseTravelMode(TravelMode mode)
        {
            var modeToString = ((int)mode).ToString();
            var travelModeContainers = WebDriver
                .FindElement(TravelModeWidget)
                .FindElements(DivSelector);

            travelModeContainers
                .Single(element => element.GetAttribute("data-travel_mode") == modeToString)
                .Click();

            return this;
        }

        public SearchMapsPageObject CloseDirectionsPage()
        {
            WebDriver.FindElement(DirectionsXButton).Click();

            return new SearchMapsPageObject(WebDriver);
        }

        public TripResultsPageObject GoToTripResults() => new TripResultsPageObject(WebDriver);
    }
}