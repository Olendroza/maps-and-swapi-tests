using OpenQA.Selenium;

namespace AvanssurRecruitment.Infrastructure
{
    public static class IWebDriverExtensions
    {
        public static bool IsChrome(this IWebDriver driver) =>
            driver.GetType().Name == "ChromeDriver";
    }
}
