using AvanssurRecruitment.Fixtures;
using AvanssurRecruitment.PageObjects;
using FluentAssertions;
using Xunit;

namespace AvanssurRecruitment.Tests
{
    [Collection(FrontendFixture.CollectionName)]
    public class RouteLengthTests
    {
        public RouteLengthTests(FrontendFixture fixture)
        {
            entryPoint = fixture.AcceptTermsIfNecessary();
        }

        private readonly SearchMapsPageObject entryPoint;

        [Theory(DisplayName = "Distance and Time of travel is shorter than test.")]
        [InlineData("Ch這dna 51, Warszawa", "plac Defilad 1, Warszawa", TravelMode.Walk, 3000, 40)]
        [InlineData("Ch這dna 51, Warszawa", "plac Defilad 1, Warszawa", TravelMode.Bike, 3000, 15)]
        [InlineData("plac Defilad 1, Warszawa", "Ch這dna 51, Warszawa",TravelMode.Walk, 3000, 40)]
        [InlineData("plac Defilad 1, Warszawa", "Ch這dna 51, Warszawa", TravelMode.Bike, 3000, 15)]
        public void MapsLoaded_TripDefined_LengthAndTimeShorterThan
            (string directionsFrom, string directionsTo, TravelMode travelMode, int expectedDistance, int expectedTime)
        {
            var searchPageObject = entryPoint
                .FillSearchInput(directionsFrom)
                .ClickDirectionsButton()
                .FillDirectionsFrom(directionsTo)
                .ChooseTravelMode(travelMode);
              var RouteResults = searchPageObject
                .GoToTripResults()
                .GetTripResults();

            searchPageObject.CloseDirectionsPage();

            RouteResults.Should().OnlyContain(route => route.Distance < expectedDistance)
                .And.OnlyContain(route => route.Time < expectedTime);
        }
    }
}
