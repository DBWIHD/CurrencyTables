using CurrencyTables.Drivers;
using OpenQA.Selenium;

namespace CurrencyTables.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IWebDriver driver;
        public Hooks(SeleniumDriver chrome)
        {
            driver = chrome.Driver;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}