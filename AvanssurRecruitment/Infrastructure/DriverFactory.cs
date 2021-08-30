using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace AvanssurRecruitment.Infrastructure
{
    public static class DriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {
            if (ConfigurationManager.AppSettings.Get("driver") == "chrome")
                return new ChromeDriver();
            else
            {
                var options = new EdgeOptions
                {
                    UseChromium = true
                };

                return new EdgeDriver(options);
            }
        }
    }
}
