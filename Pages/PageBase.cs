using CurrencyTables.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using CurrencyTables.Support;

namespace CurrencyTables.Pages
{
    public abstract class PageBase
    {
        protected readonly SeleniumDriver Chrome;

        protected PageBase(SeleniumDriver chrome)
        {
            Chrome = chrome;
        }

        protected IWebElement GetElementByXPath(string xPath)
        {
            return Chrome.Driver.FindElementWithTimeout(By.XPath(xPath));
        }
        protected IWebElement GetElementByCSS(string CSS)
        {
            return Chrome.Driver.FindElementWithTimeout(By.CssSelector(CSS));
        }
        protected IWebElement GetElementByID(string id)
        {
            return Chrome.Driver.FindElementWithTimeout(By.Id(id));
        }
        protected IWebElement GetElementByText(string text)
        {
            return Chrome.Driver.FindElementWithTimeout(By.XPath(string.Format("//*[text()= '{0}']", text)));
        }
        protected void HoverOverElement(string xPath)
        {
            Actions action = new Actions(Chrome.Driver);
            action.MoveToElement(Chrome.Driver.FindElementWithTimeout(By.XPath(xPath))).Perform();
        }
        protected void PressEnter(string xPath)
        {
            Chrome.Driver.FindElementWithTimeout(By.XPath(xPath)).SendKeys(Keys.Enter);
        }
    }
}
