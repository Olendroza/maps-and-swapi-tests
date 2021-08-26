using AvanssurRecruitment.PageObjects;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AvanssurRecruitment.Tests
{
    public class TripLengthTests
    {
        [Theory]
        [InlineData("Ch這dna 51, Warszawa", "plac Defilad 1, Warszawa", TravelMode.Walk, 3000, 40)]
        [InlineData("Ch這dna 51, Warszawa", "plac Defilad 1, Warszawa", TravelMode.Bike, 3000, 15)]
        [InlineData("plac Defilad 1, Warszawa", "Ch這dna 51, Warszawa",TravelMode.Walk, 3000, 15)]
        [InlineData("plac Defilad 1, Warszawa", "Ch這dna 51, Warszawa", TravelMode.Bike, 3000, 15)]
        public void MapsLoaded_TripDefined_LengthAndTimeShorterThan
            (string directionsFrom, string directionsTo, TravelMode travelMode, int expectedDistance, int expectedTime)
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://www.google.pl/maps/");
            chrome.Manage().Window.Maximize();

            var tripResults = new TermsAndConditionsPageObject(chrome)
                .ClickAgreeButton()
                .FillSearchInput(directionsFrom)
                .ClickDirectionsButton()
                .FillDirectionsFrom(directionsTo)
                .ChooseTravelMode(travelMode)
                .GoToTripResults()
                .GatherTrips();

            tripResults.Should().OnlyContain(trip => trip.Distance < expectedDistance)
                .And.OnlyContain(trip => trip.Time < expectedTime);
        }
    }
}
