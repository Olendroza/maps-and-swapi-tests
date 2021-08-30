using AvanssurRecruitment.Fixtures;
using AvanssurRecruitment.PageObjects;
using FluentAssertions;
using Xunit;

namespace AvanssurRecruitment.Tests
{
    [Collection(FrontEndTestsFixture.CollectionName)]
    public class TripLengthTests
    {
        public TripLengthTests(FrontEndTestsFixture fixture)
        {
            entryPoint = fixture.BeforeFrontEndTestsTests();
        }

        private readonly SearchMapsPageObject entryPoint;

        [Theory]
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
              var tripResults = searchPageObject
                .GoToTripResults()
                .GatherTrips();

            searchPageObject.CloseDirectionsPage();

            tripResults.Should().OnlyContain(trip => trip.Distance < expectedDistance)
                .And.OnlyContain(trip => trip.Time < expectedTime);
        }
    }
}
