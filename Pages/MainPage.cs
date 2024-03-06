using CurrencyTables.Drivers;

namespace CurrencyTables.Pages
{
    public static class MainPageItems
    {
        // 1 - 'tools', 2 - 'resources', 3 - 'sign in' or 4 - 'register'
        public static string ExpandableTabItem(int order) => $"(//div[contains(@class,'TooltipContainer')])[{order}]";
        public static string DropdownMenuItems(int tabItem, int order) => $"((//*[contains(@class,'TooltipContainer')])[{tabItem}]//li)[{order}]";
    }

    public class MainPage : PageBase
    {
        public MainPage(SeleniumDriver chrome) : base(chrome)
        {
        }

        public void ClickExpandableTabItem(int order) => GetElementByXPath(MainPageItems.ExpandableTabItem(order)).Click();
        public void ClickDropdownMenuItems(int tabItem, int order) => GetElementByXPath(MainPageItems.DropdownMenuItems(tabItem, order)).Click();
        public void HoverOverTabItem(int order) => HoverOverElement(MainPageItems.ExpandableTabItem(order));
    }
}
