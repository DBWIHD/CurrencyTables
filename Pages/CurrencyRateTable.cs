using CurrencyTables.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using Validation;
using CurrencyTables.Input;
using CurrencyTables.Output;

namespace CurrencyTables.Pages
{
    public static class CurrencyRateTableItems
    {
        public static string TableCurrencyName(int order) => $"//*[@id='table-section']//tr[{order}]/td[1]";
        public static string TableCurrencyRate(int order) => $"//*[@id='table-section']//tr[{order}]/td[2]";
        public static readonly string CurrencyTableTitle = "//section/div[1]/h2";
        public static readonly string SelectedCurrency = "currency";
        public static readonly string CurrencyTextField = "//*[@aria-owns='currency-listbox']";
        public static readonly string FirstCurrencyInSearch = "currency-option-0";
        public static readonly string SelectedDate = "//section/form/div[2]/div/div[1]";
        public static readonly string DateTextField = "//div[@class='DayPickerInput']//*[contains(@class,'TextInput')]";
        public static readonly string ConfirmButton = "//form/button";
        public static readonly string LearnAboutAPIButton = "//form/a";
    }

    public class CurrencyRateTable : PageBase
    {
        public CurrencyRateTable(SeleniumDriver chrome) : base(chrome)
        {
        }

        public void ClickSelectedCurrency() => GetElementByID(CurrencyRateTableItems.SelectedCurrency).Click();
        public void SendKeysToCurrencyTextField(string key) => GetElementByXPath(CurrencyRateTableItems.CurrencyTextField).SendKeys(key);
        public void SelectAllDateTextField() => GetElementByXPath(CurrencyRateTableItems.DateTextField).SendKeys(Keys.Control + "a");
        public void SendKeysToDateTextField(string key) => GetElementByXPath(CurrencyRateTableItems.DateTextField).SendKeys(key);
        public void ClickFirstCurrencyInSearch() => GetElementByID(CurrencyRateTableItems.FirstCurrencyInSearch).Click();
        public void ClickSelectedDate() => GetElementByXPath(CurrencyRateTableItems.SelectedDate).Click();
        public void ClickDateTextField() => GetElementByXPath(CurrencyRateTableItems.DateTextField).Click();
        public void ClickConfirmButton() => GetElementByXPath(CurrencyRateTableItems.ConfirmButton).Click();
        public void ClickLearnAboutAPIButton() => GetElementByXPath(CurrencyRateTableItems.LearnAboutAPIButton).Click();
        public string TableCurrencyNameToText(int order) => GetElementByXPath(CurrencyRateTableItems.TableCurrencyName(order)).Text;
        public string TableCurrencyRateToText(int order) => GetElementByXPath(CurrencyRateTableItems.TableCurrencyRate(order)).Text;
        public void CurrencyTableTitleIsCorrect(string currency)
        {
            Assert.That((GetElementByXPath(CurrencyRateTableItems.CurrencyTableTitle).Text).Contains(currency));
        }

        /// <summary>
        /// Checks if rates are correct
        /// </summary>
        /// <param name="RatesFromFile"></param>
        /// <returns>The objects list with checks results</returns>
        public List<ReportData> CheckRates(RatesFromFile RatesFromFile)
        {
            List<ReportData> reportData = new List<ReportData>();
            int i = 1;
            foreach (var filedata in RatesFromFile.Rates())
            {
                // making sure that correct page/table is opened
                Assert.That(filedata.Currency == TableCurrencyNameToText(i));
                reportData.Add(new ReportData(filedata.Currency, Verify.Equals(filedata.Rate, Convert.ToDecimal(TableCurrencyRateToText(i)))));
                i++;
            }

            return reportData;
        }

        public void PressEnterInDateTextField() => PressEnter(CurrencyRateTableItems.DateTextField);
    }
}
