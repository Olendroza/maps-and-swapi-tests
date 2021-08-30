using AvanssurRecruitment.PageObjects;
using AvanssurRecruitment.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace AvanssurRecruitment.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class FrontEndTestsFixture : ICollectionFixture<FrontEndTestsFixture>
    {
        public const string CollectionName = "Maps Tests Collection";
        public IWebDriver driver;
        public Navigator navigator;
        public bool isTermsAccepted = false;


        public FrontEndTestsFixture()
        {
            driver = new ChromeDriver();
            navigator = new Navigator(driver);
            driver.Manage().Window.Maximize();
        }

        public SearchMapsPageObject BeforeFrontEndTestsTests()
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
