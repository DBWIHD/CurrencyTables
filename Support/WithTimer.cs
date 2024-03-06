using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeoutExtensions
{
    public static class WithTimer
    {
        public static IReadOnlyCollection<IWebElement> FindElementsWithTimeout(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var slept = 0;
            while (true)
            {
                try
                {
                    var elements = driver.FindElements(by);
                    if (elements != null && elements.Any(e => e.Displayed))
                    {
                        return elements.Where(e => e.Displayed).ToList();
                    }
                }
                catch
                {
                    if (slept > timeoutInSeconds)
                        throw;
                }



                if (slept > timeoutInSeconds)
                    throw new Exception("Could not find elements");



                var step = 100;
                Thread.Sleep(step);
                slept += step;
            }
        }
        public static IWebElement FindElementWithTimeout(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile("./../../../logs/screenshotException.jpg");
                throw new WebDriverTimeoutException("failed to find element " + by + " in " + timeoutInSeconds + " seconds");
            }
        }
    }
}