using AvanssurRecruitment.PageObjects;
using OpenQA.Selenium;

namespace AvanssurRecruitment.Services
{
    public class Navigator
    {
        public const string googleMapsUrl = "https://www.google.pl/maps/";
        private readonly IWebDriver driver;

        public Navigator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public TermsAndConditionsPageObject NavigateToMaps()
        {
            driver.Navigate().GoToUrl("https://www.google.pl/maps/");

            return new TermsAndConditionsPageObject(driver);
        }
    }
}
