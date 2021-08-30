using AvanssurRecruitment.Data;
using AvanssurRecruitment.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;

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

        public List<TripResult> GatherTrips()
        {
            var result = new List<TripResult>();
            var trips = sectionContainer.FindElements(TripNumbersSelector);

            foreach(var trip in trips)
                result.Add(new TripResult(
                    trip.FindElement(TripTimeSelector).Text.ToMinutes(),
                    trip.FindElement(TripDistanceSelector).Text.ToMeters()));

            return result;
        }
    }
}
