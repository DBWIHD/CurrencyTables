using CurrencyTables.Drivers;
using CurrencyTables.Output;
using CurrencyTables.Pages;
using OpenQA.Selenium;
using CurrencyTables.Input;

namespace CurrencyTables.StepDefinitions
{
    [Binding]
    public class SimpleRateChecksStepDefinitions
    {
        private readonly IWebDriver driver;
        readonly MainPage MainPage;
        readonly CurrencyRateTable CurrencyRateTable;

        public SimpleRateChecksStepDefinitions(SeleniumDriver chrome)
        {
            driver = chrome.Driver;
            MainPage = new MainPage(chrome);
            CurrencyRateTable = new CurrencyRateTable(chrome);
        }

        [Given(@"user checks ""([^""]*)"" rates for ""([^""]*)""")]
        public void GivenUserChecksRatesFor(string currency, string date)
        {
            driver.Url = String.Format("https://www.xe.com/currencytables/?from={0}&date={1}#table-section", currency, date);
        }

        [When(@"historical rates page for correct ""([^""]*)"" is loaded")]
        public void WhenHistoricalRatesPageForCorrectIsLoaded(string currency)
        {
            CurrencyRateTable.CurrencyTableTitleIsCorrect(currency);
        }

        [Given(@"user is on main page")]
        public void GivenUserIsOnMainPage()
        {
            driver.Url = "https://www.xe.com/";
        }

        [Given(@"user hovers over ""([^""]*)"" tab and clicks ""([^""]*)"" button")]
        public void GivenUserHoversOverTabAndClicksButton(int tabItem, int dropDownItem)
        {
            MainPage.HoverOverTabItem(tabItem);
            MainPage.ClickDropdownMenuItems(tabItem, dropDownItem);
        }

        [Given(@"user clicks on currency")]
        public void GivenUserClicksOnCurrency()
        {
            CurrencyRateTable.ClickSelectedCurrency();
        }

        [Given(@"user selects ""([^""]*)""")]
        public void GivenUserSelects(string currency)
        {
            CurrencyRateTable.SendKeysToCurrencyTextField(currency);
            CurrencyRateTable.ClickFirstCurrencyInSearch();
        }

        [Given(@"user sets date to ""([^""]*)""")]
        public void GivenUserSetsDateTo(string date)
        {
            CurrencyRateTable.SelectAllDateTextField();
            CurrencyRateTable.SendKeysToDateTextField(date);
        }

        [When(@"user presses enter in date text field")]
        public void WhenUserPressesEnterInDateTextField()
        {
            // we could click anywhere outside of datepicker area to close pop up, but pressing enter seems way easier here
            CurrencyRateTable.PressEnterInDateTextField();
        }

        [Then(@"rates are displayed for ""([^""]*)"" on ""([^""]*)""")]
        public void ThenRatesAreDisplayedForOn(string currency, string date)
        {
            var inputFilePath = String.Format("./../../../Rates/{0}{1}Rates.txt", currency, date);
            var outputFilePath = String.Format("./../../../Reports/{0}{1}Report.xlsx", currency, date);
            RatesFromFile RatesFromFile = new RatesFromFile(inputFilePath);
            RateCheckExcel RateCheckExcel = new RateCheckExcel(outputFilePath);
            RateCheckExcel.ReportToExcel(CurrencyRateTable.CheckRates(RatesFromFile));
        }
    }
}
