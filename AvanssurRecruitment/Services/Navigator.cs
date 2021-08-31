using AvanssurRecruitment.Data;
using AvanssurRecruitment.PageObjects;
using OpenQA.Selenium;

namespace AvanssurRecruitment.Services
{
    public class Navigator
    {
        private readonly IWebDriver driver;

        public Navigator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public TermsAndConditionsPageObject NavigateToMaps()
        {
            driver.Navigate().GoToUrl(Urls.GoogleMapsUrl);

            return new TermsAndConditionsPageObject(driver);
        }
    }
}
