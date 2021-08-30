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
            WaitForVisibleElement(FirstTripSelector);
            sectionContainer = webDriver.FindElement(SectionSelector);
        }

        private readonly IWebElement sectionContainer;
        private By TripNumbersSelector => By.ClassName("section-directions-trip-numbers");
        private By TripTimeSelector => By.ClassName("section-directions-trip-duration");
        private By TripDistanceSelector => By.ClassName("section-directions-trip-distance");
        private By FirstTripSelector => By.Id("section-directions-trip-0");
        private By SectionSelector => By.Id("pane");

        public List<TripResult> GetTripResults() => sectionContainer.FindElements(TripNumbersSelector)
            .Select(trip => new TripResult(
                time: trip.FindElement(TripTimeSelector).Text.ToMinutes(),
                distance: trip.FindElement(TripDistanceSelector).Text.ToMeters()))
            .ToList();
    }
}
