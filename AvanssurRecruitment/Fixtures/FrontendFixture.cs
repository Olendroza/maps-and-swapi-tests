using AvanssurRecruitment.PageObjects;
using AvanssurRecruitment.Services;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using Xunit;

namespace AvanssurRecruitment.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class FrontendFixture : ICollectionFixture<FrontendFixture>
    {
        public const string CollectionName = "Maps Tests Collection";
        public IWebDriver driver;
        public Navigator navigator;
        public bool isTermsAccepted = false;

        public FrontendFixture()
        {
            if(ConfigurationManager.AppSettings.Get("driver") == "chrome")
                driver = new ChromeDriver();
            else
            {
                var options = new EdgeOptions
                {
                    UseChromium = true
                };
                driver = new EdgeDriver(options);
            }

            navigator = new Navigator(driver);
            driver.Manage().Window.Maximize();
        }

        public SearchMapsPageObject BeforeTests()
        {
            if (!isTermsAccepted)
            {
                navigator.NavigateToMaps().ClickAgreeButton();
                isTermsAccepted = true;
            }

            return new SearchMapsPageObject(driver);
        }
    }
}
