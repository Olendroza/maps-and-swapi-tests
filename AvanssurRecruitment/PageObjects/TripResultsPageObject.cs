using AvanssurRecruitment.Data;
using AvanssurRecruitment.Infrastructure;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AvanssurRecruitment.PageObjects
{
    public class TripResultsPageObject : PageElement
    {
        public TripResultsPageObject(IWebDriver webDriver) : base(webDriver)
        {
            WaitForVisibleElement(FirstRouteSelector);
            sectionContainer = webDriver.FindElement(SectionSelector);
        }

        private readonly IWebElement sectionContainer;
        private By RouteNumbersSelector => By.ClassName("section-directions-trip-numbers");
        private By RouteTimeSelector => By.ClassName("section-directions-trip-duration");
        private By RouteDistanceSelector => By.ClassName("section-directions-trip-distance");
        private By FirstRouteSelector => By.Id("section-directions-trip-0");
        private By SectionSelector => By.Id("pane");

        public List<RouteResult> GetTripResults() => sectionContainer.FindElements(RouteNumbersSelector)
            .Select(route => new RouteResult(
                time: route.FindElement(RouteTimeSelector).Text.ToMinutes(),
                distance: route.FindElement(RouteDistanceSelector).Text.ToMeters()))
            .ToList();
    }
}
