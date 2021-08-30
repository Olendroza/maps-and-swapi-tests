using AvanssurRecruitment.Infrastructure;
using AvanssurRecruitment.PageObjects;
using AvanssurRecruitment.Services;
using OpenQA.Selenium;
using Xunit;

namespace AvanssurRecruitment.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class FrontendFixture : ICollectionFixture<FrontendFixture>
    {
        public const string CollectionName = "Maps Tests Collection";
        public IWebDriver driver;
        public Navigator navigator;
        public bool areTermsAccepted = false;

        public FrontendFixture()
        {
            driver = DriverFactory.CreateWebDriver();
            navigator = new Navigator(driver);
            driver.Manage().Window.Maximize();
        }

        public SearchMapsPageObject AcceptTermsIfNecessary()
        {
            if (!areTermsAccepted)
            {
                navigator.NavigateToMaps()
                    .ClickAgreeButton();
                areTermsAccepted = true;
            }

            return new SearchMapsPageObject(driver);
        }
    }
}
