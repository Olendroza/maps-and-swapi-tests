using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace AvanssurRecruitment.Infrastructure
{
    /// <summary>
    /// Factory that provides with right WebDriver.
    /// Edge and Chrome are supported since they are most popular web browsers on PC.
    /// </summary>
    public static class DriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {

            switch (ConfigurationManager.AppSettings.Get("driver"))
            {
                case "Chrome":
                    return new ChromeDriver();
                case "Edge":
                    var options = new EdgeOptions
                    {
                        UseChromium = true
                    };
                    return new EdgeDriver(options);
                default:
                    throw new ConfigurationErrorsException
                        ($"{ConfigurationManager.AppSettings.Get("driver")} is not valid driver option.");
            }
        }
    }
}
