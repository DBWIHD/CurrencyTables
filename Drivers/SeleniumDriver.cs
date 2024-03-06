using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CurrencyTables.Drivers
{
    public class SeleniumDriver
    {
        public IWebDriver Driver;
        public SeleniumDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
        }
    }
}